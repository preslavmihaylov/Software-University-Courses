#include <stdio.h>
#include <stdlib.h>

#define MAX_DATA 100

static int loop[100];
static int numbers[100];
static int variationsCount;
static int numbersCount;

int main()
{
    ProcessInput();
    FillArray();

    GenerateVariationsWithoutRepetition(0);
    return 0;
}

void GenerateVariationsWithoutRepetition(int currentIndex)
{
    int count;

    if (currentIndex >= variationsCount)
    {
        Print();
        return;
    }

    for (count = 0; count < numbersCount - currentIndex; count++)
    {
        loop[currentIndex] = numbers[count];
        Swap(&numbers[count], &numbers[numbersCount - currentIndex - 1]);

        GenerateVariationsWithoutRepetition(currentIndex + 1);

        Swap(&numbers[numbersCount - currentIndex - 1], &numbers[count]);
    }
}

void Print()
{
    int index;

    for (index = 0; index < variationsCount; index++)
    {
        printf("%d ", loop[index]);
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
    scanf(" %d", &variationsCount);
}

void FillArray()
{
    int count;

    for (count = 0; count < numbersCount; count++)
    {
        numbers[count] = count + 1;
    }
}
