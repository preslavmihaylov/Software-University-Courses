using System;
using System.Collections;
using System.Threading.Tasks;

class AsyncTimer
{
    private int ticks;
    private int interval;
    private ModifiedEventArgs args;
    public TimeChangedEventHandler timeChanged;

    public int Ticks 
    {
        get 
        {
            return this.ticks;
        }
        private set 
        {
            if (value < 0)
	        {
		         throw new ArgumentException();
	        }
            this.ticks = value;
        }
    }

    public int Interval
    {
        get 
        {
            return this.interval;
        }
        private set 
        {
            if (value <= 0)
	        {
		         throw new ArgumentException();
	        }
            this.interval = value;
        }
    }

    public AsyncTimer(Action actionToBePerformed, int ticks, int interval)
    {
        this.Ticks = ticks;
        this.Interval = interval;
        this.args = new ModifiedEventArgs(actionToBePerformed);
        this.timeChanged = new TimeChangedEventHandler(ActionPerformed);
    }

    private async void ActionPerformed(object sender, ModifiedEventArgs args)
    {
        if (this.timeChanged != null)
        {
            args.Action();
        }
    }

    public void Start()
    {
        Task task = new Task(asyncTask);
        task.Start();
    }

    private async void asyncTask()
    {
        while (this.Ticks > 0)
        {
            System.Threading.Thread.Sleep(this.Interval);
            this.Ticks--;
            timeChanged(this, this.args);
        }
    }

}
