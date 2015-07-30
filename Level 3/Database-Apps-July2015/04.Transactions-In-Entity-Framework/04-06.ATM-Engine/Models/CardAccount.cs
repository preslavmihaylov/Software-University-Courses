using System.ComponentModel.DataAnnotations;

class CardAccount
{
    public int CardAccountId
    {
        get;
        set;
    }

    [StringLength(10)]
    public string CardNumber
    {
        get;
        set;
    }

    [StringLength(4)]
    public string CardPIN
    {
        get;
        set;
    }

    [ConcurrencyCheck]
    public decimal CardCash
    {
        get;
        set;
    }
}