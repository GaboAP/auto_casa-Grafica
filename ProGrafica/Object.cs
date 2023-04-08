using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ProGrafica
{
    internal class Object
    {
        private List<Face> faces;
        private Vector3d center;
        private Double width; //x
        private Double height;  //y
        private Double length; //z

        public Object(Double centroX, Double centroY, Double centroZ)
        {
            this.faces = new List<Face>();
            this.center = new Vector3d(centroX, centroY, centroZ);
            this.height = 100;
            this.length = 100;
            this.width = 100;
        }
        public Object(List<Face> faces, Vector3d center, Double width, Double height, Double length) 
        {
            this.faces = faces;
            this.center = center;
            this.width = width;
            this.height = height;
            this.length = length;
        }
        public Face[] Faces
        {
            get{ return Faces.ToArray(); }

            set { faces = new List<Face>(value); }
        }
        public Double CenterX 
        { 
            get { return this.center.X; } 

            set { this.center.X = value; } 
        }
        public Double CenterY
        {
            get { return this.center.Y; } 
            
            set { this.center.Y = value;}
        }
        public Double CenterZ
        {
            get { return this.center.Z; }

            set { this.center.Z = value;}
        }
        public void addFace(Face face)
        {
            this.faces.Add(face);
        }
        public void draw()
        {
            if (this.faces.Count != 0)
            {
                foreach (Face face in this.faces)
                {
                    face.Draw(center);
                }
            } 
        }
    }
}
