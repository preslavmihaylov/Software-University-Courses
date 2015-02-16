using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    class Snow : EnvironmentObject
    {
        protected const char SnowCharImage = '.';

        public Snow(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { SnowCharImage } };
        }

        public override void Update()
        {
            return;
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            return;
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
