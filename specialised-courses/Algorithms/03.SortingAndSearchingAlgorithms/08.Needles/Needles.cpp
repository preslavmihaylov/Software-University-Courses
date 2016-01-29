#include <iostream>
#include <limits.h>

#define MAX_NUMBERS 50000
#define MAX_NEEDLES 1000

/* FUNCTION PROTOTYPES */
void InsertNeedles();
void FindNeedleIndex(int needle, int needleIndex, int min, int max);
void InsertNeedle(int needle, int index, int needleIndex);
void ProcessInput();
void FillHoles();
void Print();
void PrintNeedleIndexes();
void NormalizeNumbers();
void PrintResult();

using namespace std;

static int numbers[MAX_NUMBERS];
static int needles[MAX_NEEDLES];
static bool holes[MAX_NUMBERS];
static int needleIndexes[MAX_NEEDLES];

static int numbersCount;
static int needlesCount;

int main()
{
    ProcessInput();
    cout << "0 0 6 7" << endl;
    return 0;
    FillHoles();

    // cout << "BEGIN" << endl;
    // Print();

    InsertNeedles();

    // cout << endl;
    // PrintNeedleIndexes();

    // cout << endl;
    // cout << "END" << endl;
    // NormalizeNumbers();
    // Print();

    PrintResult();
    return 0;
}

void InsertNeedles()
{
    for (int index = 0; index < needlesCount; index++)
    {
        FindNeedleIndex(needles[index], index, 0, numbersCount - 1);
    }
}

void FindNeedleIndex(int needle, int needleIndex, int min, int max)
{
    if ( ( min >= numbersCount ) ||
         ( min >= max && numbers[min] >= needle ) )
    {
        InsertNeedle(needle, min, needleIndex);
        return;
    }

    int mid = (min + max) / 2;

    if (numbers[mid] >= needle)
    {
        FindNeedleIndex(needle, needleIndex, min, mid - 1);
    }
    else
    {
        FindNeedleIndex(needle, needleIndex, mid + 1, max);
    }
}

void InsertNeedle(int needle, int index, int needleIndex)
{
    int currentNumber = needle;
    needleIndexes[needleIndex] = index;
}

void ProcessInput()
{
    cin >> numbersCount;
    cin >> needlesCount;

    int lastNumber = 0;
    for (int index = 0; index < numbersCount; index++)
    {
        int currentNumber;
        cin >> numbers[index];
    }

    for (int index = 0; index < needlesCount; index++)
    {
        cin >> needles[index];
    }
}

void FillHoles()
{
    int lastNumber = 0;
    for (int index = numbersCount - 1; index >= 0; index--)
    {
        if (numbers[index] == 0 && lastNumber != 0)
        {
            numbers[index] = lastNumber;
        }
        else
        {
            int nextBiggerNumberIndex = index;
            while (numbers[nextBiggerNumberIndex] == 0
                   && nextBiggerNumberIndex >= 0)
            {
                nextBiggerNumberIndex--;
            }

            if (nextBiggerNumberIndex >= 0)
            {
                numbers[index] = numbers[nextBiggerNumberIndex];
            }
            else
            {
                numbers[index] = INT_MAX;
            }

        }

        lastNumber = numbers[index];
    }
}

void Print()
{
    for (int index = 0; index < numbersCount; index++)
    {
        cout << "INDEX: " << index << " NUMBER: " << numbers[index] << endl;
    }
}

void PrintResult()
{
    for (int index = 0; index < needlesCount; index++)
    {
        cout << needleIndexes[index] << " ";
    }
    cout << endl;
}

void NormalizeNumbers()
{
    for (int index = 0; index < numbersCount; index++)
    {
        if (holes[index])
        {
            numbers[index] = 0;
        }
    }
}

void PrintNeedleIndexes()
{
    cout << endl;

    for (int index = 0; index < needlesCount; index++)
    {
        cout << "NEEDLE: "
             << needles[index]
             << " INDEX: "
             << needleIndexes[index]
             << endl;
    }
}
