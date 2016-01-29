#include "surface.h"
#include <math.h>

#ifndef PI
#define PI acos(-1.0) // ArcCos of -1 is equal to PI
#endif

double surface(double sideLength, int angleCnt) {
	double sumInteriorAngles = (angleCnt - 2) * PI; // in radians

	// Half of the length of a single angle in the polygon
	double angleRads = (sumInteriorAngles / angleCnt) / 2; 
	double halfLength = sideLength / 2;

	// Using the sin theorem
	double height = ( halfLength * sin(angleRads) ) / sin((PI / 2) - angleRads);
	
	// Surface = area of single triangle * nums of triangles
	double surface = ((sideLength * height) / 2) * angleCnt;
	return surface;
}
