namespace MyTunesShop.Models.Performers
{
    public class Singer : Performer
    {
        public Singer(string name)
            : base(name)
        {
        }

        public override PerformerType Type
        {
            get
            {
                return PerformerType.Singer;
            }
        }
    }
}
