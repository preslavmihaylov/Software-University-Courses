using System;

public class ModifiedEventArgs : EventArgs
{
    private string oldName;
    private string newName;
    private int oldAge;
    private int newAge;
    private string propertyChanged;

    public string OldName 
    {
        get
        {
            return this.oldName;
        }
        private set
        {
            this.oldName = value;
        }
    }

    public string NewName
    {
        get
        {
            return this.newName;
        }
        set
        {
            this.OldName = this.NewName;
            this.newName = value;
        }
    }

    public int OldAge
    {
        get
        {
            return this.oldAge;
        }
        private set
        {
            this.oldAge = value;
        }
    }

    public int NewAge
    {
        get
        {
            return this.newAge;
        }
        set
        {
            this.OldAge = this.NewAge;
            this.newAge = value;
        }
    }

    public string PropertyChanged
    {
        get
        {
            return this.propertyChanged;
        }
        set
        {
            this.propertyChanged = value;
        }
    }

    public ModifiedEventArgs()
    {
    }

    public void ShowChanges()
    {
        if (this.PropertyChanged == "Name")
        {
            if (this.OldName != null)
            {
                Console.WriteLine("Property changed: {0} (From {1} to {2})", this.propertyChanged, this.oldName, this.newName);
            }
        }
        else
        {
            if (this.OldAge != 0)
            {
                Console.WriteLine("Property changed: {0} (From {1} to {2})", this.propertyChanged, this.oldAge, this.newAge);
            }
        }
    }
}
