using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Shaders
{
    public class ShaderFactory
    {
        public static Shader GetShader()
        {
            //setup the shader
            //To use the Shader class you will have to implicitly type
            //the layout location of each attribute
            //else the vbo wont know where they go when binding
            //here i only used 2 attributes since thats all i need for this example
            //but you can always write more to these, or atleast give it a go
            //it can be really fun :D
            string vertex_source =
            @"#version 400
            layout (location = 0) in vec3 vertex_position;
            layout (location = 1) in vec4 vertex_color;

            uniform mat4 mvp_matrix;

            out vec4 color;

            void main(void)
            {
                color = vertex_color;
                //ref line 124
                gl_Position = mvp_matrix * vec4(vertex_position, 1.0);
            }";

            //during the rasterization process each pixel that will be processed (excluding the glclearcolor)
            //to the viewport will go through this pixel shader
            //initially any processed pixel does not have an actual color
            //you can set it from here but since this example uses vertex coloring
            //the color is passed from the [vertex shader] out vec4 color -> [pixelshader] in vec4 color
            //and then output through frag_color
            string fragment_source =
            @"#version 400

            layout (location = 0) out vec4 frag_color;

            in vec4 color;

            void main(void)
            {
	            frag_color = color;
            }";

            return new Shader(ref vertex_source, ref fragment_source);
        }
    }
}
