#include <stdio.h>
#include <math.h>
#include <stdlib.h>

#define PI acos(-1)

int main(int argc, char ** argv) {
	int x1, y1, x2, y2, x3, y3;

	scanf("%d,%d;%d,%d;%d,%d;", &x1, &y1, &x2, &y2, &x3, &y3);

	double a = sqrt(pow(x1 - x2, 2) + pow(y1 - y2, 2));
	double b = sqrt(pow(x2 - x3, 2) + pow(y2 - y3, 2));
	double c = sqrt(pow(x1 - x3, 2) + pow(y1 - y3, 2));
	
	double angleA = acos( (pow(a, 2) - pow(b, 2) - pow(c, 2)) / (-2*b*c) );
	double angleB = acos( (pow(b, 2) - pow(a, 2) - pow(c, 2)) / (-2*a*c) );
	double angleC = acos( (pow(c, 2) - pow(b, 2) - pow(a, 2)) / (-2*b*a) );
	
	printf("%f\n", angleA * 180 / PI);
	printf("%f\n", angleB * 180 / PI);
	printf("%f\n", angleC * 180 / PI);
}
