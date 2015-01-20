using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ElementBuilder
{
    private Regex regex = new Regex("[a-zA-Z]+");
    private Dictionary<string, string> attributes = new Dictionary<string, string>();
    private string content = "";
    private string element;

    public string Element
    {
        get
        {
            return this.element;
        }
        set
        {
            if (!regex.IsMatch(value) || String.IsNullOrEmpty(value))
            {
                throw new ArgumentException();
            }
            this.element = value;
        }
    }

    public string Content
    {
        get
        {
            return this.content;
        }
        set
        {
            this.content = value;
        }
    }

    public Dictionary<string, string> Attributes
    {
        get
        {
            return this.attributes;
        }
    }

    public ElementBuilder(string element)
    {
        this.Element = element;
    }

    public void addContent(string content)
    {
        this.Content += content;
    }

    public void addAttribute(string attribute, string value)
    {
        this.attributes.Add(attribute, value);
    }

    public static string operator *(ElementBuilder element, int count)
    {
        string output = "";

        for (int index = 0; index < count; index++)
        {
            output += element.ToString();
        }

        return output;
    }

    public static string operator *(int count, ElementBuilder element)
    {
        string output = "";

        for (int index = 0; index < count; index++)
        {
            output += element.ToString();
        }

        return output;
    }

    public override string ToString()
    {
        string output = "<" + this.Element;
        foreach (KeyValuePair<string, string> entry in this.Attributes)
        {
            output += " " + entry.Key + "=\"" + entry.Value + "\"";
        }

        if (this.Element != "input")
        {
            output += ">" + this.Content + "</" + this.Element + ">";
        }
        else
        {
            output += ">";
        }

        return output;
    }
}
