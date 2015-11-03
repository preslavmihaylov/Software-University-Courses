#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <algorithm>
#include <stdio.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS


#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void CalculateCoinsToTake();
void PrintCoinsToTake(int coinValue, int coinsToTake);
void ProcessInput();
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static int * coins;

static int desiredSum;
static int coinsCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    CalculateCoinsToTake();
    DisposeResources();

    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void CalculateCoinsToTake()
{
    sort(coins, coins + coinsCount);

    for (int index = coinsCount - 1; index >= 0; --index)
    {
        if (desiredSum >= coins[index])
        {
            int coinsToTake = desiredSum / coins[index];
            desiredSum = desiredSum % coins[index];

            PrintCoinsToTake(coins[index], coinsToTake);
        }
    }
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cin >> coinsCount;
    InitializeResources();

    for (int index = 0; index < coinsCount; ++index)
    {
        cin >> coins[index];
    }

    cin >> desiredSum;
}

void PrintCoinsToTake(int coinValue, int coinsToTake)
{
    printf("%d coin(s) with value %d\n", coinsToTake, coinValue);
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_MANAGEMENT

void InitializeResources()
{
    coins = new int[coinsCount];
}

void DisposeResources()
{
    delete coins;
}

#endif // _RESOURCES_DISPOSAL
