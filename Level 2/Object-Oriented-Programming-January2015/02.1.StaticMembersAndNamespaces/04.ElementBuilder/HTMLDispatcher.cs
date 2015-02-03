using System;

static class HTMLDispatcher
{
    public static string CreateImage(string source, string alt, string title)
    {
        ElementBuilder element = new ElementBuilder("img");
        element.addAttribute("src", source);
        element.addAttribute("alt", alt);
        element.addAttribute("title", title);

        return element.ToString();
    }

    public static string CreateURL(string url, string title, string text)
    {
        ElementBuilder element = new ElementBuilder("a");
        element.addAttribute("href", url);
        element.addAttribute("title", title);
        element.addContent(text);

        return element.ToString();
    }

    public static string CreateInput(string type, string name, string value)
    {
        ElementBuilder element = new ElementBuilder("input");
        element.addAttribute("type", type);
        element.addAttribute("name", name);
        element.addAttribute("value", value);

        return element.ToString();
    }
}
