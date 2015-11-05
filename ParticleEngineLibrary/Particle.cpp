//
// PROG56693 Games Tools and Data-Driven Design
// February 2014
// Mikhail Kutuzov, Vladyslav Dolhopolov 
//

#include "Particle.h"

#include <algorithm>

Particle::Particle(ParticleType type, Vector2f position, Vector2f linearVelocity, float angle, float angularVelocity, Colour startColour, Colour finishColour, float ttl) :
    m_type(type),
    m_position(position),
    m_angle(angle),
    m_linearVelocity(linearVelocity),
    m_angularVelocity(angularVelocity),
    m_startColour(startColour),
    m_currentColour(startColour),
    m_finishColour(finishColour),
    m_ttl(ttl),
	m_elapsed(0)
{
}

Particle::~Particle()
{
}

void Particle::Update(float delta) {
    m_ttl -= (delta);
    m_position += (m_linearVelocity * delta);
    m_angle += (m_angularVelocity * delta);

    UpdateColor(delta);
}

// updates colour
void Particle::UpdateColor(float dt)
{
    // fades between start and finish colour during particle lifetime
	m_currentColour.R = m_currentColour.R + ((m_finishColour.R - m_currentColour.R) * (dt / m_ttl));
	m_currentColour.G = m_currentColour.G + ((m_finishColour.G - m_currentColour.G) * (dt / m_ttl));
	m_currentColour.B = m_currentColour.B + ((m_finishColour.B - m_currentColour.B) * (dt / m_ttl));
	m_currentColour.A = m_currentColour.A + ((m_finishColour.A - m_currentColour.A) * (dt / m_ttl));
}

// puts 4 bytes of a colour to an integer32 for marshalling 
int Particle::GetColour(Colour& colour)
{
    __int32 res = 0;

    byte input = colour.R;
    for (int i = 0, j = 0; i < 32; i++)
    {
        if (input & (1 << j))
        {
            res |= (1 << i);
        }

        input = (i == 7) ? colour.G : (i == 15) ? colour.B : (i == 23) ? colour.A : input;
        j = (j == 7) ? 0 : j + 1;
    }

    return res;
}

// 
// external functions
//
float GetParticlePosX(Particle** p)
{
	return (*p)->GetPosition().X;
}

float GetParticlePosY(Particle** p)
{
	return (*p)->GetPosition().Y;
}

int GetParticleColour(Particle** p)
{
    return Particle::GetColour((*p)->m_currentColour);
}

int GetParticleType(Particle** p)
{
    return (*p)->GetType();
}