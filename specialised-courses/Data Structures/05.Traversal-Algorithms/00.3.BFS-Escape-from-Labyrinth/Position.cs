class Position
{
    public Position(int row, int col, char direction, Position previousPosition)
    {
        this.Row = row;
        this.Col = col;
        this.Direction = direction;
        this.PreviousPosition = previousPosition;
    }

    public int Row
    {
        get;
        set;
    }

    public int Col
    {
        get;
        set;
    }

    public char Direction
    {
        get;
        set;
    }

    public Position PreviousPosition
    {
        get;
        set;
    }
}