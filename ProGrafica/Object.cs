using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Newtonsoft.Json;

namespace ProGrafica
{
    internal class Object
    {
        [JsonProperty("faces")]
        private Dictionary<String, Face> faces { get; set; } 
        private Vector3d center;
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
        }
        public Object(Double centroX, Double centroY, Double centroZ)
        {
            this.faces = new Dictionary<String, Face>();
            this.center = new Vector3d(centroX, centroY, centroZ);
            this.height = 100;
            this.length = 100;
            this.width = 100;
        }
        public Object(Dictionary<String, Face> faces, Vector3d center, Double width, Double height, Double length) 
        {
            this.faces = faces;
            this.center = center;
            this.width = width;
            this.height = height;
            this.length = length;
        }
        public Object(Object Objeto) //Constructor Clonar
        {
            this.faces= Objeto.faces;
            this.center = Objeto.center;
            this.height = Objeto.height;
            this.length = Objeto.length;
            this.width = Objeto.width;
        }

        [JsonProperty("CenterX")]
        public Double CenterX 
        { 
            get { return this.center.X; } //Retorna el valor de X del centro

            set { this.center.X = value; } //Setea el valor de X del centro
        }

        [JsonProperty("CenterY")]
        public Double CenterY
        {
            get { return this.center.Y; } //Retorna el valor de Y del centro
            
            set { this.center.Y = value;} //Setea el valor de Y del centro
        }

        [JsonProperty("CenterZ")]
        public Double CenterZ
        {
            get { return this.center.Z; } //Retorna el valor de Z del centro

            set { this.center.Z = value;} //Setea el valor de Z del centro
        }
        public void addFace(String descripcion, Face face)
        {
            this.faces.Add(descripcion, face); //añadir cara a la lista de caras "faces"
        }
        public void draw()
        {
            if (this.faces.Count != 0) //Verifica si la lista caras NO está vacía
            {
                foreach (var cara in this.faces) //para cada cara en la lista de caras "faces"
                {
                    cara.Value.draw(center);  //Dibujarla
                }
            } 
        }
    }
}
