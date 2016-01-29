#include <stdio.h>
#include <stdlib.h>

#define MAX_DATA 100

void generateCombinationsIteratively();
void print(int *combinations);
void processInput();

static int numbersCount;
static int combinationSize;

int main()
{
    processInput();
    generateCombinationsIteratively();
    return 0;
}

void generateCombinationsIteratively()
{
    int combinations[MAX_DATA];
    int count;
    int t;
    int index;

    for (count = 0; count < combinationSize; count++)
    {
        combinations[count] = count;
    }

    while (combinations[combinationSize - 1] < numbersCount)
    {
        print(combinations);

        t = combinationSize - 1;
        while (t != 0 &&
               combinations[t] == numbersCount - combinationSize + t)
        {
            t--;
        }

        combinations[t]++;

        for (index = t + 1; index < combinationSize; index++)
        {
            combinations[index] = combinations[index - 1] + 1;
        }
    }
}

void print(int *combinations)
{
    int count;

    for (count = 0; count < combinationSize; count++)
    {
        printf("%d ", combinations[count] + 1);
    }
    printf("\n");
}

void processInput()
{
    scanf("%d", &numbersCount);
    scanf("%d", &combinationSize);
}
