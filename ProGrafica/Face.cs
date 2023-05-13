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
        protected Dictionary<String, Vector3d> vertices { get; set; } //List of vertix that make the face
        [JsonProperty("color")]
        protected Color color { get; set; } //Color of this face 
        [JsonProperty("shape")]
        protected PrimitiveType shape { get; set; } //Shape of the face, facilitates drawing function

        public Face() //Empty constructor, initializes properties
        {
            vertices = new Dictionary<string, Vector3d>();
            color = Color.Transparent;
            shape = new PrimitiveType();
        }
        public Face(Dictionary<string, Vector3d> vertices, Color color, PrimitiveType shape) //All-parameters Constructor
        {
            this.vertices = vertices;
            this.color = color;
            this.shape = shape;
        }
        public Face(Color color, PrimitiveType shape) //Only color and shape constructor, most commonly used one
        {
            vertices = new Dictionary<string, Vector3d>();
            this.color = color;
            this.shape = shape;
        }
        public virtual void draw(Vector3d center) //Draws the face with the object's center as a parameter to take into account, in case user wants to move the object
        {
            GL.Begin(this.shape);
            GL.Color3(this.color);
            foreach (var vertex in this.vertices)
            {
                GL.Vertex3(center.X + vertex.Value.X, center.Y + vertex.Value.Y, center.Z + vertex.Value.Z);
            }
            GL.End();
        }
        public virtual void draw() //Draws the face with the object's center as a parameter to take into account, in case user wants to move the object
        {
            GL.Begin(this.shape);
            GL.Color3(this.color);
            foreach (var vertex in this.vertices)
            {
                GL.Vertex3(vertex.Value.X, vertex.Value.Y, vertex.Value.Z);
            }
            GL.End();
        }
        public void addVertex(String descripcion, Vector3d vertex) //Adds a vertex to the list of vertix
        {
            this.vertices.Add(descripcion, vertex);
        }
        public Vector3d formulaRodriguez(Vector3d k, Vector3d v, Double theta)
        {
            //(k x v) sin0
            Vector3d kxv = Vector3d.Multiply(Vector3d.Cross(k, v), Math.Sin(theta));
            //vcos0+(k x v)sin 0
            Vector3d pt1 = Vector3d.Add(Vector3d.Multiply(v, Math.Cos(theta)), kxv);
            //k(k.v)
            Vector3d kkdotv = Vector3d.Multiply(k, Vector3d.Dot(k, v));
            //k(k.v)(1-cos0)
            Vector3d pt2=Vector3d.Multiply(kkdotv,(1.0-Math.Cos(theta)));
            v = Vector3d.Add(pt1, pt2);
            return v;
        }
        public virtual void rotate(Vector3d eje, Double theta)
        {
            foreach (var vector in vertices.ToList())
            {
                String key=vector.Key;
                Vector3d vi = new Vector3d(vector.Value.X, vector.Value.Y, vector.Value.Z);
                vi=formulaRodriguez(eje,vi,theta);
                vertices[key]=vi;
            }
        }

        public virtual void Move(Vector3d eje) //Trasladar sin necesidad del centro
        {
            foreach(var vector in vertices.ToList())
            {
                vertices[vector.Key] = vector.Value + eje;
            }
        }
 

        public void Scale(double times)
        {
            foreach (var vector in vertices.ToList())
            {
                vertices[vector.Key] = vector.Value * times;
            }
        }
    }
}
