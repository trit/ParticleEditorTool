//
// PROG56693 Games Tools and Data-Driven Design
// February 2014
// Mikhail Kutuzov, Vladyslav Dolhopolov 
//

#ifndef PARTICLE_H
#define PARTICLE_H

#include "Export.h"
#include "Vector2.h"
#include "Colour.h"

enum ParticleType 
{
    PARTICLE_ELLIPSE = 0,
    PARTICLE_STAR = 1,
    PARTICLE_CIRCLE = 2,
    PARTICLE_DIAMOND = 3
};

class Particle;

extern "C" PARTICLE_API int GetParticleColour(Particle** p);

class PARTICLE_API Particle
{
public:
    Particle(ParticleType type, Vector2f position, Vector2f linearVelocity, float angle, float angularVelocity, Colour startColour, Colour finishColour, float ttl);
    ~Particle();

    void                        Update(float delta);
    bool                        IsDead() { return m_ttl <= 0; }

    Vector2f& const             GetPosition() { return m_position; }
    int                         GetType() { return m_type; }
    static int                  GetColour(Colour& colour);
    void                        UpdateColor(float dt);

private:
    friend PARTICLE_API int     GetParticleColour(Particle** p);

private:
    ParticleType                m_type;
    Vector2f                    m_position;
    float                       m_angle;
    Vector2f                    m_linearVelocity;
    float                       m_angularVelocity;
    Colour                      m_startColour;
    Colour                      m_currentColour;
    Colour                      m_finishColour;
    float                       m_ttl;
	float			            m_elapsed;
};

extern "C"
{
	PARTICLE_API float          GetParticlePosX(Particle** p);
	PARTICLE_API float          GetParticlePosY(Particle** p);
    PARTICLE_API int            GetParticleColour(Particle** p);
    PARTICLE_API int            GetParticleType(Particle** p);
}


#endif