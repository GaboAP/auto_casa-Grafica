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
using System.Threading;

namespace ProGrafica
{
    class Game:GameWindow
    {
        private Double theta=0;
        private Double traslacion = 0.1;
        Object auto = new Object(1.5, 1.2, 0.0); //Se introduce el punto centro del objeto
        public Game(int widht, int height, string title):base(widht, height, GraphicsMode.Default, title)
        {
        }
        
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            
            Face cabinaFront = new Face(Color.FromArgb(1, 168, 204, 215), PrimitiveType.Quads);
            cabinaFront.addVertex("cabinaFront1", new Vector3d(-0.4, -0.5, -0.25)); //Arri, izq, atras
            cabinaFront.addVertex("cabinaFront2", new Vector3d(-0.4, -0.75, 0.0));//Abajo, izq, adelante
            cabinaFront.addVertex("cabinaFront3", new Vector3d(-0.2, -0.75, 0.0));//Abajo, der, adelante
            cabinaFront.addVertex("cabinaFront4", new Vector3d(-0.2, -0.5, -0.25));//Arri, der, atras
            Face cabinaBack = new Face(Color.FromArgb(1, 168, 204, 215), PrimitiveType.Quads);
            cabinaBack.addVertex("cabinaBack1", new Vector3d(-0.4, -0.5, -0.75)); //izq, arriba, adelante
            cabinaBack.addVertex("cabinaBack2", new Vector3d(-0.4, -0.75, -1.0)); //izq, abajo, atras
            cabinaBack.addVertex("cabinaBack3", new Vector3d(-0.2, -0.75, -1.0)); //der, abajo, atras
            cabinaBack.addVertex("cabinaBack4", new Vector3d(-0.2, -0.5, -0.75)); //der, arriba, adelante
            Face cabinaIzq = new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
            cabinaIzq.addVertex("cabinaIzq1", new Vector3d(-0.4, -0.5, -0.25)); //A
            cabinaIzq.addVertex("cabinaIzq2", new Vector3d(-0.40, -0.75, 0.0));//B
            cabinaIzq.addVertex("cabinaIzq3", new Vector3d(-0.4, -0.75, -1.0));//C
            cabinaIzq.addVertex("cabinaIzq4", new Vector3d(-0.4, -0.5, -0.75));//D
            Face cabinaDer = new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
            cabinaDer.addVertex("cabinaDer1", new Vector3d(-0.2, -0.5, -0.25)); //A
            cabinaDer.addVertex("cabinaDer2", new Vector3d(-0.2, -0.75, 0.0)); //B
            cabinaDer.addVertex("cabinaDer3", new Vector3d(-0.2, -0.75, -1.0));//C
            cabinaDer.addVertex("cabinaDer4", new Vector3d(-0.2, -0.5, -0.75));//D
            Face carrosaIzq = new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
            carrosaIzq.addVertex("carrosaIzq1", new Vector3d(-0.40, -0.75, 0.0)); //A
            carrosaIzq.addVertex("carrosaIzq2", new Vector3d(-0.40, -1.05, 0.0)); //B
            carrosaIzq.addVertex("carrosaIzq3", new Vector3d(-0.40, -1.05, -1.0));//C
            carrosaIzq.addVertex("carrosaIzq4", new Vector3d(-0.40, -0.75, -1.0));//D
            Face carrosaFront = new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
            carrosaFront.addVertex("carrosaFront1", new Vector3d(-0.40, -0.75, 0.0)); //A
            carrosaFront.addVertex("carrosaFront2", new Vector3d(-0.40, -1.05, 0.0)); //B
            carrosaFront.addVertex("carrosaFront3", new Vector3d(-0.20, -1.05, 0.0)); //C
            carrosaFront.addVertex("carrosaFront4", new Vector3d(-0.20, -0.75, 0.0)); //D
            Face carrosaBack = new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
            carrosaBack.addVertex("carrosaBack1", new Vector3d(-0.40, -0.75, -1.0)); //A
            carrosaBack.addVertex("carrosaBack2", new Vector3d(-0.40, -1.05, -1.0)); //B
            carrosaBack.addVertex("carrosaBack3", new Vector3d(-0.20, -1.05, -1.0)); //C
            carrosaBack.addVertex("carrosaBack4", new Vector3d(-0.20, -0.75, -1.0)); //D
            Face carrosaDer = new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
            carrosaDer.addVertex("carrosaDer1", new Vector3d(-0.20, -0.75, 0.0)); //A
            carrosaDer.addVertex("carrosaDer2", new Vector3d(-0.20, -1.05, 0.0)); //B
            carrosaDer.addVertex("carrosaDer3", new Vector3d(-0.20, -1.05, -1.0));//C
            carrosaDer.addVertex("carrosaDer4", new Vector3d(-0.20, -0.75, -1.0));//D
            Face techo = new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
            techo.addVertex("techo1", new Vector3d(-0.4, -0.5, -0.75)); //A
            techo.addVertex("techo2", new Vector3d(-0.4, -0.5, -0.25)); //B
            techo.addVertex("techo3", new Vector3d(-0.2, -0.5, -0.25)); //C
            techo.addVertex("techo4", new Vector3d(-0.2, -0.5, -0.75));
            Circle rueditaFrontIzq = new Circle("ruedita1", 0.15, "yz", new Vector3d(-0.41, -1.0, -0.20), Color.Orange);
            Circle rueditaFrontDer = new Circle("ruedita2", 0.15, "yz", new Vector3d(-0.19, -1.0, -0.20), Color.Orange);
            Circle rueditaBackIzq = new Circle("ruedita3", 0.15, "yz", new Vector3d(-0.41, -1.0, -0.75), Color.Orange);
            Circle rueditaBackDer = new Circle("ruedita4", 0.15, "yz", new Vector3d(-0.19, -1.0, -0.75), Color.Orange);
            auto.addFace("paraBrisasFront", cabinaFront);
            auto.addFace("paraBrisasBack", cabinaBack);
            auto.addFace("ventanaIzq", cabinaIzq);
            auto.addFace("ventanaDer", cabinaDer);
            auto.addFace("carrosaIzq", carrosaIzq);
            auto.addFace("carrosaFront", carrosaFront);
            auto.addFace("carrosaBack", carrosaBack);
            auto.addFace("carrosaDer", carrosaDer);
            auto.addFace("techo", techo);
            auto.addFace("rueda1", rueditaFrontIzq);
            auto.addFace("rueda2", rueditaFrontDer);
            auto.addFace("rueda4", rueditaBackDer);
            auto.addFace("rueda3", rueditaBackIzq);
            base.OnLoad(e);
            //auto.Move(new Vector3d(1.0, 1.0, 1.0));
            auto.Scale(2.0);
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
                theta += 1;
            }
        }
        public void traslacionInc()
        {
            bool b = true;
            if (Math.Abs(traslacion) > 2.0)
            {
                b = !b;
                traslacion = 0;
            }
            if (b)
            {
                traslacion += 0.1;
            }
            else
            {
                traslacion -= 0.1;
            }
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Rotate(10.0, 1.0, 0.0, 0.0);
            GL.Rotate(theta, 0.0, 1.0, 0.0);
            //-----------------------------ESCENARIO-------------------------------
            
            auto.draw();
            //casaAuto.Move("x", traslacion);
            //casaAuto.rotate(eje, theta

            thetaInc();
            traslacionInc();
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
