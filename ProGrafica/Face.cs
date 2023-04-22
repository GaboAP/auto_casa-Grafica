using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using Newtonsoft.Json;

namespace ProGrafica
{
    internal class Face
    {
        [JsonProperty("vertices")]
        protected List<Double[]> vertices { get; set; }
        [JsonProperty("color")]
        protected Color color { get; set; }
        [JsonProperty("shape")]
        protected PrimitiveType shape { get; set; }

        public Face()
        {
            vertices = new List<Double[]>();
            color = Color.Transparent;
            shape = new PrimitiveType();
        }
        public Face(List<Double[]> vertices, Color color, PrimitiveType shape)
        {
            this.vertices = vertices;
            this.color = color;
            this.shape = shape;
        }
        public Face(Color color, PrimitiveType shape)
        {
            vertices = new List<Double[]>();
            this.color = color;
            this.shape = shape;
        }
        public virtual void draw(Vector3d center)
        {
            GL.Begin(this.shape);
            GL.Color3(this.color);
            foreach (Double[] vertex in this.vertices)
            {
                GL.Vertex3(center.X + vertex[0], center.Y + vertex[1], center.Z + vertex[2]);
            }
            GL.End();
        }
        public void addVertex(Double[] vertex)
        {
            vertices.Add(new Double[] { vertex[0], vertex[1], vertex[2] });
        }
    }
}
