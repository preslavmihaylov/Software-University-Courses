#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <stdio.h>
#include <stdlib.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_INPUT_LENGTH 10
#define RESULT_NOT_FOUND -1

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    int number;
    int value;
    int deadline;
} Task;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void ScheduleOptimalTasks();
void AddMostOptimalTask(int * currentScheduledTasks, int currentScheduledTasksCount);
void SortTasks();
void ProcessInput();
void PrintScheduledTasks();
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Task * tasks;
static int * scheduledTasks;
static bool * usedTasks;

static int scheduledTasksCount;
static int tasksCount;
static int maxDeadline;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    ScheduleOptimalTasks();
    PrintScheduledTasks();
    DisposeResources();

    return 0;
}

#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void ScheduleOptimalTasks()
{
    bool resultFound = false;
    int * currentScheduledTasks = (int*)malloc(sizeof(int) * tasksCount);
    int currentScheduledTasksCount = 0;
    int currentStep = 1;

    SortTasks();

    do
    {
        resultFound = false;
        int index = 0;
        while (currentScheduledTasksCount < maxDeadline && index < tasksCount)
        {
            if (tasks[index].deadline >= currentStep && !usedTasks[index])
            {
                currentScheduledTasks[currentScheduledTasksCount++] = index;
                resultFound = true;
            }

            ++index;
        }

        AddMostOptimalTask(currentScheduledTasks, currentScheduledTasksCount);

        ++currentStep;
        currentScheduledTasksCount = 0;
    } while (resultFound);
}

void AddMostOptimalTask(int * currentScheduledTasks, int currentScheduledTasksCount)
{
    int mostOptimalTaskIndex = RESULT_NOT_FOUND;
    int minDeadline = maxDeadline + 1;

    for (int index = 0; index < currentScheduledTasksCount; ++index)
    {
        Task task = tasks[currentScheduledTasks[index]];
        if (task.deadline < minDeadline)
        {
            minDeadline = task.deadline;
            mostOptimalTaskIndex = currentScheduledTasks[index];
        }
    }

    if (mostOptimalTaskIndex != RESULT_NOT_FOUND)
    {
        usedTasks[mostOptimalTaskIndex] = true;
        scheduledTasks[scheduledTasksCount++] = mostOptimalTaskIndex;
    }
}

void SortTasks()
{
    for (int index = 1; index < tasksCount; ++index)
    {
        Task task = tasks[index];
        int innerIndex = index - 1;

        while (innerIndex >= 0 &&
               tasks[innerIndex].value < task.value)
        {
            tasks[innerIndex + 1] = tasks[innerIndex];
            --innerIndex;
        }

        tasks[innerIndex + 1] = task;
    }
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    char input[MAX_INPUT_LENGTH];

    cin >> input; // Ignore unnecessary string
    cin >> tasksCount;

    InitializeResources();

    for (int cnt = 0; cnt < tasksCount; ++cnt)
    {
        int value;
        int deadline;

        cin >> value;
        cin >> input; // Ignore unnecessary string
        cin >> deadline;

        if (deadline > maxDeadline)
        {
            maxDeadline = deadline;
        }

        tasks[cnt].number = cnt + 1;
        tasks[cnt].value = value;
        tasks[cnt].deadline = deadline;
    }
}

void PrintScheduledTasks()
{
    cout << "Optimal schedule: ";
    int totalValue = 0;

    for (int index = 0; index < scheduledTasksCount; ++index)
    {
        Task task = tasks[scheduledTasks[index]];
        totalValue += task.value;

        cout << task.number;

        if (index != scheduledTasksCount - 1)
        {
            cout << " -> ";
        }
        else
        {
            cout << endl;
        }
    }

    cout << "Total value: " << totalValue << endl;
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_MANAGEMENT

void InitializeResources()
{
    tasks = (Task*)malloc(sizeof(Task) * tasksCount);
    scheduledTasks = (int*)malloc(sizeof(int) * tasksCount);
    usedTasks = (bool*)malloc(sizeof(bool) * tasksCount);
}

void DisposeResources()
{
    free(tasks);
    free(scheduledTasks);
    free(usedTasks);
}

#endif // _RESOURCES_MANAGEMENT
