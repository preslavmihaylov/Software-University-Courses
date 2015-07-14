class Item
{
    public int Value { get; set; }

    public Item PreviousItem { get; set; }

    public Item(int value)
    {
        this.Value = value;
    }

    public Item(int value, Item previousItem)
    {
        this.Value = value;
        this.PreviousItem = previousItem;
    }
}