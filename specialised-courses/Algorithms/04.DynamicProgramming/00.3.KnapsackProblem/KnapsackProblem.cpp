#include <iostream>
#include <limits.h>

#define MAX_DATA 100

using namespace std;

/* FUNCTION PROTOTYPES */
void FindAvailableSequences();
void ExtractOptimalSubsequence();
void ProcessInput();
void PrintResult();

typedef struct
{
    int weight;
    int value;
} Item;

static Item items[MAX_DATA];
static Item optimalSubsequence[MAX_DATA];

// Arrays for keeping the current weight & value of a subsequence
static int values[MAX_DATA];
static int previousIndexes[MAX_DATA];

static int weightLimit;
static int itemsCount;
static int optimalSubsequenceLength = 0;

static int lastSequenceIndex = 0;
static int bestChoiceIndex = -1;
static int bestChoiceValue = INT_MIN;

int main()
{
    ProcessInput();
    FindAvailableSequences();
    ExtractOptimalSubsequence();
    PrintResult();

    return 0;
}

void FindAvailableSequences()
{
    // Initialize initial weight to point to an invalid index
    previousIndexes[0] = -1;

    for (int index = 0; index < itemsCount; index++)
    {
        for (int innerIndex = lastSequenceIndex; innerIndex >= 0; innerIndex--)
        {
            if ( ( innerIndex != 0 || innerIndex == 0 ) &&
                 ( innerIndex + items[index].weight <= weightLimit ) )
            {
                int newWeight = innerIndex + items[index].weight;
                int newValue = values[innerIndex] + items[index].value;

                if (newValue > values[newWeight])
                {
                    values[newWeight] = newValue;

                    if (items[index].weight != 0)
                    {
                        previousIndexes[newWeight] = innerIndex;
                    }
                }

                if ( ( newValue > bestChoiceValue ) ||
                     ( newValue == bestChoiceValue &&
                       newWeight < bestChoiceIndex ) )
                {
                    bestChoiceValue = newValue;
                    bestChoiceIndex = newWeight;
                }

                if (newWeight > lastSequenceIndex)
                {
                    lastSequenceIndex = newWeight;
                }
            }
        }
    }
}

void ExtractOptimalSubsequence()
{
    int previousIndex = bestChoiceIndex;
    int currentIndex = previousIndexes[bestChoiceIndex];

    while (currentIndex >= 0)
    {
        int currentItemWeight = previousIndex - currentIndex;
        int currentItemValue = values[previousIndex] - values[currentIndex];

        optimalSubsequence[optimalSubsequenceLength].weight = currentItemWeight;
        optimalSubsequence[optimalSubsequenceLength].value = currentItemValue;

        previousIndex = currentIndex;
        currentIndex = previousIndexes[currentIndex];
        ++optimalSubsequenceLength;
    }

    if (values[0] != 0)
    {
        optimalSubsequence[optimalSubsequenceLength].weight = 0;
        optimalSubsequence[optimalSubsequenceLength].value = values[0];

        ++optimalSubsequenceLength;
    }
}

void ProcessInput()
{
    cout << "Input weight limit: ";
    cin >> weightLimit;

    cout << "Input Items count: ";
    cin >> itemsCount;

    for (int count = 0; count < itemsCount; count++)
    {
        cin >> items[count].weight;
        cin >> items[count].value;
    }
}

void PrintResult()
{
    for (int index = 0; index < optimalSubsequenceLength; ++index)
    {
        cout << "WEIGHT: "
             << optimalSubsequence[index].weight
             << " VALUE: "
             << optimalSubsequence[index].value
             << endl;
    }

    /*
    for (int index = 0; index <= weightLimit; index++)
    {
        if (values[index] != 0)
        {
            cout << "WEIGHT: "
                 << index
                 << " VALUE: "
                 << values[index]
                 << " PREVIOUS INDEX: " << previousIndexes[index]
                 << endl;
        }
    }

    cout << endl;
    cout << "BESTINDEX: " << bestChoiceIndex << endl;
    */
}
