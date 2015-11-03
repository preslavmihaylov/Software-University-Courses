#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <stdio.h>
#include <stdlib.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_INPUT_LENGTH 10
#define RESULT_NOT_FOUND -1
#define MAX_PERCENTAGE 100

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    float weight;
    float price;
} Item;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void TakeOptimalItems();
void ProcessInput();
void PrintItem(int itemIndex, float percent);
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Item * items;
static bool * usedItems;

static int capacity;
static int itemsCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    TakeOptimalItems();
    DisposeResources();

    return 0;
}

#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

// A straightforward greedy approach. Take the current most optimal item (max price / weight)
void TakeOptimalItems()
{
    int mostOptimalItemIndex;
    float mostOptimalItemRating;

    do
    {
        mostOptimalItemIndex = RESULT_NOT_FOUND;
        mostOptimalItemRating = 0;

        for (int index = 0; index < itemsCount; ++index)
        {
            if (!usedItems[index])
            {
                float currentItemRating = items[index].price / items[index].weight;
                if (mostOptimalItemRating < currentItemRating)
                {
                    mostOptimalItemRating = currentItemRating;
                    mostOptimalItemIndex = index;
                }
            }
        }

        usedItems[mostOptimalItemIndex] = true;

        if (mostOptimalItemIndex != RESULT_NOT_FOUND)
        {
            Item item = items[mostOptimalItemIndex];
            if (item.weight < capacity)
            {
                capacity -= item.weight;

                PrintItem(mostOptimalItemIndex, MAX_PERCENTAGE);
            }
            else
            {
                float percentageToTake = (capacity * MAX_PERCENTAGE) / item.weight;
                capacity = 0;

                PrintItem(mostOptimalItemIndex, percentageToTake);
            }
        }

    } while (mostOptimalItemRating != RESULT_NOT_FOUND && capacity > 0);
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    char input[MAX_INPUT_LENGTH];

    cin >> input; // Skip unnecessary string
    cin >> capacity;

    cin >> input; // Skip unnecessary string
    cin >> itemsCount;

    InitializeResources();

    for (int cnt = 0; cnt < itemsCount; ++cnt)
    {
        float price;
        float weight;

        cin >> price;
        cin >> input; // Skip unnecesarry string
        cin >> weight;

        items[cnt].price = price;
        items[cnt].weight = weight;
    }
}

void PrintItem(int itemIndex, float percent)
{
    printf("Take %.2f%% of item with price %.2f and weight %.2f\n",
           percent,
           items[itemIndex].price,
           items[itemIndex].weight);
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_MANAGEMENT

void InitializeResources()
{
    items = (Item*)malloc(sizeof(Item) * itemsCount);
    usedItems = (bool*)malloc(sizeof(bool) * itemsCount);

    for (int cnt = 0; cnt < itemsCount; ++cnt)
    {
        usedItems[cnt] = false;
    }
}

void DisposeResources()
{
    free(items);
    free(usedItems);
}

#endif // _RESOURCES_MANAGEMENT
