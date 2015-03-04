namespace MyTunesShop.Models.Performers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class Band : Performer, IBand
    {
        private IList<string> members = new List<string>();

        public Band(string name)
            : base(name)
        {
        }

        public IList<string> Members
        {
            get
            {
                return this.members;
            }
        }

        public void AddMember(string memberName)
        {
            this.members.Add(memberName);
        }

        public override PerformerType Type
        {
            get
            {
                return PerformerType.Band;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(this.Name + ": ");
            if (this.Members.Any())
            {
                output.Append(string.Join(", ", this.Members));
            }

            output.AppendLine();
            if (this.Songs.Any())
            {
                var sortedSongs = this.Songs.OrderBy(s => s.Title).Select(s => s.Title);

                output.Append(string.Join("; ", sortedSongs));
            }
            else
            {
                output.Append("no songs");
            }

            return output.ToString();
        }
    }
}
