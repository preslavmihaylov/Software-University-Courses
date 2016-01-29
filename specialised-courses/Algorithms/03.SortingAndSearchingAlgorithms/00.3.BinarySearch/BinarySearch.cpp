#include <iostream>
#include <algorithm>

#define MAX_DATA 100

int BinarySearch(int start, int end, int searchValue);
void ProcessInput();
int InputSearchValue();
void Print();

using namespace std;

int numbers[MAX_DATA];
static int numbersCount;

int main()
{
    ProcessInput();
    int searchValue = InputSearchValue();
    sort(numbers, numbers + numbersCount);

    cout << endl;

    Print();

    cout << endl;

    int index = BinarySearch(0, numbersCount - 1, searchValue);

    if (index < 0)
    {
        cout << "Value not found" << endl;
    }
    else
    {
        cout << "Value found: "
             << numbers[index]
             << " at index: "
             << index
             << endl;
    }

    return 0;
}

int BinarySearch(int start, int end, int searchValue)
{
    if (start > end)
    {
        return -1;
    }

    int midIndex = (start + end) / 2;

    if (numbers[midIndex] > searchValue)
    {
        return BinarySearch(start, midIndex - 1, searchValue);
    }
    else if (numbers[midIndex] < searchValue)
    {
        return BinarySearch(midIndex + 1, end, searchValue);
    }
    else
    {
        return midIndex;
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

int InputSearchValue()
{
    int searchValue;

    cout << "Input value to search for: " << endl;
    cin >> searchValue;

    return searchValue;
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
