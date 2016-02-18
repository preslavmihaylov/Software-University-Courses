#include <stdio.h>
#include <stdlib.h>

#define MAX_DATA 20

char result[MAX_DATA];
int cnt = 0;

int main(int argc, char ** argv) {
	char ch;
	while ((ch = getc(stdin)) != '.') {
		if (cnt % 2 == 0) {
			result[cnt++] = ch + 1;
		} else {	
			result[cnt++] = ch - 1;
		}
	}

	printf("%s\n", result);
}
