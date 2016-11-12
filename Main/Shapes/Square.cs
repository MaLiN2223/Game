using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    using System.Drawing;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    public class Square : Quad
    {
        private float height;

        public Square(float height, Color color)
        {
            this.height = height;
            base.color = color;
        }
        /// <summary>
        /// Draw Square by left down corner
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Draw(float x, float y)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(color); GL.Vertex2(new Vector2(x, y));
            GL.Vertex2(new Vector2(x, y + height));
            GL.Vertex2(new Vector2(x + height, y + height));
            GL.Vertex2(new Vector2(x + height, y));
            GL.End();
        }

        protected override Vector2[] Vertices => new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,0),
            new Vector2(1,1),
        };
    }
}
