#include <stdio.h>
#include <stdlib.h>
#include <limits.h>

#define MAX_DATA 100
#define mSwap(first, second)     \
    do                           \
    {                            \
        int temp;                \
        temp = *first;           \
        *first = *second;        \
        *second = temp;          \
    } while(0)                   \

void GeneratePermutationsWithRepetition(int start, int end);
void processInput();
void print();
void sortArray();

static int numbers[MAX_DATA];
static int numbersCount;
static int permutationsCount = 0;

int main()
{
    processInput();

    sortArray();
    GeneratePermutationsWithRepetition(0, numbersCount - 1);
    printf("%d", permutationsCount);
    return 0;
}

void GeneratePermutationsWithRepetition(int start, int end)
{
    int left;
    int right;
    int firstElement;
    int i;

    permutationsCount++;

    for (left = end - 1; left >= start; left--)
    {
        for (right = left + 1; right <= end; right++)
        {
            if (numbers[left] != numbers[right])
            {
                mSwap(&numbers[left], &numbers[right]);
                GeneratePermutationsWithRepetition(left + 1, end);
            }
        }

        firstElement = numbers[left];

        for (i = left; i <= end - 1; i++)
        {
            numbers[i] = numbers[i + 1];
        }

        numbers[end] = firstElement;
    }
}

void sortArray()
{
    int outer;
    int inner;
    int largestNumIndex;
    int smallestNum;

    for (outer = 0; outer < numbersCount; outer++)
    {
        largestNumIndex = -1;
        smallestNum = INT_MAX;

        for (inner = outer + 1; inner < numbersCount; inner++)
        {
            if (numbers[inner] < smallestNum)
            {
                smallestNum = numbers[inner];
                largestNumIndex = inner;
            }
        }

        if (largestNumIndex >= 0 && numbers[outer] > numbers[largestNumIndex])
        {
            mSwap(&numbers[largestNumIndex], &numbers[outer]);
        }
    }
}

void processInput()
{
    int count;

    scanf("%d", &numbersCount);

    for (count = 0; count < numbersCount; count++)
    {
        scanf("%d", &numbers[count]);
    }
}

void print()
{
    int index;

    for (index = 0; index < numbersCount; index++)
    {
        printf("%d ", numbers[index]);
    }

    printf("\n");
}
