#include <iostream>

#define MAX_DATA 100

#define mSwap(first, second) do { \
    int temp = *first;             \
    *first = *second;               \
    *second = temp;                \
} while (0)

/* PROTOTYPES */
void InsertionSort();
void ProcessInput();
void Print();

using namespace std;

int numbers[MAX_DATA];
static int numbersCount;

int main()
{
    ProcessInput();
    InsertionSort();
    Print();
    return 0;
}

void InsertionSort()
{
    for (int outer = 0; outer < numbersCount; outer++)
    {
        for (int inner = outer; inner > 0; inner--)
        {
            if (numbers[inner] > numbers[inner - 1])
            {
                mSwap(&numbers[inner], &numbers[inner - 1]);
            }
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
