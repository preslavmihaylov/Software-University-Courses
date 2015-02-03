using System;

class InterestCalculator
{
    private string result;
    private int sum;
    private double interest;
    private int years;
    private Func<int, double, int, string> calculateInterestDelegate;
        
    public string Result {
        get
        {
            return this.result;
        }
        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.result = value;
        }
    }

    public int Sum
    {
        get
        {
            return this.sum;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.sum = value;
            calculateResult();
        }
    }

    public double Interest
    {
        get
        {
            return this.interest;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.interest = value;
            calculateResult();
        }
    }

    public int Years
    {
        get
        {
            return this.years;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.years = value;
            calculateResult();
        }
    }

    public Func<int, double, int, string> CalculateInterestDelegate
    {
        get 
        {
            return this.calculateInterestDelegate;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException();
            }

            this.calculateInterestDelegate = value;
            calculateResult();
        }
    }

    public InterestCalculator(int sum, double interest, int years, Func<int, double, int, string> calculateInterestDelegate)
    {
        this.Sum = sum;
        this.Interest = interest;
        this.Years = years;
        this.CalculateInterestDelegate = calculateInterestDelegate;

        this.Result = this.CalculateInterestDelegate(this.Sum, this.Interest, this.Years);
    }

    private void calculateResult()
    {
        if (this.Result == null)
	    {
            return;
	    }

        this.Result = this.CalculateInterestDelegate(this.Sum, this.Interest, this.Years);
    }
}
