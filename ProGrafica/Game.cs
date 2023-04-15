using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

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
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Rotate(10.0, 1.0, 0.0, 0.0);
            GL.Rotate(theta, 0.0, 1.0, 0.0);

            //-----------------------------CASA-------------------------------
            Object casa = new Object(0.5,2.0,0.0); //Se introduce el punto centro del Objeto
            Face triangulo1 = new Face(Color.BurlyWood,PrimitiveType.Triangles);
                triangulo1.addVertex(new Double[] { -0.5, -0.5, 0.0 }); //Punto izq abajo
                triangulo1.addVertex(new Double[] { 0.5, -0.5, 0.0 });  //punto derecha abajo
                triangulo1.addVertex(new Double[] { 0.0, 0.5, 0.0 });   //Punto cima
            Face triangulo2 = new Face(Color.BurlyWood, PrimitiveType.Triangles);
                triangulo2.addVertex(new Double[] { -0.5, -0.5, -2.0 }); //Punto izq abajo
                triangulo2.addVertex(new Double[] { 0.5, -0.5, -2.0 });  //Punto der abajo
                triangulo2.addVertex(new Double[] { 0.0, 0.5, -2.0 });  //Punto cima
            Face rectDer = new Face(Color.Firebrick, PrimitiveType.Quads);
                rectDer.addVertex(new Double[] { 0.0, 0.5, 0.0 });  //A
                rectDer.addVertex(new Double[] { 0.5, -0.5, 0.0 }); //B
                rectDer.addVertex(new Double[] { 0.5, -0.5, -2.0 });//C
                rectDer.addVertex(new Double[] { 0.0, 0.5, -2.0 }); //D
            Face rectIzq = new Face(Color.Firebrick, PrimitiveType.Quads);
                rectDer.addVertex(new Double[] { 0.0, 0.5, 0.0 }); //A
                rectDer.addVertex(new Double[] { -0.5, -0.5, 0.0 }); //B
                rectDer.addVertex(new Double[] { -0.5, -0.5, -2.0 });//C
                rectDer.addVertex(new Double[] { 0.0, 0.5, -2.0 });  //D
            Face paredFront = new Face(Color.WhiteSmoke, PrimitiveType.Quads);
                paredFront.addVertex(new Double[] { -0.5, -0.5, 0.0 }); //A
                paredFront.addVertex(new Double[] { -0.5, -2.0, 0.0}); //B
                paredFront.addVertex(new Double[] { 0.5, -2.0, 0.0 }); //C
                paredFront.addVertex(new Double[] { 0.5, -0.5, 0.0 }); //D
            Face puerta= new Face(Color.FromArgb(1,128,64,0), PrimitiveType.Quads);
                puerta.addVertex(new Double[] { -0.25, -1.0, 0.01 }); //A
                puerta.addVertex(new Double[] { -0.25, -2.0, 0.01 }); //B
                puerta.addVertex(new Double[] { 0.25, -2.0, 0.01 }); //C
                puerta.addVertex(new Double[] { 0.25, -1.0, 0.01 }); //D
            Face paredBack = new Face(Color.WhiteSmoke, PrimitiveType.Quads);
                paredBack.addVertex(new Double[] { -0.5, -0.5, -2.0 }); //A
                paredBack.addVertex(new Double[] { -0.5, -2.0, -2.0 }); //B
                paredBack.addVertex(new Double[] { 0.5, -2.0, -2.0 }); //C
                paredBack.addVertex(new Double[] { 0.5, -0.5, -2.0 }); //D
            Face paredIzq = new Face(Color.WhiteSmoke, PrimitiveType.Quads);
                paredIzq.addVertex(new Double[] { -0.5, -0.5, 0.0 });  //A
                paredIzq.addVertex(new Double[] { -0.5, -2.0, 0.0 });  //B
                paredIzq.addVertex(new Double[] { -0.5, -2.0, -2.0 });  //C
                paredIzq.addVertex(new Double[] { -0.5, -0.5, -2.0 }); //D
            Face paredDer = new Face(Color.WhiteSmoke, PrimitiveType.Quads);
                paredDer.addVertex(new Double[] { 0.5,-0.5,0.0 });
                paredDer.addVertex(new Double[] { 0.5,-2.0,0.0 });
                paredDer.addVertex(new Double[] { 0.5,-2.0,-2.0 });
                paredDer.addVertex(new Double[] { 0.5,-0.5,-2.0 });
            
            casa.addFace(triangulo1);
            casa.addFace(triangulo2);
            casa.addFace(rectDer);
            casa.addFace(rectIzq);
            casa.addFace(paredFront);
            casa.addFace(puerta);
            casa.addFace(paredBack);
            casa.addFace(paredIzq);
            casa.addFace(paredDer);
            //casa.draw();
            //-----------------------------CASA-------------------------------
            //-----------------------------AUTO-------------------------------
            Object auto = new Object(1.5, -0.80, 0.0); //Se introduce el punto centro del objeto
            Face cabinaFront = new Face(Color.FromArgb(1, 168, 204, 215), PrimitiveType.Quads);
                cabinaFront.addVertex(new Double[] { -0.4,-0.5,-0.25 }); //Arri, izq, atras
                cabinaFront.addVertex(new Double[] { -0.4, -0.75, 0.0 });//Abajo, izq, adelante
                cabinaFront.addVertex(new Double[] { -0.2, -0.75, 0.0 });//Abajo, der, adelante
                cabinaFront.addVertex(new Double[] { -0.2, -0.5, -0.25 });//Arri, der, atras
            Face cabinaBack = new Face(Color.FromArgb(1, 168, 204, 215), PrimitiveType.Quads);
                cabinaBack.addVertex(new Double[] { -0.4, -0.5, -0.75 }); //izq, arriba, adelante
                cabinaBack.addVertex(new Double[] { -0.4, -0.75, -1.0 }); //izq, abajo, atras
                cabinaBack.addVertex(new Double[] { -0.2, -0.75, -1.0 }); //der, abajo, atras
                cabinaBack.addVertex(new Double[] { -0.2, -0.5, -0.75 }); //der, arriba, adelante
            Face cabinaIzq = new Face(Color.FromArgb(1,170,51,51),PrimitiveType.Quads);
                cabinaIzq.addVertex(new Double[] { -0.4, -0.5, -0.25 }); //A
                cabinaIzq.addVertex(new Double[] { -0.40, -0.75, 0.0 });//B
                cabinaIzq.addVertex(new Double[] { -0.4, -0.75, -1.0 });//C
                cabinaIzq.addVertex(new Double[] { -0.4, -0.5, -0.75 });//D
            Face cabinaDer = new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
                cabinaDer.addVertex(new Double[] { -0.2, -0.5, -0.25 }); //A
                cabinaDer.addVertex(new Double[] { -0.2, -0.75, 0.0 }); //B
                cabinaDer.addVertex(new Double[] { -0.2, -0.75, -1.0 });//C
                cabinaDer.addVertex(new Double[] { -0.2, -0.5, -0.75 });//D
            Face carrosaIzq = new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
                carrosaIzq.addVertex(new Double[] { -0.40, -0.75, 0.0 }); //A
                carrosaIzq.addVertex(new Double[] { -0.40, -1.05, 0.0 }); //B
                carrosaIzq.addVertex(new Double[] { -0.40, -1.05, -1.0 });//C
                carrosaIzq.addVertex(new Double[] { -0.40, -0.75, -1.0 });//D
            Face carrosaFront = new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
                carrosaFront.addVertex(new Double[] { -0.40, -0.75, 0.0 }); //A
                carrosaFront.addVertex(new Double[] { -0.40, -1.05, 0.0 }); //B
                carrosaFront.addVertex(new Double[] { -0.20, -1.05, 0.0 }); //C
                carrosaFront.addVertex(new Double[] { -0.20, -0.75, 0.0 }); //D
            Face carrosaBack = new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
                carrosaBack.addVertex(new Double[] { -0.40, -0.75, -1.0 }); //A
                carrosaBack.addVertex(new Double[] { -0.40, -1.05, -1.0 }); //B
                carrosaBack.addVertex(new Double[] { -0.20, -1.05, -1.0 }); //C
                carrosaBack.addVertex(new Double[] { -0.20, -0.75, -1.0 }); //D
            Face carrosaDer = new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
                carrosaDer.addVertex(new Double[] { -0.20, -0.75, 0.0 }); //A
                carrosaDer.addVertex(new Double[] { -0.20, -1.05, 0.0 }); //B
                carrosaDer.addVertex(new Double[] { -0.20, -1.05, -1.0 });//C
                carrosaDer.addVertex(new Double[] { -0.20, -0.75, -1.0 });//D
            Face techo= new Face(Color.FromArgb(1, 170, 51, 51), PrimitiveType.Quads);
                techo.addVertex(new Double[] { -0.4, -0.5, -0.75 }); //A
                techo.addVertex(new Double[] { -0.4, -0.5, -0.25 }); //B
                techo.addVertex(new Double[] { -0.2, -0.5, -0.25 }); //C
                techo.addVertex(new Double[] { -0.2, -0.5, -0.75 });
            Circle rueditaFrontIzq = new Circle(0.15, "yz", new double[] { -0.41, -1.0, -0.20 }, Color.Orange);
            Circle rueditaFrontDer = new Circle(0.15, "yz", new double[] { -0.19, -1.0, -0.20 }, Color.Orange);
            Circle rueditaBackIzq = new Circle(0.15, "yz", new double[] { -0.41, -1.0, -0.75 }, Color.Orange);
            Circle rueditaBackDer = new Circle(0.15, "yz", new double[] { -0.19, -1.0, -0.75 }, Color.Orange);
            auto.addFace(cabinaFront);
            auto.addFace(cabinaBack);  
            auto.addFace(cabinaIzq);
            auto.addFace(cabinaDer);
            auto.addFace(carrosaIzq);
            auto.addFace(carrosaFront);
            auto.addFace(carrosaBack);
            auto.addFace(carrosaDer);
            auto.addFace(techo);
            auto.addFace(rueditaFrontIzq);
            auto.addFace(rueditaFrontDer);
            auto.addFace(rueditaBackDer);
            auto.addFace(rueditaBackIzq);
            //auto.draw();
            Scene casaAuto = new Scene();
            Object auto2 = new Object(auto);
            auto2.CenterX = -1.5;
            casaAuto.Add(auto);
            casaAuto.Add(casa);
            //casaAuto.Add(auto2);
            casaAuto.Draw();
            //-----------------------------AUTO-------------------------------
            GL.Begin(PrimitiveType.Lines);

                GL.Color3(Color.Red); //Eje X
                GL.Vertex3(-20, 0, 0);
                GL.Vertex3(20, 0, 0); 

                GL.Color3(Color.Blue); //Eje Y
                GL.Vertex3(0, -20, 0);
                GL.Vertex3(0, 20, 0);

                GL.Color3(Color.Green); //Eje Z
                GL.Vertex3(0, 0, -500);
                GL.Vertex3(0, 0, 500);

            GL.End();

            /*GL.Begin(PrimitiveType.TriangleFan);
             GL.Color4(Color.Orange);
             Double radius = 1.0;
             GL.Vertex3(0.0, 2.0, 0.0);
             for (int i = 0; i < 360; i++)
             {
                 GL.Vertex3(0.0 + Math.Cos(i) * radius, 2.0 + Math.Sin(i) * radius,0);
             }

             GL.End();
             */


            Context.SwapBuffers();
            if (theta==360)
            {
                theta = 0;
            }
            else
            {
                theta++;
            }
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
