#include <iostream>
#include "include/Heap.h"

#define MAX_DATA 100

using namespace std;

/* FUNCTION PROTOTYPES */
void Heapsort(int * buffer);
void ProcessInput();
void Print(int *sorted);

int numbers[MAX_DATA];
static int numbersCount;

int main()
{
    int sorted[MAX_DATA];

    ProcessInput();
    Heapsort(sorted);
    Print(sorted);

    return 0;
}

void Heapsort(int * buffer)
{
    Heap<int> heap (numbers, numbersCount);

    for (int index = 0; index < numbersCount; index++)
    {
        buffer[index] = heap.ExtractMin();
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

