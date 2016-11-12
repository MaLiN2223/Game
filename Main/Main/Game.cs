using System;
using OpenTK;
//this namespace allows us to use only OpenGL 4, with all deprecated items removed.
using OpenTK.Graphics.OpenGL4;

namespace Main
{
    using System.Collections.Generic;
    using System.Drawing;
    using Shapes;
    using Shapes.Shaders;

    internal partial class Game : GameWindow
    {
        private Matrix4 ProjectionMatrix;

        private Shader shader;
        private List<VertexFloatBuffer> buffers;
        private Camera camera;
        public Game(int width = 800, int height = 600)
            : base(width, height,
            OpenTK.Graphics.GraphicsMode.Default,
            "Main window",
            GameWindowFlags.Default,
            DisplayDevice.Default,
            4, 0, OpenTK.Graphics.GraphicsContextFlags.ForwardCompatible)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            #region GL_VERSION
            //this will return your version of opengl
            int major, minor;
            GL.GetInteger(GetPName.MajorVersion, out major);
            GL.GetInteger(GetPName.MinorVersion, out minor);
            Console.WriteLine("Major {0}\nMinor {1}", major, minor);
            //you can also get your GLSL version, although not sure if it varies from the above
            Console.WriteLine("GLSL {0}", GL.GetString(StringName.ShadingLanguageVersion));
            #endregion

            // Background color
            GL.ClearColor(Color.Black);

            //setup projection this tutorial is for 3D ill make another about 2D
            ProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Width / (float)Height, 0.5f, 10000.0f);

            camera = new Camera(new Vector2(0.5f, 0.5f), -2);

            shader = ShaderFactory.GetShader();
            buffers = new List<VertexFloatBuffer>();
            buffers.Add(Triangle.GetTriangle());
            buffers.ForEach(x => x.Load());
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            camera.Update();

            Matrix4 MVP_Matrix = camera.GetView(ProjectionMatrix);

            //send to shader
            GL.UseProgram(shader.Program);
            //will return -1 without use program
            int mvp_matrix_location = GL.GetUniformLocation(shader.Program, "mvp_matrix");
            GL.UniformMatrix4(mvp_matrix_location, false, ref MVP_Matrix);
            GL.UseProgram(0);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Viewport(0, 0, Width, Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            camera.Transform();
            GL.UseProgram(shader.Program);
            buffers.ForEach(x => x.Bind(shader));
            GL.UseProgram(0);

            SwapBuffers();
        }
    }
}
