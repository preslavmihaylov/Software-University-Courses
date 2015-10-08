#include <stdio.h>
#include <stdlib.h>

#define MAX_DATA 100

int loop[MAX_DATA];
int numbers[MAX_DATA];

int numbersCount;
int combinationSize;

int main()
{
    ProcessInput();
    FillArray();

    GenerateCombinationsWithoutRepetition(0, 0);
    return 0;
}

void GenerateCombinationsWithoutRepetition(int currentIndex,
                                           int currentNumberIndex)
{
    int count;

    if (currentIndex >= combinationSize)
    {
        Print();
        return;
    }

    for (count = currentNumberIndex; count < numbersCount; count++)
    {
        loop[currentIndex] = numbers[count];
        GenerateCombinationsWithoutRepetition(currentIndex + 1, count + 1);
    }
}

void Print()
{
    int index;

    for (index = 0; index < combinationSize; index++)
    {
        printf("%d ", loop[index]);
    }

    printf("\n");
}

void ProcessInput()
{
    scanf(" %d", &numbersCount);
    scanf(" %d", &combinationSize);
}

void FillArray()
{
    int count;

    for (count = 0; count < numbersCount; count++)
    {
        numbers[count] = count + 1;
    }
}

