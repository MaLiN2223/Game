namespace Shapes
{
    using System.Drawing;
    using OpenTK;

    public struct ColoredVector2
    {

        public Vector2 vector;
        public Color color;
        public ColoredVector2(float x, float y, Color color) : this(new Vector2(x, y), color) { }
        public ColoredVector2(Vector2 vector, Color color)
        {
            this.vector = vector;
            this.color = color;
        }
    }
}
