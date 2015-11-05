//
// PROG56693 Games Tools and Data-Driven Design
// February 2014
// Mikhail Kutuzov, Vladyslav Dolhopolov 
//

#ifndef PARTICLE_EMITTER_H
#define PARTICLE_EMITTER_H

#include <random>
#include <vector>

#include "Vector2.h"
#include "Particle.h"

class ParticleEmitter;

extern "C" PARTICLE_API Particle** GetFirstParticle(ParticleEmitter* object);

class PARTICLE_API ParticleEmitter
{

public:
    ParticleEmitter(Vector2f location, int emissionRate, int maxParticles, int seed = 0);
    ~ParticleEmitter();

    void    StartEmitting();
    void    StopEmitting();
    void    DeleteAllParticles();
    void    Update(float delta);

    void    SetEmissionRate(int value);
    void    SetMaxParticles(int value);
    void    SetStartColour(char r, char g, char b, char a);
    void    SetFinishColour(char r, char g, char b, char a);
    void    SetParticleType(int type);

    int     GetParticleCount();
    float   GetEmitterPosX();
    float   GetEmitterPosY();
    int     GetEmissionRate();
    int     GetMaxParticles();
    int     GetStartColour();
    int     GetFinishColour();
    int     GetParticleType();
    int     GetIsWorking();    

    void     InitParticleEmitterFromFile(char* filePath);
	
private:
    float nextFloat(float lo, float high);

    friend PARTICLE_API Particle** GetFirstParticle(ParticleEmitter* object);

private:
    Vector2f                    m_location;
    std::vector<Particle*>      m_particles;
    std::default_random_engine  m_random;
    bool                        m_emitting;
    int                         m_emissionRate;
    int                         m_maxParticles;
    Colour                      m_startColour;
    Colour                      m_currentColour;
    Colour                      m_finishColour;
    ParticleType                m_particleType;
    
};

extern "C"
{
	PARTICLE_API ParticleEmitter*   CreateDefaultParticleEmitter();
	PARTICLE_API ParticleEmitter*   CreateParticleEmitter(float locationX, float locationY, int emissionRate, int maxParticles, int seed = 0);
	PARTICLE_API void               DeleteParticleEmitter(ParticleEmitter* object);
	PARTICLE_API Particle**         GetFirstParticle(ParticleEmitter* object);
}

#endif