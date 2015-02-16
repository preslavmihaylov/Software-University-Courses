using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    public class Trail : EnvironmentObject
    {
        protected const char SnowflakeCharImage = '.';
        private int trailFrameCount = 0;

        public Trail(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.ImageProfile = new char[,] { { SnowflakeCharImage } };
        }

        public override void Update()
        {
            if (this.trailFrameCount < 2)
            {
                this.trailFrameCount++;
            }
            else
            {
                this.Exists = false;
            }
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
