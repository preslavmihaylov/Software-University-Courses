#include <stdio.h>
#include <stdlib.h>

/* PROTOTYPES */
void GeneratePermutationsWithRepetition(int currentIndex);
void Print();
void Swap(int *first, int *second);
void ProcessInput();
void FillArray();

static int loop[100];
static int numbers[100];
static int variationsCount;
static int numbersCount;
static int totalPermutations = 0;

int main()
{
    ProcessInput();
    FillArray();

    GeneratePermutationsWithRepetition(0);

    printf("Total Permutations: %d\n", totalPermutations);
    return 0;
}

void GeneratePermutationsWithRepetition(int currentIndex)
{
    int count;

    if (currentIndex >= variationsCount)
    {
        totalPermutations++;
        Print();
        return;
    }

    for (count = currentIndex; count < numbersCount; count++)
    {
        Swap(&numbers[count], &numbers[currentIndex]);

        GeneratePermutationsWithRepetition(currentIndex + 1);
        Swap(&numbers[count], &numbers[currentIndex]);
    }
}

void Print()
{
    int index;

    for (index = 0; index < variationsCount; index++)
    {
        printf("%d ", numbers[index]);
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
    variationsCount = numbersCount;
}

void FillArray()
{
    int count;

    for (count = 0; count < numbersCount; count++)
    {
        numbers[count] = count + 1;
    }
}
