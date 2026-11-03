using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Camera
    {
        public Rectangle Bounds;
        public Vector2 Position;
        public Camera(Point worldSize)
        {
            Position = Vector2.Zero;

            Bounds = new Rectangle(
                0, 0,
                worldSize.X,
                worldSize.Y
            );
        }

        public void MoveTo(Vector2 position)
        {
            Position = position;

            Bounds.X = (int)Position.X;
            Bounds.Y = (int)Position.Y;
        }
    }
}
