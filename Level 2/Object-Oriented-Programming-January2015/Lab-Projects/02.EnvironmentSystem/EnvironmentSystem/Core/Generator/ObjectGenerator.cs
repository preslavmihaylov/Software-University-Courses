namespace EnvironmentSystem.Core.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EnvironmentSystem.Models;
    using EnvironmentSystem.Models.Objects;
    

    public class ObjectGenerator
    {
        private const int SnowflakeCount = 10;
        private Random rnd = new Random();

        private readonly int WorldWidth;
        private readonly int WorldHeight;

        public ObjectGenerator(int worldWidth, int worldHeight)
        {
            this.WorldWidth = worldWidth;
            this.WorldHeight = worldHeight;
        }

        /// <summary>
        /// Adds objects only once to the passed collection.
        /// </summary>
        /// <param name="objects"></param>
        public void Initiliaze(List<EnvironmentObject> objects)
        {
            objects.Add(new Ground(0, 25, 50, 2));

            for (int i = 0; i < 10; i++)
            {
                int x = rnd.Next(0, WorldWidth);
                int y = rnd.Next(0, WorldHeight - 10);
                var envObject = new Star(x, y, 1, 1, new Point(0, 0));
                var overlappingStar = objects.Select(o => o).Where(o => o.Bounds.TopLeft.X == x && o.Bounds.TopLeft.Y == y);
                if (overlappingStar.Count() == 0)
                {
                    objects.Add(envObject);
                }
                else
                {
                    i--;
                }
            }
        }

        /// <summary>
        /// Dynamically adds objects to the passed collection.
        /// </summary>
        /// <param name="objects"></param>
        public void DynamicallyAdd(List<EnvironmentObject> objects)
        {
            // for (int i = 0; i < SnowflakeCount; i++)
            // {
            //     int generateFlag = rnd.Next(0, 5);
            // 
            //     if (generateFlag == 1)
            //     {
            //         int x = rnd.Next(0, WorldWidth);
            //         var envObject = new Snowflake(x, 1, 1, 1, new Point(0, 1));
            // 
            //         objects.Add(envObject);
            //     }
            // }

            for (int i = 0; i < SnowflakeCount; i++)
            {
                int generateFlag = rnd.Next(0, 30);
            
                if (generateFlag == 1)
                {
                    int x = rnd.Next(0, WorldWidth);
                    int y = rnd.Next(0, WorldHeight - 10);
                    var envObject = new UnstableStar(x, y, 1, 1, new Point(rnd.Next(2) - 1, 1));
            
                    objects.Add(envObject);
                }
            }

            for (int i = 0; i < SnowflakeCount; i++)
            {
                int generateFlag = rnd.Next(0, 30);

                if (generateFlag == 1)
                {
                    int x = rnd.Next(0, WorldWidth);
                    int y = rnd.Next(0, WorldHeight - 10);
                    var envObject = new FallingStar(x, y, 1, 1, new Point(rnd.Next(2) - 1, 1));

                    objects.Add(envObject);
                }
            }
        }
    }
}
