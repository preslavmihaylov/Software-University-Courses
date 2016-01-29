#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_DATA 100

void generateStringSubsets(int currentIndex, int wordIndex);
void print();
void processInput();

static char strings[MAX_DATA][MAX_DATA];
static char combinations[MAX_DATA][MAX_DATA];
static int stringsCount;
static int combinationSize;

int main()
{
    processInput();
    generateStringSubsets(0, 0);

    return 0;
}

void generateStringSubsets(int currentIndex, int wordIndex)
{
    int count;

    if (currentIndex >= combinationSize)
    {
        print();
        return;
    }

    for (count = wordIndex; count < stringsCount; count++)
    {
        strcpy(combinations[currentIndex], strings[count]);
        generateStringSubsets(currentIndex + 1, count + 1);
    }
}

void print()
{
    int count;
    printf("(");

    for (count = 0; count < combinationSize; count++)
    {
        printf("%s ", combinations[count]);
    }

    printf(")\n");
}

void processInput()
{
    int count;

    scanf("%d", &stringsCount);
    scanf("%d", &combinationSize);

    for (count = 0; count < stringsCount; count++)
    {
        scanf(" %s", &strings[count]);
    }
}
