//
// PROG56693 Games Tools and Data-Driven Design
// February 2014
// Mikhail Kutuzov, Vladyslav Dolhopolov 
//

#ifndef COLOUR_H
#define COLOUR_H

typedef unsigned char byte;

class Colour
{
public:
    byte R;
    byte G;
    byte B;
    byte A;

    Colour();
    Colour(byte r, byte g, byte b, byte a);
    ~Colour();
};

#endif