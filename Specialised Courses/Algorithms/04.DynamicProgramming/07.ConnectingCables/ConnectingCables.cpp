#include <iostream>
#include <stack>

#define MAX_DATA 100

using namespace std;

#ifndef _FUNCTION_PROTOTYPES

int FindMaxConnectedPairs();
int FindMaxConnectedPairsPrivate(int upperMin,
                                 int upperMax,
                                 int lowerMin,
                                 int lowerMax,
                                 stack<int> *optimalConnectedPairs);
void ProcessInput();
void PrintResult(int maxConnectedPairs);

#endif // _FUNCTION_PROTOTYPES

static int pairs[MAX_DATA];
stack<int> connectedPairs;

static int pairsCount;

int main()
{
    ProcessInput();
    int maxConnectedPairs = FindMaxConnectedPairs();
    PrintResult(maxConnectedPairs);

    return 0;
}

#ifndef _FIND_MAX_CONNECTED_PAIRS

// A simple encapsulation
int FindMaxConnectedPairs()
{
    return FindMaxConnectedPairsPrivate(0,
                                        pairsCount - 1,
                                        0,
                                        pairsCount - 1,
                                        &connectedPairs);
}

int FindMaxConnectedPairsPrivate(int upperMin,
                                 int upperMax,
                                 int lowerMin,
                                 int lowerMax,
                                 stack<int> *optimalConnectedPairs)
{
    if (upperMin > upperMax || lowerMin > lowerMax)
    {
        return 0;
    }

    int maxConnectedPairs = 0;
    int optimalIndex;

    for (int index = upperMin; index <= upperMax; index++)
    {
        if (pairs[index] >= lowerMin && pairs[index] <= lowerMax)
        {
            stack<int> currentConnectedPairs;

            int currentConnectedPairsCount = 1;
            currentConnectedPairsCount +=
                FindMaxConnectedPairsPrivate(upperMin,
                    index - 1,
                    lowerMin,
                    pairs[index] - 1,
                    &currentConnectedPairs);

            currentConnectedPairsCount +=
                FindMaxConnectedPairsPrivate(index + 1,
                                             upperMax,
                                             pairs[index] + 1,
                                             lowerMax,
                                             &currentConnectedPairs);

            if (currentConnectedPairsCount > maxConnectedPairs)
            {
                (*optimalConnectedPairs) = currentConnectedPairs;
                optimalIndex = index;
                maxConnectedPairs = currentConnectedPairsCount;
            }
        }
    }

    (*optimalConnectedPairs).push(optimalIndex);

    return maxConnectedPairs;
}

#endif // _FIND_MAX_CONNECTED_PAIRS

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cin >> pairsCount;

    int currentIndex = 0;

    for (int count = 0; count < pairsCount; count++)
    {
        int number;
        cin >> number;

        pairs[number - 1] = currentIndex;
        currentIndex++;
    }
}

void PrintResult(int maxConnectedPairs)
{
    cout << "Connected Pairs Count: " << maxConnectedPairs << endl;

    cout << "Connected Cables: ";
    while (connectedPairs.size() > 0)
    {
        int element = connectedPairs.top() + 1;
        connectedPairs.pop();

        cout << element << " ";
    }

    cout << endl;
}

#endif // _IO_PROCESSING
