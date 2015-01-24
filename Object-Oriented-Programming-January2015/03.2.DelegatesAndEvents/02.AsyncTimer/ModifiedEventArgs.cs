using System;

public class ModifiedEventArgs : EventArgs
{
    private int ticksLeft;
    private Action action;

    public Action Action
    {
        get
        {
            return this.action;
        }
        private set
        {
            this.action = value;
        }
    }

    public ModifiedEventArgs(Action action)
    {
        this.Action = action;
    }
}
