#include <stdio.h>
#include "perimeter.h"
#include "surface.h"

int main(int argc, char ** argv) {
	double side;
	int angleCnt;
	printf("Enter side lengths: ");
	scanf("%lf", &side);
	printf("Enter angles count: ");
	scanf("%d", &angleCnt);

	printf("Perimeter: %.2lf\n", perimeter(side, angleCnt));
	printf("Surface: %.2lf\n", surface(side, angleCnt));
}
