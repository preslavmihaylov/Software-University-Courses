#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <sstream>
#include <vector>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_DATA 50

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    vector<int> connectedComponents;
    long long usedConnections;
    int index;
} Pair;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void CalculateMaxConnectedComponents();
int FindMaxConnectedComponents(int upperMin,
                               int upperMax,
                               int lowerMin,
                               int lowerMax);
void PrintMaxConnectedComponents(int maxConnectedComponents);
int GetBitAtPosition(long long number, int position);
void SetBitAtPosition(long long * number, int position, int bit);
void ProcessInput();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Pair pairs[MAX_DATA];

static int upperNumbersCount;
static int lowerNumbersCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    CalculateMaxConnectedComponents();

    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void CalculateMaxConnectedComponents()
{
    int maxConnectedComponentsCount =
        FindMaxConnectedComponents(0,
                                   upperNumbersCount - 1,
                                   0,
                                   lowerNumbersCount - 1);

    PrintMaxConnectedComponents(maxConnectedComponentsCount);
}

int FindMaxConnectedComponents(int upperMin, int upperMax, int lowerMin, int lowerMax)
{
    int optimalMaxConnectedComponents = 0;

    for (int cnt = upperMin; cnt <= upperMax; ++cnt)
    {
        for (int conIndex = 0;
             conIndex < pairs[cnt].connectedComponents.size();
             ++conIndex)
        {
            int nextPairIndex = pairs[cnt].connectedComponents.at(conIndex);

            if (nextPairIndex >= lowerMin &&
                nextPairIndex <= lowerMax &&
                !GetBitAtPosition(pairs[cnt].usedConnections, conIndex))
            {
                SetBitAtPosition(&pairs[cnt].usedConnections, conIndex, 1);
                int currentMaxConnectedComponents = 1;

                currentMaxConnectedComponents +=
                    FindMaxConnectedComponents(upperMin,
                                               cnt,
                                               lowerMin,
                                               nextPairIndex);

                currentMaxConnectedComponents +=
                    FindMaxConnectedComponents(cnt,
                                               upperMax,
                                               nextPairIndex,
                                               lowerMax);

                SetBitAtPosition(&pairs[cnt].usedConnections, conIndex, 0);

                if (currentMaxConnectedComponents > optimalMaxConnectedComponents)
                {
                    optimalMaxConnectedComponents = currentMaxConnectedComponents;
                }
            }
        }
    }

    return optimalMaxConnectedComponents;
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    int number;
    string line;
    getline(cin, line);
    istringstream firstLineStream(line);

    while (firstLineStream >> number)
    {
        pairs[upperNumbersCount].index = number;
        ++upperNumbersCount;
    }

    getline(cin, line);
    istringstream secondLineStream(line);

    while (secondLineStream >> number)
    {
        for (int index = 0; index < upperNumbersCount; ++index)
        {
            if (pairs[index].index == number)
            {
                pairs[index].connectedComponents.push_back(lowerNumbersCount);
            }
        }

        ++lowerNumbersCount;
    }
}

void PrintMaxConnectedComponents(int maxConnectedComponents)
{
    cout << maxConnectedComponents << endl;
}

#endif // _IO_PROCESSING

#ifndef _BITWISE_OPERATIONS

int GetBitAtPosition(long long number, int position)
{
    return (number >> position) & 1;
}

void SetBitAtPosition(long long * number, int position, int bit)
{
    if (bit == 0)
    {
        (*number) &= ( ~((long long)1 << position));
    }
    else
    {
        (*number) |= (long long)1 << position;
    }
}

#endif // _BITWISE_OPERATIONS

#ifndef _RESOURCES_MANAGEMENT

#endif // _RESOURCES_DISPOSAL
