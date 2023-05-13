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
        private Vector3d center { get; set; }

        public Circle() : base()
        {
            this.radius = 0.0;
            this.plano = "";
            this.center = new Vector3d();
        }

        [JsonConstructor]
        public Circle(String descripcion, double radius, string plano, Vector3d center, Color color) :
             base(color, PrimitiveType.TriangleFan)
        {
            this.radius = radius;
            this.plano = plano;
            this.center = center;
            for (int i = 0; i < 360; i++)
            {
                descripcion += i;
                if (plano.Equals("yz"))
                {
                    this.vertices.Add(descripcion, new Vector3d(center.X,
                                                    center.Y + Math.Cos(i) * this.radius,
                                                    center.Z + Math.Sin(i) * this.radius));
                }
                else if (plano.Equals("xz"))
                {
                    this.vertices.Add(descripcion,new Vector3d ( center.X + Math.Cos(i) * this.radius,
                                                     center.Y,
                                                     center.Z + Math.Sin(i) * this.radius ));
                }
                else if (plano.Equals("xy"))
                {
                    this.vertices.Add(descripcion,new Vector3d( center[0] + Math.Cos(i) * this.radius,
                                                    center[1] + Math.Sin(i) * this.radius,
                                                    center[2] ));
                }
            }
        }
        
        override
        public void draw(Vector3d centerObject)
        {
            GL.Begin(this.shape);
            GL.Color3(this.color);
            Double cX = centerObject.X;
            Double cY = centerObject.Y;
            Double cZ = centerObject.Z;
            //GL.Vertex3(cX + center[0], cY + center[1], cZ + center[2]);
            foreach (var punto in vertices)
            {
                GL.Vertex3(cX + punto.Value.X,
                                cY + punto.Value.Y,
                                cZ + punto.Value.Z);
                /*if (plano.Equals("yz"))
                {
                    
                }
                else if (plano.Equals("xz"))
                {
                    GL.Vertex3(cX + punto[0],
                                cY + punto[1],
                                cZ + punto[2]);
                }
                else if (plano.Equals("xy"))
                {
                    GL.Vertex3( cX + punto[0], 
                                cY + punto[1], 
                                cZ + punto[2]);
                }*/
            }
            GL.End();

        }

        override
        public void rotate(Vector3d eje, Double theta){
            foreach (var vector in vertices.ToList())
            {
                String key = vector.Key;
                Vector3d vi = new Vector3d(vector.Value.X, vector.Value.Y, vector.Value.Z);
                vi = formulaRodriguez(eje, vi, theta);
                this.vertices[key] = vi;
            }
        }
    }
}
