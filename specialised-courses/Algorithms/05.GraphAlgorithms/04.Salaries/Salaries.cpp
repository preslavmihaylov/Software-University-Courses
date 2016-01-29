#include <iostream>

#define MAX_DATA 50

using namespace std;

typedef long long U64;

typedef struct
{
    int subordinates[MAX_DATA];
    int subordinatesCount;
    U64 salary;
    bool isManager = true;
} Employee;

/* FUNCTION PROTOTYPES */
void CalculateEmployeeSalaries();
U64 CalculateSalary(int employeeIndex);
U64 CalculateTotalSalaries();
bool ContainsSubordinate(Employee employee, int subordinateIndex);
void ProcessInput();
void PrintResult(U64 totalSalaries);

static Employee employees[MAX_DATA];

static int employeesCount;

int main()
{
    ProcessInput();
    CalculateEmployeeSalaries();
    U64 totalSalaries = CalculateTotalSalaries();
    PrintResult(totalSalaries);

    return 0;
}

void CalculateEmployeeSalaries()
{
    for (int index = 0; index < employeesCount; index++)
    {
        if (employees[index].isManager)
        {
            CalculateSalary(index);
        }
    }
}

U64 CalculateTotalSalaries()
{
    U64 totalSalaries = 0;

    for (int index = 0; index < employeesCount; index++)
    {
        totalSalaries += employees[index].salary;
    }

    return totalSalaries;
}

U64 CalculateSalary(int employeeIndex)
{
    Employee* employee = &employees[employeeIndex];

    if ( (*employee).salary != 0)
    {
        return (*employee).salary;
    }

    for (int index = 0; index < (*employee).subordinatesCount; index++)
    {
        int subordinateIndex = (*employee).subordinates[index];
        (*employee).salary += CalculateSalary(subordinateIndex);
    }

    if (!(*employee).salary)
    {
        (*employee).salary = 1;
    }

    return (*employee).salary;
}

void ProcessInput()
{
    cin >> employeesCount;

    for (int index = 0; index < employeesCount; index++)
    {
        char line[MAX_DATA];

        cin >> line;

        for (int ch = 0; line[ch] != '\0'; ch++)
        {
            if (line[ch] == 'Y')
            {
                int subordinatesCount = employees[index].subordinatesCount;
                employees[index].subordinates[subordinatesCount] = ch;
                employees[index].subordinatesCount++;

                employees[ch].isManager = false;
            }
        }
    }
}

void PrintResult(U64 totalSalaries)
{
    cout << totalSalaries << endl;
}
