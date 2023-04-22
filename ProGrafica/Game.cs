using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;

namespace ProGrafica
{
    class Game:GameWindow
    {
        private Double theta=0;
        public Game(int widht, int height, string title):base(widht, height, GraphicsMode.Default, title)
        {
        }
        
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
         
            base.OnLoad(e);
            //Code goes here
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {

            base.OnUpdateFrame(e);
        }
        public void thetaInc()
        {
            if (theta == 360)
            {
                theta = 0;
            }
            else
            {
                theta++;
            }
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Rotate(10.0, 1.0, 0.0, 0.0);
            GL.Rotate(theta, 0.0, 1.0, 0.0);
            thetaInc();

            //-----------------------------CASA-------------------------------
            Object casa = JSON.Load<Object>("C:\\Users\\gabri\\Desktop\\ProGrafica\\ProGrafica\\Json\\casa.json");
            //-----------------------------CASA-------------------------------

            //-----------------------------AUTO-------------------------------  
            Object auto = JSON.Load<Object>("C:\\Users\\gabri\\Desktop\\ProGrafica\\ProGrafica\\Json\\auto.json");
            //-----------------------------AUTO-------------------------------  

            //-----------------------------ESCENARIO-------------------------------  
            Scene casaAuto = JSON.Load<Scene>("C:\\Users\\gabri\\Desktop\\ProGrafica\\ProGrafica\\Json\\casaAuto.json");
            casaAuto.Draw();
            //-----------------------------ESCENARIO-------------------------------  
            Axis axis = new Axis();
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        protected override void OnResize(EventArgs e)
        {
            double escala = 5.0;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-escala, escala, -escala, escala, -escala, escala);
            GL.MatrixMode(MatrixMode.Modelview);


            base.OnResize(e);
        }
    }
}
