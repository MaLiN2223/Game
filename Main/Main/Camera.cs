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
        public float zoom;
        public Camera(Vector2 position, float zoom)
        {
            this.position = position;
            this.zoom = zoom;
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
                if (keyboard[Key.KeypadPlus] || keyboard[Key.Plus])
                    MoveUp();
                if (keyboard[Key.KeypadMinus] || keyboard[Key.Minus])
                    MoveDown();
            }

        }

        private void MoveDown()
        {

            zoom -= speed;
        }

        private void MoveUp()
        {
            zoom += speed;
        }

        public void Transform()
        {
            Matrix4 matrix = Matrix4.Identity;
            matrix = Matrix4.Mult(matrix, Matrix4.CreateTranslation(position.X, position.Y, 0));
            matrix = Matrix4.Mult(matrix, Matrix4.CreateScale(zoom, zoom, 1f));
            GL.MultMatrix(ref matrix);
        }

        public Matrix4 GetModelviewMatrix()
        {
            return Matrix4.CreateTranslation(0, 0, zoom);
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
