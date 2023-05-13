using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Newtonsoft.Json;

namespace ProGrafica
{
    internal class Object
    {
        [JsonProperty("faces")]
        private Dictionary<String, Face> faces { get; set; } //Faces that conform the object
        private Vector3d center;  //Center of mass of said object
        [JsonProperty("width")]
        private Double width { get; set; }//x 
        [JsonProperty("height")]
        private Double height { get; set; }  //y
        [JsonProperty("length")]
        private Double length { get; set; }//z

        public Object()
        {
            this.faces = new Dictionary<String, Face>();
            this.center = new Vector3d();
            this.height = 100;
            this.length = 100;
            this.width = 100;
        } //Empty constructor, intializes properties
        public Object(Double centroX, Double centroY, Double centroZ)
        {
            this.faces = new Dictionary<String, Face>();
            this.center = new Vector3d(centroX, centroY, centroZ);
            this.height = 100;
            this.length = 100;
            this.width = 100;
        } //Constructor with only it's center as parameter
        public Object(Dictionary<String, Face> faces, Vector3d center, Double width, Double height, Double length) 
        {
            this.faces = faces;
            this.center = center;
            this.width = width;
            this.height = height;
            this.length = length;
        } //Constructor with all parameters
        public Object(Object Objeto) //Constructor Clonar
        {
            this.faces= Objeto.faces;
            this.center = Objeto.center;
            this.height = Objeto.height;
            this.length = Objeto.length;
            this.width = Objeto.width;
        }

        [JsonProperty("CenterX")]
        public Double CenterX //Getter/Setter of the the center in X axis
        { 
            get { return this.center.X; } //Retorna el valor de X del centro

            set { this.center.X = value; } //Setea el valor de X del centro
        } 

        [JsonProperty("CenterY")]
        public Double CenterY //Getter/Setter of the the center in Y axis
        {
            get { return this.center.Y; } //Retorna el valor de Y del centro
            
            set { this.center.Y = value;} //Setea el valor de Y del centro
        }

        [JsonProperty("CenterZ")]
        public Double CenterZ //Getter/Setter of the the center in Z axis
        {
            get { return this.center.Z; } //Retorna el valor de Z del centro

            set { this.center.Z = value;} //Setea el valor de Z del centro
        }
        public void addFace(String descripcion, Face face) //Adds a face to the object's list
        {
            this.faces.Add(descripcion, face); //añadir cara a la lista de caras "faces"
        }
            public void draw()  //Draws the object
            {
                if (this.faces.Count != 0) //Verifica si la lista caras NO está vacía
                {
                    foreach (var cara in this.faces) //para cada cara en la lista de caras "faces"
                    {
                        cara.Value.draw(center);  //Dibujarla
                    }
                } 
            }
        public void rotate(Vector3d eje,Double theta)
        {
            foreach (var cara in faces)
            {
                cara.Value.rotate(eje, theta);
            }
        }
        public void Move(Vector3d eje)
        {
            center = center + eje;
        }
        public void Scale(Double scale)
        {
            foreach (var item in faces)
            {
                item.Value.Scale(scale);
            }
        }
    }
}
