using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    public class Square : Shape
    {
        private float height;
        private Vector3 color1, color2, color3, color4;
        public Square(float height, Vector3 color)
        {
            this.height = height;
            color1 = color2 = color3 = color4 = color;
        }
        public Square(float height, Vector3 color1, Vector3 color2, Vector3 color3, Vector3 color4)
        {
            this.height = height;
            this.color4 = color4;
            this.color3 = color3;
            this.color2 = color2;
            this.color1 = color1;
        }
        /// <summary>
        /// Draw Square by left down corner
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Draw(float x, float y)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(color1); GL.Vertex3(new Vector3(x, y, 0));
            GL.Color3(color2); GL.Vertex3(new Vector3(x, y + height, 0));
            GL.Color3(color3); GL.Vertex3(new Vector3(x + height, y + height, 0));
            GL.Color3(color4); GL.Vertex3(new Vector3(x + height, y, 0));
            GL.End();
        }
    }
}
