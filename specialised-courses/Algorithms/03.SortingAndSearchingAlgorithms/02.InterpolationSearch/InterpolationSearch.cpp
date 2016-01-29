#include <iostream>
#include <algorithm>

#define MAX_DATA 100

#define mSwap(first, second) do { \
    int temp = *first;             \
    *first = *second;               \
    *second = temp;                \
} while (0)

/* PROTOTYPES */
int InterpolationSearch(int key);
void ProcessInput();
int InputSearchValue();
void Print();

using namespace std;

int numbers[MAX_DATA];
static int numbersCount;

int main()
{
    ProcessInput();
    sort(numbers, numbers + numbersCount);

    int searchValue = InputSearchValue();

    cout << endl;
    Print();
    cout << endl;

    int index = InterpolationSearch(searchValue);

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

int InterpolationSearch(int key)
{
    int low = 0;
    int high = numbersCount - 1;

    while (numbers[low] <= key && numbers[high] >= key)
    {
        int mid = low +
            ((key - numbers[low]) *
            (high - low) /
            (numbers[high] - numbers[low]));

        if (numbers[mid] < key)
        {
            low = mid + 1;
        }
        else if (numbers[mid] > key)
        {
            high = mid - 1;
        }
        else
        {
            return mid;
        }
    }

    if (numbers[low] == key)
    {
        return low;
    }
    else
    {
        return -1;
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
