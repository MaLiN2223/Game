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
            return GetTriangle(new ColoredVector2(0, 0, Color.FromArgb(1, 1, 0, 0)),
                new ColoredVector2(0, 1, Color.FromArgb(1, 0, 1, 0)),
                new ColoredVector2(1, 1, Color.FromArgb(1, 0, 0, 1)));
        }
        public static VertexFloatBuffer GetTriangle(ColoredVector2 vector1, ColoredVector2 vector2, ColoredVector2 vector3)
        {
            var triangle = new VertexFloatBuffer(VertexFormat.XYZ_COLOR, 3);
            triangle.AddVertex(vector1);
            triangle.AddVertex(vector2);
            triangle.AddVertex(vector3);
            triangle.IndexFromLength();
            return triangle;
        }
    }
}
