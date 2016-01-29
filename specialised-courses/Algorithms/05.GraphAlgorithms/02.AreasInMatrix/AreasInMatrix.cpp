#include <iostream>

#define MAX_DATA 50
#define LETTERS_COUNT 26

using namespace std;

/* FUNCTION PROTOTYPES */
void FindConnectedAreas();
void MarkConnectedArea(int row, int col, char letter);
bool IsInBounds(int row, int col);
void ProcessInput();
void PrintResult();

static int rows;
static int cols;
static int totalAreas = 0;

static char matrix[MAX_DATA][MAX_DATA];
static bool visited[MAX_DATA][MAX_DATA];
static int letterOccurences[LETTERS_COUNT];

int main()
{
    ProcessInput();
    FindConnectedAreas();
    PrintResult();

    return 0;
}

void FindConnectedAreas()
{
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; matrix[row][col] != '\0'; col++)
        {
            if (!visited[row][col])
            {
                char letter = matrix[row][col];
                letterOccurences[letter - 'a']++;
                totalAreas++;

                MarkConnectedArea(row, col, letter);
            }
        }
    }
}

void MarkConnectedArea(int row, int col, char letter)
{
    if (visited[row][col] || !IsInBounds(row, col) || matrix[row][col] != letter)
    {
        return;
    }

    visited[row][col] = true;

    MarkConnectedArea(row - 1, col, letter);
    MarkConnectedArea(row, col + 1, letter);
    MarkConnectedArea(row + 1, col, letter);
    MarkConnectedArea(row, col - 1, letter);
}

bool IsInBounds(int row, int col)
{
    return row >= 0 &&
           row < rows &&
           col >= 0 &&
           matrix[row][col] != '\0';
}

void ProcessInput()
{
    cin >> rows;

    for (int index = 0; index < rows; index++)
    {
        cin >> matrix[index];
    }
}

void PrintResult()
{
    cout << "Total Occurences: " << totalAreas << endl;

    for (int index = 0; index < LETTERS_COUNT; index++)
    {
        if (letterOccurences[index] > 0)
        {
            cout << "Letter: '"
                 << (char)(index + 'a')
                 << "' -> "
                 << letterOccurences[index]
                 << endl;
        }
    }
}
