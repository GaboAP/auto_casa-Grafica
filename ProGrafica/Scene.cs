using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProGrafica
{
    internal class Scene
    {
        [JsonProperty("objects")]
        public Dictionary<String, Object> objects{ get; set; }
        public Scene()
        {
            objects = new Dictionary<String, Object>();
        }
        public void Add(String descripción, Object objeto)
        {
            this.objects.Add(descripción, objeto);
            
        }
        public void Remove(String descripcion)
        {
            this.objects.Remove(descripcion);
        }
        public void Clear() { 
            this.objects = new Dictionary<String, Object>();
        }
        public void Draw()
        {
            foreach (var objeto in objects)
            {
                objeto.Value.draw();
            }
        }
    }
}
