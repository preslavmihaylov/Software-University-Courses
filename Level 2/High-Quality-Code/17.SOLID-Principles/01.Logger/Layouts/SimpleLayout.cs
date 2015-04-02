namespace _01.Logger.Layouts
{
    using Interfaces;

    class SimpleLayout : ILayout
    {
        public string Format
        {
            get
            {
                return "{0} - {1} - {2}";
            }
        }
    }
}
