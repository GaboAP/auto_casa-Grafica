using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using System.Diagnostics.Eventing.Reader;
using Newtonsoft.Json;

namespace ProGrafica
{
    internal class Circle : Face
    {
        [JsonProperty("radius")]
        private Double radius { get; set; }
        [JsonProperty("plano")]
        private string plano { get; set; }
        [JsonProperty("center")]
        private Double[] center { get; set; }

        public Circle() : base()
        {
            this.radius = 0.0;
            this.plano = "";
            this.center = new Double[3];
        }

        public Circle(double radius, string plano, Double[] center, Color color) :
             base(color, PrimitiveType.TriangleFan)
        {
            this.radius = radius;
            this.plano = plano;
            this.center = center;
        }
        
        override
        public void draw(Vector3d centerObject)
        {
            GL.Begin(this.shape);
            GL.Color3(this.color);
            Double cX = centerObject.X;
            Double cY = centerObject.Y;
            Double cZ = centerObject.Z;
            GL.Vertex3(cX + center[0], cY + center[1], cZ + center[2]);
            for (int i = 0; i < 360; i++)
            {
                if (plano.Equals("yz"))
                {
                    GL.Vertex3( cX + center[0], 
                                cY + center[1] + Math.Cos(i) * this.radius,
                                cZ + center[2] + Math.Sin(i) * this.radius);
                }
                else if (plano.Equals("xz"))
                {
                    GL.Vertex3( cX + center[0] + Math.Cos(i) * this.radius,
                                cY + center[1], 
                                cZ + center[2] + Math.Sin(i) * this.radius);
                }
                else if (plano.Equals("xy"))
                {
                    GL.Vertex3( cX + center[0] + Math.Cos(i) * this.radius, 
                                cY + center[1] + Math.Sin(i) * this.radius, 
                                cZ + center[2]);
                }
            }

            GL.End();

        }
    }
}
