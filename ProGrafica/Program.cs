﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;


namespace ProGrafica
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game nw = new Game(800, 600, "prueba"))
            {
                nw.Run(60.0);
            }
        }
    }
}
