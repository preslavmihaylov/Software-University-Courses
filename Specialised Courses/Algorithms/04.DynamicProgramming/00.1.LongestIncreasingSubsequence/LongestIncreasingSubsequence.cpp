#include <iostream>
#define MAX_DATA 100

void FindLongestIncreasingSequence();
void ProcessInput();
void PrintResult();
void StoreLongestIncreasingSequence();

using namespace std;

static int numbersCount;
static int longestSequenceLength = 0;
static int longestSequenceLastIndex = 0;

static int numbers[MAX_DATA];
static int lengths[MAX_DATA];
static int previousIndexes[MAX_DATA];
static int resultSequence[MAX_DATA];

int main()
{
    ProcessInput();
    FindLongestIncreasingSequence();
    PrintResult();
    return 0;
}

void FindLongestIncreasingSequence()
{
    for (int index = 0; index < numbersCount; ++index)
    {
        int currentLargestSequence = 0;
        int lastNumberIndex = -1;
        previousIndexes[index] = -1;

        for (int innerIndex = index - 1; innerIndex >= 0; --innerIndex)
        {
            if (numbers[index] > numbers[innerIndex] &&
                currentLargestSequence <= lengths[innerIndex])
            {
                currentLargestSequence = lengths[innerIndex];
                previousIndexes[index] = innerIndex;
            }
        }

        lengths[index] = currentLargestSequence + 1;
        if (lengths[index] > longestSequenceLength)
        {
            longestSequenceLength = lengths[index];
            longestSequenceLastIndex = index;
        }
    }

    StoreLongestIncreasingSequence();
}

void StoreLongestIncreasingSequence()
{
    int currentIndex = longestSequenceLastIndex;
    int currentLongestSequenceIndex = longestSequenceLength - 1;

    while (currentIndex >= 0)
    {
        resultSequence[currentLongestSequenceIndex] = numbers[currentIndex];
        currentIndex = previousIndexes[currentIndex];
        currentLongestSequenceIndex--;
    }
}

void ProcessInput()
{
    cin >> numbersCount;

    for (int index = 0; index < numbersCount; index++)
    {
        cin >> numbers[index];
    }
}

void PrintResult()
{
    cout << "LENGTH: " << longestSequenceLength << endl;

    for (int index = 0; index < longestSequenceLength; index++)
    {
        cout << resultSequence[index] << " ";
    }

    cout << endl;
}
