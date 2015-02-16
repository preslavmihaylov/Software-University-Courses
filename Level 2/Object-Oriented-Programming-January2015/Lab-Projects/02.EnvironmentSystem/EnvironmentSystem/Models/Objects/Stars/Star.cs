using EnvironmentSystem.Models.Objects.Effects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EnvironmentSystem.Models.Objects
{
    public class Star : MovingObject
    {
        protected readonly char[] StarCharImages = new char[] { '@', '0', 'O' };
        private static Random randGenerator = new Random();
        private int starFrame = 0;

        public Star(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        protected char[,] GenerateImageProfile()
        {
            return new char[,] { { StarCharImages[randGenerator.Next(3)] } };
        }

        public override void Update()
        {
            base.Update();

            if (this.starFrame >= 10)
            {
                this.ImageProfile = this.GenerateImageProfile();
                this.starFrame = 0;
            }
            else
            {
                this.starFrame++;
            }

            
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            if (collisionInfo.HitObject is ExplosionTrail)
            {
                this.Exists = false;
            }
        }

        public override System.Collections.Generic.IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
