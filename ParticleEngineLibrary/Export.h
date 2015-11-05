//
// PROG56693 Games Tools and Data-Driven Design
// February 2014
// Mikhail Kutuzov, Vladyslav Dolhopolov 
//

#pragma once

#ifdef PARTICLELIBRARY_EXPORT
	#define PARTICLE_API _declspec(dllexport)
#else
	#define PARTICLE_API _declspec(dllimport)
#endif