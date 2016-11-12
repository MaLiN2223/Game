using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    using System.Drawing;
    using OpenTK;

    public class Triangle
    {
        public static VertexFloatBuffer GetTriangle()
        {
            var triangle = new VertexFloatBuffer(VertexFormat.XYZ_COLOR, 3);
            triangle.AddVertex(0.0f, 0.0f, Color.FromArgb(1, 1, 0, 0));
            triangle.AddVertex(new Vector2(0, 1), Color.FromArgb(1, 0, 1, 0));
            triangle.AddVertex(1.0f, 1, Color.FromArgb(1, 0, 0, 1));
            triangle.IndexFromLength();
            return triangle;

        }
    }
}
