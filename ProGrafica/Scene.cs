using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenTK;

namespace ProGrafica
{
    internal class Scene
    {
        [JsonProperty("objects")]
        public Dictionary<String, Object> objects{ get; set; } //List of objects
        public Scene()
        {
            objects = new Dictionary<String, Object>();
        }   //Empty constructor, intializes list
        public void Add(String descripción, Object objeto)
        {
            this.objects.Add(descripción, objeto);
            
        } //Adds an object 
        public void Remove(String descripcion)
        {
            this.objects.Remove(descripcion);
        } //Removes an object
        public Object Get(String descripcion)
        {
            return this.objects[descripcion];
        } //Gets an object based on its key
        public void Clear() { 
            this.objects = new Dictionary<String, Object>();
        } //Clears the list of objects 
        public void Draw() //Draws the scenario, all of its objects
        {
            foreach (var objeto in objects)
            {
                objeto.Value.draw();
            }
        }
        public void rotate(Vector3d eje, Double theta)
        {
            foreach (var item in objects)
            {
                item.Value.rotate(eje, theta);
            }
        }
        public void Move(Vector3d eje)
        {
            foreach (var item in objects)
            {
                item.Value.Move(eje);
            }
        }
        public void Scale(Double scale)
        {
            foreach (var item in objects)
            {
                item.Value.Scale(scale);
            }
        }
    }
}
