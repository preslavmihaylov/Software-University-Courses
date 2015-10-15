#include <iostream>

#define MAX_DATA 100

#define mSwap(first, second) do { \
    int temp = *first;             \
    *first = *second;               \
    *second = temp;                \
} while (0)

/* PROTOTYPES */
void Quicksort(int minIndex, int maxIndex);
void ProcessInput();
void Print();

using namespace std;

int numbers[MAX_DATA];
static int numbersCount;

int main()
{
    ProcessInput();
    Quicksort(0, numbersCount - 1);
    Print();
    return 0;
}

void Quicksort(int minIndex, int maxIndex)
{
    if (minIndex >= maxIndex)
    {
        return;
    }

    int pivotIndex = maxIndex;
    int stepIndex = minIndex;

    for (int index = minIndex; index < maxIndex; index++)
    {
        if (numbers[index] <= numbers[pivotIndex])
        {
            mSwap(&numbers[index], &numbers[stepIndex]);
            stepIndex++;
        }
    }

    mSwap(&numbers[stepIndex], &numbers[pivotIndex]);

    Quicksort(minIndex, stepIndex - 1);
    Quicksort(stepIndex + 1, maxIndex);
}

void ProcessInput()
{
    cout << "Input the count of the numbers" << endl;
    cin >> numbersCount;

    for (int count = 0; count < numbersCount; count++)
    {
        cin >> numbers[count];
    }
}

void Print()
{
    cout << "Sorted: " << endl;

    for (int count = 0; count < numbersCount; count++)
    {
        cout << numbers[count] << " ";
    }

    cout << endl;
}
