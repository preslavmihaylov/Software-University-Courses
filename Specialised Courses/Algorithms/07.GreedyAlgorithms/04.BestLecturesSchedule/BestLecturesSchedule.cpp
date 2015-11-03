#ifndef _LIBS_NAMESPACES

#include <stdlib.h>
#include <stdio.h>
#include <iostream>

using namespace std;

#endif // _LIBS_NAMESPACES

#define RESULT_NOT_FOUND -1

#ifndef _LOCAL_CONSTANTS

#define MAX_INPUT_LENGTH 20

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    string name;
    int start;
    int finish;
} Lecture;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void ChooseOptimalSchedule();
void ScheduleLecture(int lectureIndex, int * currentTime);
void ProcessInput();
void PrintLectureSchedule();
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Lecture * lectures;
static int * scheduledLectures;

static int scheduledLecturesCount;
static int lecturesCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    ChooseOptimalSchedule();
    PrintLectureSchedule();
    DisposeResources();

    return 0;
}

#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

// A straightforward greedy approach. Choose the lecture with least end time which is still available.
void ChooseOptimalSchedule()
{
    int currentTime = 0;
    int currentBestLectureIndex;

    do
    {
        currentBestLectureIndex = RESULT_NOT_FOUND;
        int minFinishTime = INT_MAX;

        for (int index = 0; index < lecturesCount; ++index)
        {
            if (lectures[index].finish < minFinishTime && currentTime <= lectures[index].start)
            {
                minFinishTime = lectures[index].finish;
                currentBestLectureIndex = index;
            }
        }

        if (currentBestLectureIndex != RESULT_NOT_FOUND)
        {
            ScheduleLecture(currentBestLectureIndex, &currentTime);
        }

    } while (currentBestLectureIndex != RESULT_NOT_FOUND);
}

void ScheduleLecture(int lectureIndex, int * currentTime)
{
    scheduledLectures[scheduledLecturesCount++] = lectureIndex;
    (*currentTime) = lectures[lectureIndex].finish;
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    string input;

    cin >> input; // Ignore unnecessary string
    cin >> lecturesCount;

    InitializeResources();

    for (int cnt = 0; cnt < lecturesCount; ++cnt)
    {
        int start;
        int finish;

        cin >> input;
        lectures[cnt].name = input;

        // Remove the ':' character in the rear of the string
        lectures[cnt].name = lectures[cnt].name.substr(0, lectures[cnt].name.size() - 1);

        cin >> start;
        cin >> input; // Ignore unnecessary string
        cin >> finish;

        lectures[cnt].start = start;
        lectures[cnt].finish = finish;
    }
}

void PrintLectureSchedule()
{
    printf("Lectures (%d):\n", scheduledLecturesCount);

    for (int index = 0; index < scheduledLecturesCount; ++index)
    {
        Lecture lecture = lectures[scheduledLectures[index]];
        printf("%d - %d -> %s\n", lecture.start, lecture.finish, lecture.name.c_str());
    }
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_MANAGEMENT

void InitializeResources()
{
    lectures = new Lecture[lecturesCount];
    scheduledLectures = new int[lecturesCount];
}

void DisposeResources()
{
    delete lectures;
    delete scheduledLectures;
}

#endif // _RESOURCES_MANAGEMENT
