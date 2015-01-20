using System;
class Program
{
    static void Main()
    {
        ElementBuilder element = new ElementBuilder("div");
        element.addAttribute("class", "none");
        element.addAttribute("id", "bla");
        element.addAttribute("url", "none");
        element.addContent("Meaningless...");

        Console.WriteLine(4 * element);
        Console.WriteLine();
        Console.WriteLine(HTMLDispatcher.CreateInput("text", "input", "Input text here"));
    }
}
