using System;
class StringAndObjects
{
    static void Main()
    {
        string firstString = "Hello";
        string secondString = "World";
        object myObject = firstString + " " + secondString;
        string thirdString = (string) myObject;

    }
}
