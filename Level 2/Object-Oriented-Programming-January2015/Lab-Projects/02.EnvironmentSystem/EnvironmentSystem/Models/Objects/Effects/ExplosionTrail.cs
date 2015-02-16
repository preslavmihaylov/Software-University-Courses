using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects.Effects
{
    public class ExplosionTrail : Trail
    {
        public ExplosionTrail(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
        }

        // public override void RespondToCollision(CollisionInfo collisionInfo)
        // {
        //     if (collisionInfo.HitObject is Ground)
        //     {
        //         this.Exists = false;
        //     }
        // }
    }
}
