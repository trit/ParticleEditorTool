//
// PROG56693 Games Tools and Data-Driven Design
// February 2014
// Mikhail Kutuzov, Vladyslav Dolhopolov 
//

#include "ParticleEmitter.h"
#include "tinyxml\tinystr.h"
#include "tinyxml\tinyxml.h"

#define MIN_VEL -25.5f
#define MAX_VEL 25.5f
#define MIN_TTL 4.0f
#define MAX_TTL 10.0f

ParticleEmitter::ParticleEmitter(Vector2f location, int emissionRate, int maxParticles, int seed) 
    : m_location(location), m_random()
    , m_emissionRate(emissionRate)
    , m_emitting(false)
    , m_maxParticles(maxParticles)
    , m_particleType(ParticleType::PARTICLE_CIRCLE)
{
    
}

void ParticleEmitter::StartEmitting() {
    m_emitting = true;
}

void ParticleEmitter::StopEmitting() {
    m_emitting = false;
}

void ParticleEmitter::DeleteAllParticles() {
    for(unsigned int p = 0; p < m_particles.size(); p++) {
        delete m_particles[p];
    }
    m_particles.clear();
}

void ParticleEmitter::Update(float delta) {
    //Emit some particles.
    if( m_emitting && m_particles.size() < m_maxParticles) {
        for(int p = 0; p < m_emissionRate; p++) {
            if( m_particles.size() < m_maxParticles ) {

				float x = nextFloat(MIN_VEL, MAX_VEL) * cosf(nextFloat(-180, 180));
				float y = nextFloat(MIN_VEL, MAX_VEL) * sinf(nextFloat(-180, 180));

                m_particles.push_back( new Particle( m_particleType, m_location, Vector2f(x, y),
                    0.0f, 0.0f, m_startColour, m_finishColour, nextFloat(MIN_TTL, MAX_TTL)));
            } else {
                break;
            }
        }
    }
    
    for(unsigned int p = 0; p < m_particles.size(); ) {
        m_particles[p]->Update(delta);
        
        if(m_particles[p]->IsDead()) {
            //delete the dead particle.
            delete m_particles[p];
            //Swap with last one on the list.
            m_particles[p] = m_particles[m_particles.size() - 1];
            //Pop it off the list.
            m_particles.pop_back();
        } else {
            p++;
        }
    }
}

float ParticleEmitter::nextFloat(float lo, float hi) {
    return lo + (float)m_random() / (float)( m_random.max() / (hi - lo) );
}

ParticleEmitter::~ParticleEmitter()
{
    for(unsigned int p = 0; p < m_particles.size(); p++) {
        delete m_particles[p];
    }
    m_particles.clear();
}

//
// accessors
//
int ParticleEmitter::GetParticleCount()
{
	return m_particles.size();
}

float ParticleEmitter::GetEmitterPosX()
{
    return m_location.X;
}

float ParticleEmitter::GetEmitterPosY()
{
    return m_location.Y;
}

void ParticleEmitter::SetEmissionRate(int value) {

    m_emissionRate = value;
}
void ParticleEmitter::SetMaxParticles(int value) {

    m_maxParticles = value;
}

void ParticleEmitter::SetStartColour(char r, char g, char b, char a) {

   m_startColour = Colour(r, g, b, a);
}

void ParticleEmitter::SetFinishColour(char r, char g, char b, char a) {

    m_finishColour = Colour(r, g, b, a);
}

void ParticleEmitter::SetParticleType(int type)
{
    m_particleType = static_cast<ParticleType>(type);
}

int ParticleEmitter::GetEmissionRate() {

    return m_emissionRate;
}

int ParticleEmitter::GetMaxParticles() {

    return m_maxParticles;
}
 
int ParticleEmitter::GetStartColour() {

    return Particle::GetColour(m_startColour);
}

int ParticleEmitter::GetFinishColour() {

    return Particle::GetColour(m_finishColour);
}
 
int ParticleEmitter::GetParticleType() {

    return m_particleType;
}

int ParticleEmitter::GetIsWorking()
{
    return (m_emitting) ? 1 : 0;
}

// parses configuration file and applies to current emitter
void ParticleEmitter::InitParticleEmitterFromFile(char* filePath) {

    
    TiXmlDocument xmlDoc = TiXmlDocument(filePath);

    if (!xmlDoc.LoadFile()) {
        throw std::runtime_error("Error loading the file");
    }

    TiXmlElement* rootElement = xmlDoc.FirstChildElement("Emitter_settings");

    byte r, g, b, a;

    m_location.X = atoi(rootElement->FirstChildElement("Position")->Attribute("x"));
    m_location.Y = atoi(rootElement->FirstChildElement("Position")->Attribute("y"));

    m_emissionRate = atoi(rootElement->FirstChildElement("Emission_rate")->GetText());
    m_maxParticles = atoi(rootElement->FirstChildElement("Max_particles")->GetText());

    r = atoi(rootElement->FirstChildElement("Start_colour")->Attribute("r"));
    g = atoi(rootElement->FirstChildElement("Start_colour")->Attribute("g"));
    b = atoi(rootElement->FirstChildElement("Start_colour")->Attribute("b"));
    a = atoi(rootElement->FirstChildElement("Start_colour")->Attribute("a"));

    m_startColour = Colour(r, g, b, a);

    r = atoi(rootElement->FirstChildElement("Finish_colour")->Attribute("r"));
    g = atoi(rootElement->FirstChildElement("Finish_colour")->Attribute("g"));
    b = atoi(rootElement->FirstChildElement("Finish_colour")->Attribute("b"));
    a = atoi(rootElement->FirstChildElement("Finish_colour")->Attribute("a"));

    m_finishColour = Colour(r, g, b, a);

    m_particleType = static_cast<ParticleType>(atoi(rootElement->FirstChildElement("Particle_type")->GetText()));
}

// 
// external functions
//
ParticleEmitter* CreateDefaultParticleEmitter()
{
	return new ParticleEmitter(Vector2f(150.0f, 150.0f), 100, 200000, 10);
}

ParticleEmitter* CreateParticleEmitter(float locationX, float locationY, int emissionRate, int maxParticles, int seed)
{
	return new ParticleEmitter(Vector2f(locationX, locationY), emissionRate, maxParticles, seed);
}

void DeleteParticleEmitter(ParticleEmitter* object)
{
	if (object != NULL)
	{
		delete object;
		object = NULL;
	}
}

Particle** GetFirstParticle(ParticleEmitter* object)
{
	if (object->m_particles.size() == 0)
	{
		return NULL;
	}
	return &(object->m_particles[0]);
}