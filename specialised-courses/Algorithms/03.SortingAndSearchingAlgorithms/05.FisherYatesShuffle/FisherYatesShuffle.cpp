#include <iostream>
#include <random>
#include <time.h>

#define MAX_DATA 100

#define mSwap(first, second) do { \
    int temp = *first;             \
    *first = *second;               \
    *second = temp;                \
} while (0)

/* PROTOTYPES */
void Shuffle();
void ProcessInput();
void Print();

using namespace std;

int numbers[MAX_DATA];
static int numbersCount;

int main()
{
    ProcessInput();
    Shuffle();
    Print();

    return 0;
}

void Shuffle()
{
    srand(time(NULL));

    for (int count = 0; count < numbersCount; count++)
    {
        int positionToSwap = (rand() % (numbersCount - count)) + count;
        mSwap(&numbers[count], &numbers[positionToSwap]);
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
    cout << "Shuffled: " << endl;

    for (int count = 0; count < numbersCount; count++)
    {
        cout << numbers[count] << " ";
    }

    cout << endl;
}
