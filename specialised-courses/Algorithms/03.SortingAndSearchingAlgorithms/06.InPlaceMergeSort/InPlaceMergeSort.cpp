#include <iostream>

#define MAX_DATA 100

#define mSwap(first, second) do { \
    int temp = *first;             \
    *first = *second;               \
    *second = temp;                \
} while (0)

/* PROTOTYPES */
void InPlaceMergeSort(int minIndex, int maxIndex);
void ProcessInput();
void Print();

using namespace std;

int numbers[MAX_DATA];
static int numbersCount;

int main()
{
    ProcessInput();

    int sorted[MAX_DATA];

    InPlaceMergeSort(0, numbersCount - 1);
    Print();
    return 0;
}

void InPlaceMergeSort(int minIndex, int maxIndex)
{
    int currentNumbersCount = (maxIndex - minIndex) + 1;

    if (currentNumbersCount == 1)
    {
        return;
    }
    else if (currentNumbersCount < 1)
    {
        cout << "ERROR" << endl;
    }

    int mid = (minIndex + maxIndex) / 2;

    InPlaceMergeSort(minIndex, mid);
    InPlaceMergeSort(mid + 1, maxIndex);

    int leftIndex = minIndex;
    int rightIndex = mid + 1;

    if (numbers[mid] <= numbers[rightIndex])
    {
        return;
    }

    while (leftIndex <= mid &&
           rightIndex <= maxIndex)
    {
        if (numbers[leftIndex] < numbers[rightIndex])
        {
            leftIndex++;
        }
        else
        {
            int temp = numbers[rightIndex];
            for (int index = rightIndex - 1; index >= leftIndex; index--)
            {
                numbers[index + 1] = numbers[index];
            }

            numbers[leftIndex] = temp;
            leftIndex++;
            rightIndex++;
            mid++;
        }
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

void Print()
{
    cout << "Sorted: " << endl;

    for (int count = 0; count < numbersCount; count++)
    {
        cout << numbers[count] << " ";
    }

    cout << endl;
}
