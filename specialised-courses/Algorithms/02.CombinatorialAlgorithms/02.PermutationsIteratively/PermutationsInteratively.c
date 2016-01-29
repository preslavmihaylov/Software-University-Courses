#include <stdio.h>
#include <stdlib.h>

#define MAX_DATA 100
#define mSwap(first, second) \
    int temp = *first;       \
    *first = *second;        \
    *second = temp;          \

void Print(int *indexes);
void ProcessInput();
void FillArray();
void GeneratePermutationsWithRepetitionsIteratively();

static int numbers[MAX_DATA];
static int numbersCount;
static int permutationsCount = 0;

int main()
{
    ProcessInput();
    FillArray();
    GeneratePermutationsWithRepetitionsIteratively();

    printf("Total permutations: %d\n", permutationsCount);
    return 0;
}

void GeneratePermutationsWithRepetitionsIteratively()
{
    int indexes[MAX_DATA];
    int weights[MAX_DATA] = { 0 };
    int upperIndex = 1;
    int lowerIndex;
    int index;

    for (index = 0; index < numbersCount; index++)
    {
        indexes[index] = index;
    }

    Print(indexes);

    while (upperIndex < numbersCount)
    {
        if (weights[upperIndex] < upperIndex)
        {
            lowerIndex =
                ( upperIndex % 2 ) * weights[upperIndex];

            mSwap(&indexes[lowerIndex], &indexes[upperIndex]);

            Print(indexes);
            weights[upperIndex]++;
            upperIndex = 1;
        }
        else
        {
            weights[upperIndex] = 0;
            upperIndex++;
        }
    }
}

void Print(int *indexes)
{
    permutationsCount++;
    int index;

    for (index = 0; index < numbersCount; index++)
    {
        printf("%d ", numbers[indexes[index]]);
    }

    printf("\n");
}

void Swap(int *first, int *second)
{
    int temp = *first;
    *first = *second;
    *second = temp;
}

void ProcessInput()
{
    scanf(" %d", &numbersCount);
}

void FillArray()
{
    int count;

    for (count = 0; count < numbersCount; count++)
    {
        numbers[count] = count + 1;
    }
}
