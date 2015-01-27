using System;
interface IProject
{
    string Name { get; }
    DateTime StartDate { get; }
    string Details { get; set; }
    string State { get; }
    void CloseProject();
}
