using EnvironmentSystem.Models.Objects.Effects;
using System;
using System.Collections.Generic;

namespace EnvironmentSystem.Models.Objects
{
    public class UnstableStar : FallingStar
    {
        private int passedFrames = 0;

        public UnstableStar(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
        }

        public override void Update()
        {
            base.Update();

            if (this.passedFrames >= 8)
            {
                this.Exists = false;
            }

            this.passedFrames++;
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (!this.Exists && this.Bounds.TopLeft.Y < 23)
            {
                return new List<EnvironmentObject>() 
                { 
                    new ExplosionTrail(this.Bounds.TopLeft.X - 2, this.Bounds.TopLeft.Y - 1, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X - 1, this.Bounds.TopLeft.Y - 1, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y - 1, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X + 1, this.Bounds.TopLeft.Y - 1, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X + 2, this.Bounds.TopLeft.Y - 1, 1, 1),

                    new ExplosionTrail(this.Bounds.TopLeft.X - 2, this.Bounds.TopLeft.Y - 2, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X - 1, this.Bounds.TopLeft.Y - 2, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y - 2, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X + 1, this.Bounds.TopLeft.Y - 2, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X + 2, this.Bounds.TopLeft.Y - 2, 1, 1),

                    new ExplosionTrail(this.Bounds.TopLeft.X - 2, this.Bounds.TopLeft.Y, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X - 1, this.Bounds.TopLeft.Y, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X + 1, this.Bounds.TopLeft.Y, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X + 2, this.Bounds.TopLeft.Y, 1, 1),

                    new ExplosionTrail(this.Bounds.TopLeft.X - 1, this.Bounds.TopLeft.Y + 1, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y + 1, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X + 1, this.Bounds.TopLeft.Y + 1, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X - 2, this.Bounds.TopLeft.Y + 1, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X + 2, this.Bounds.TopLeft.Y + 1, 1, 1),

                    new ExplosionTrail(this.Bounds.TopLeft.X - 1, this.Bounds.TopLeft.Y + 2, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y + 2, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X + 1, this.Bounds.TopLeft.Y + 2, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X - 2, this.Bounds.TopLeft.Y + 2, 1, 1),
                    new ExplosionTrail(this.Bounds.TopLeft.X + 2, this.Bounds.TopLeft.Y + 2, 1, 1)
                };
            }

            return base.ProduceObjects();
        }
    }
}
