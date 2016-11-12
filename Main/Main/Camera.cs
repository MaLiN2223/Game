namespace Main
{
    using System;
    using System.Drawing.Text;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using OpenTK.Input;

    public class Camera
    {
        private const float speed = 0.1f;

        public Vector2 position;
        private float _currentZoom;
        public float currentZoom
        {
            get { return _currentZoom; }
            set
            {
                float f = value;
                if (f > maxZoom)
                    _currentZoom = maxZoom;
                else if (f <= minZoom)
                    _currentZoom = minZoom;
                else
                    _currentZoom = f;
            }
        }
        private const float minZoom = -10;
        private const float maxZoom = -1;
        public Camera(Vector2 position, float currentZoom)
        {
            this.position = position;
            this.currentZoom = currentZoom;
        }

        public void Update()
        {
            var keyboard = Keyboard.GetState();
            if (keyboard.IsAnyKeyDown)
            {
                if (keyboard[Key.Up])
                    position.Y += speed;
                if (keyboard[Key.Down])
                    position.Y -= speed;
                if (keyboard[Key.Right])
                    position.X += speed;
                if (keyboard[Key.Left])
                    position.X -= speed;
            }

        }
        public void Zoom(float f)
        {
            f /= 10;
            currentZoom += f;
            Console.WriteLine(currentZoom);
        } 

        public void Transform()
        {
            Matrix4 matrix = Matrix4.Identity;
            matrix = Matrix4.Mult(matrix, Matrix4.CreateTranslation(position.X, position.Y, 0));
            matrix = Matrix4.Mult(matrix, Matrix4.CreateScale(currentZoom, currentZoom, 1f));
            GL.MultMatrix(ref matrix);
        }

        public Matrix4 GetModelviewMatrix()
        {
            return Matrix4.CreateTranslation(0, 0, currentZoom);
        }

        public Matrix4 GetView(Matrix4 ProjectionMatrix)
        {

            //set the world matrix
            var WorldMatrix = Matrix4.CreateTranslation(new Vector3(-position));

            //set out triangle position with the modelview matrix
            var ModelviewMatrix = GetModelviewMatrix();

            //combine all matrices
            //the different between GL and GLSL with matrix order
            //GL   modelview * worldview * projection;
            //GLSL projection * worldview * modelview;
            return ModelviewMatrix * WorldMatrix * ProjectionMatrix;

        }
    }
}
