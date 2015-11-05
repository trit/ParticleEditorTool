//
// PROG56693 Games Tools and Data-Driven Design
// February 2014
// Mikhail Kutuzov, Vladyslav Dolhopolov 
//

#include "Colour.h"

Colour::Colour()
    : R(123), G(55), B(22), A(25)
{
}

Colour::Colour(byte r, byte g, byte b, byte a)
    : R(r), G(g), B(b), A(a)
{
}


Colour::~Colour()
{
}
