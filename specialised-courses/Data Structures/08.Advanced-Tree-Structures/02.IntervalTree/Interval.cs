namespace _02.IntervalTree
{
    using System;

    class Interval
    {
        public Interval(int start, bool startIncluding, int end, bool endIncluding)
        {
            this.Start = start;
            this.End = end;
            this.StartIncluding = startIncluding;
            this.EndIncluding = endIncluding;
        }

        public int Start { get; private set; }

        public int End { get; private set; }

        public bool StartIncluding { get; private set; }

        public bool EndIncluding { get; private set; }

        public override string ToString()
        {
            return string.Format("{2}{0}..{1}{3}", 
                this.Start, 
                this.End,
                this.StartIncluding ? "[" : ")",
                this.EndIncluding ? "]" : ")");
        }
    }
}