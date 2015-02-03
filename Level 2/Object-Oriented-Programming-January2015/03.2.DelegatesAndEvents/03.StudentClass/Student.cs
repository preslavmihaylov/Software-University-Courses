using System;

class Student
{
    private string name;
    private int age;
    private ModifiedEventArgs args;
    public PropertyChangedEventHandler onChange;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.args.NewName = value;
            this.args.PropertyChanged = "Name";
            this.name = value;
            onChange(this, this.args);
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.args.NewAge = value;
            this.args.PropertyChanged = "Age";
            this.age = value;
            onChange(this, this.args);
        }
    }

    public Student(string name, int age)
    {
        this.args = new ModifiedEventArgs();
        this.onChange += new PropertyChangedEventHandler(ActionPerformed);
        this.Name = name;
        this.Age = age;
    }

    private void ActionPerformed(object sender, ModifiedEventArgs args)
    {
        args.ShowChanges();
    }
}
