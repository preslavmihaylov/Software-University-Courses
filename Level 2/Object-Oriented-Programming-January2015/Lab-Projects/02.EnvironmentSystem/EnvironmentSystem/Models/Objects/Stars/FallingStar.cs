using EnvironmentSystem.Models.Objects.Effects;
using System;
using System.Collections.Generic;

namespace EnvironmentSystem.Models.Objects
{
    public class FallingStar : Star
    {
        public FallingStar(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            if (collisionInfo.HitObject is Ground || collisionInfo.HitObject is ExplosionTrail)
            {
                this.Exists = false;
            }
        }

        public override System.Collections.Generic.IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>() 
            { 
                new Trail(this.Bounds.TopLeft.X - this.Direction.X, 
                          this.Bounds.TopLeft.Y - this.Direction.Y, 
                          1, 
                          1) 
            };
        }
    }
}
