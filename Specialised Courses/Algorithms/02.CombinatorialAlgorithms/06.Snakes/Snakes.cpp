#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unordered_set>
#include <iostream>
#include <sstream>
#include <algorithm>

#define MOVES_COUNT 4
#define MAX_DATA 16
#define MAX_FIELD_LENGTH 30

using namespace std;

void generateSnakeMovement(int currentIndex, int lastMove, int row, int col);
void processInput();
void print();
void getSequenceStringRepresentation(string *buffer);
void storeSimilarFigures(string *sequence);
void exchangeAsymmetricCharactersAndStore(string *sequence);
void exchangeSymmetricCharactersAndStore(string *sequence);
void exchangeUpAndDownAndStore(string *sequence);
void exchangeCharacters(string *sequence, char first, char second);
int getNextRow(int row, int direction);
int getNextCol(int col, int direction);

static char availableMoves[4][2] =
{
    "R",
    "D",
    "L",
    "U"
};

#ifndef __FIELD

static char field[MAX_FIELD_LENGTH][MAX_FIELD_LENGTH] =
{
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
    {
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
      ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
    },
};

#endif // __FIELD

static int moves[MAX_DATA];
static int snakeSize;
static int combinationsCount = 0;
static unordered_set <string> similarElements;

int main()
{
    processInput();
    generateSnakeMovement(0, -3, MAX_FIELD_LENGTH / 2, MAX_FIELD_LENGTH / 2);
    printf("Snakes count = %d", combinationsCount);

    printf("\n");
    
    for (auto itr = similarElements.begin(); itr != similarElements.end(); ++itr)
    {
        //cout << *itr << endl;
        delete &itr;
    }
    
    return 0;
}

void generateSnakeMovement(int currentIndex, int lastMove, int row, int col)
{
    int count;
    int nextRow;
    int nextCol;

    if (field[row][col] == '*')
    {
        return;
    }

    if (currentIndex >= snakeSize - 1)
    {
        string sequence;
        int index;
        int currentMoveIndex;

        getSequenceStringRepresentation(&sequence);

        unordered_set<string>::const_iterator elementIndex =
            similarElements.find(sequence);

        if (elementIndex == similarElements.end())
        {
            print();
            storeSimilarFigures(&sequence);
            combinationsCount++;
        }
        return;
    }

    field[row][col] = '*';

    for (count = 0; count < MOVES_COUNT; count++)
    {
        // Optimization: no need to iterate directions other than right
        // on the first recursive call
        if (currentIndex == 0 && count > 0)
        {
            break;
        }

        if ((count + 2) != lastMove &&
            (count - 2) != lastMove)
        {
            moves[currentIndex] = count;
            nextRow = getNextRow(row, count);
            nextCol = getNextCol(col, count);

            generateSnakeMovement(currentIndex + 1, count, nextRow, nextCol);
        }
    }

    field[row][col] = ' ';
}

void processInput()
{
    scanf("%d", &snakeSize);
}

void print()
{
    int index;
    int currentMoveIndex;

    printf("S");

    for (index = 0; index < snakeSize - 1; index++)
    {
        currentMoveIndex = moves[index];
        printf("%s", availableMoves[currentMoveIndex]);
    }
    printf("\n");
}

void getSequenceStringRepresentation(string *buffer)
{
    int index;
    int currentMoveIndex;
    stringstream ss;

    for (index = 0; index < snakeSize - 1; index++)
    {
        currentMoveIndex = moves[index];
        ss << currentMoveIndex;
    }

    *buffer = ss.str();
}

void storeSimilarFigures(string *sequence)
{
    exchangeAsymmetricCharactersAndStore(sequence);

    reverse((*sequence).begin(), (*sequence).end());

    exchangeAsymmetricCharactersAndStore(sequence);
}

void exchangeAsymmetricCharactersAndStore(string *sequence)
{
    exchangeCharacters(sequence, '0', '3'); // RIGHT and UP
    exchangeCharacters(sequence, '1', '4'); // LEFT and DOWN

    exchangeSymmetricCharactersAndStore(sequence);

    exchangeCharacters(sequence, '0', '3'); // RIGHT and UP
    exchangeCharacters(sequence, '1', '4'); // LEFT and DOWN

    exchangeSymmetricCharactersAndStore(sequence);

    exchangeCharacters(sequence, '0', '1'); // RIGHT and DOWN
    exchangeCharacters(sequence, '2', '3'); // LEFT and UP

    exchangeSymmetricCharactersAndStore(sequence);

    exchangeCharacters(sequence, '0', '1'); // RIGHT and DOWN
    exchangeCharacters(sequence, '2', '3'); // LEFT and UP

    exchangeSymmetricCharactersAndStore(sequence);
}

void exchangeSymmetricCharactersAndStore(string *sequence)
{
    exchangeCharacters(sequence, '0', '2'); // RIGHT and LEFT

    exchangeUpAndDownAndStore(sequence);

    exchangeCharacters(sequence, '0', '2'); // RIGHT and LEFT

    exchangeUpAndDownAndStore(sequence);
}

void exchangeUpAndDownAndStore(string *sequence)
{
    int index;
    string *firstSequenceToStore = new string;
    string *secondSequenceToStore = new string;

    exchangeCharacters(sequence, '3', '1'); // UP and DOWN

    firstSequenceToStore = sequence;

    if (similarElements.find(*firstSequenceToStore) == similarElements.end())
    {
        similarElements.insert(*firstSequenceToStore);
    }

    exchangeCharacters(sequence, '3', '1'); // UP and DOWN

    secondSequenceToStore = sequence;

    if (similarElements.find(*secondSequenceToStore) == similarElements.end())
    {
        similarElements.insert(*secondSequenceToStore);
    }
}

void exchangeCharacters(string *sequence, char first, char second)
{
    replace( (*sequence).begin(), (*sequence).end(), second, '+');
    replace( (*sequence).begin(), (*sequence).end(), first, second);
    replace( (*sequence).begin(), (*sequence).end(), '+', first);
}

int getNextRow(int row, int direction)
{
    switch (direction)
    {
        case 0: // Right
            return row;
        case 1: // Down
            return row + 1;
            break;
        case 2: // Left
            return row;
            break;
        case 3: // Up
            return row - 1;
            break;
    }
}

int getNextCol(int col, int direction)
{
    switch (direction)
    {
        case 0: // Right
            return col + 1;
        case 1: // Down
            return col;
            break;
        case 2: // Left
            return col - 1;
            break;
        case 3: // Up
            return col;
            break;
    }
}
