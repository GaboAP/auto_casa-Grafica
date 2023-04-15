using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGrafica
{
    internal class Scene
    {
        List<Object> objects;
        public Scene()
        {
            objects = new List<Object>();
        }
        public void Add(Object objeto)
        {
            this.objects.Add(objeto);
        }
        public void Remove(Object objeto)
        {
            this.objects.Remove(objeto);
        }
        public void Clear() { 
            this.objects = new List<Object>();
        }
        public void Draw()
        {
            if (this.objects.Count!=0)
            {

            }
            foreach (Object objeto in objects)
            {
                objeto.draw();
            }
        }
    }
}
