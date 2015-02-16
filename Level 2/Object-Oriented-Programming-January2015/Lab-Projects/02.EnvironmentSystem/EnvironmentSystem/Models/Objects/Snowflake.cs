using System.Collections.Generic;
namespace EnvironmentSystem.Models.Objects
{
    public class Snowflake : MovingObject
    {
        protected const char SnowflakeCharImage = '*';

        public Snowflake(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { SnowflakeCharImage } };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            if (collisionInfo.HitObject is Ground || collisionInfo.HitObject is Snow)
            {
                this.Exists = false;
            }
        }

        public override System.Collections.Generic.IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (!this.Exists)
            {
                return new List<Snow>() { new Snow(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y - 1, this.Bounds.Width, this.Bounds.Height) };   
            }
            else
            {
                return new List<EnvironmentObject>();
            }
        }
    }
}
