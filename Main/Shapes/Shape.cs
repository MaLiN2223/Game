using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    using System.Drawing;
    using OpenTK;

    public abstract class Shape
    {
        public Vector2 position, scale, origin;
        public Color color;
        protected abstract Vector2[] Vertices
        {
            get;
        }
    }
}
