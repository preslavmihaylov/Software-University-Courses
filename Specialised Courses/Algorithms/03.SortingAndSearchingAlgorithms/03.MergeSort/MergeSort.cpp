#include <iostream>

#define MAX_DATA 100

#define mSwap(first, second) do { \
    int temp = *first;             \
    *first = *second;               \
    *second = temp;                \
} while (0)

/* PROTOTYPES */
void MergeSort(int * buffer, int minIndex, int maxIndex);
void ProcessInput();
void Print(int *sorted);

using namespace std;

int numbers[MAX_DATA];
static int numbersCount;

int main()
{
    ProcessInput();

    int sorted[MAX_DATA];

    MergeSort(sorted, 0, numbersCount - 1);
    Print(sorted);
    return 0;
}

void MergeSort(int * buffer, int minIndex, int maxIndex)
{
    int currentNumbersCount = (maxIndex - minIndex) + 1;

    if (currentNumbersCount == 1)
    {
        buffer[0] = numbers[minIndex];
        return;
    }
    else if (currentNumbersCount < 1)
    {
        cout << "ERROR" << endl;
    }

    int left[MAX_DATA];
    int right[MAX_DATA];
    int mid = (minIndex + maxIndex) / 2;

    MergeSort(left, minIndex, mid);
    MergeSort(right, mid + 1, maxIndex);

    int leftIndex = 0;
    int rightIndex = 0;
    int bufferIndex = 0;

    int leftNumbersCount = (mid - minIndex) + 1;
    int rightNumbersCount = (maxIndex - (mid + 1) ) + 1;

    while (leftIndex < leftNumbersCount &&
           rightIndex < rightNumbersCount)
    {
        if (left[leftIndex] < right[rightIndex])
        {
            buffer[bufferIndex] = left[leftIndex];
            leftIndex++;
        }
        else
        {
            buffer[bufferIndex] = right[rightIndex];
            rightIndex++;
        }

        bufferIndex++;
    }

    while (leftIndex < leftNumbersCount)
    {
        buffer[bufferIndex] = left[leftIndex];
        leftIndex++;
        bufferIndex++;
    }

    while (rightIndex < rightNumbersCount)
    {
        buffer[bufferIndex] = right[rightIndex];
        rightIndex++;
        bufferIndex++;
    }
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

void Print(int *sorted)
{
    cout << "Sorted: " << endl;

    for (int count = 0; count < numbersCount; count++)
    {
        cout << sorted[count] << " ";
    }

    cout << endl;
}
