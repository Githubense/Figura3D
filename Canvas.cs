using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras3D
{
    internal class Canvas
    {
        //variables
        CNQAEC canvas;
        PictureBox PCT_CANVAS;
        Escena escena;
        Malla malla;
        Rotacion rotacion;
        Vertice[] normal, lineaA, lineaB;
        Vertice puntoDevista;
        double[] LongitudNormal;
        Point a, b, c, d;
        int hwidth, hheight;

        public Canvas(PictureBox pictureBox) 
        {
            PCT_CANVAS = pictureBox;
            canvas = new CNQAEC(PCT_CANVAS.Size);
            pictureBox.Image = canvas.bitmap;

            escena = new Escena();
            malla = new Malla();
            rotacion = new Rotacion();
            escena.AlgunaFigura.Add( malla );
            canvas.FastClear();
            PCT_CANVAS.Invalidate();


        }
        //funciones de rotacion

        public void RotacionX()
        {
            for (int i = 0; i < malla.MallaDeTriangulos.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    malla.MallaDeTriangulos[i].Vertices[j] = new Vertice(rotacion.rotacionEnX[0, 0] * malla.MallaDeTriangulos[i].Vertices[j].X, (rotacion.rotacionEnX[1, 1] * malla.MallaDeTriangulos[i].Vertices[j].Y) + (rotacion.rotacionEnX[1, 2] * malla.MallaDeTriangulos[i].Vertices[j].Z), (rotacion.rotacionEnX[2, 1] * malla.MallaDeTriangulos[i].Vertices[j].Y) + (rotacion.rotacionEnX[2, 2] * malla.MallaDeTriangulos[i].Vertices[j].Z));
                }
            }

            for (int i = 0; i < malla.MallaDeTriangulos.Count; i++)
            {
                lineaA[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[1].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[1].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[1].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                lineaB[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[2].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[2].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[2].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                normal[i] = new Vertice(lineaA[i].Y * lineaB[i].Z - lineaA[i].Z * lineaB[i].Y, lineaA[i].Z * lineaB[i].X - lineaA[i].X * lineaB[i].Z, lineaA[i].X * lineaB[i].Y - lineaA[i].Y * lineaB[i].X);
                LongitudNormal[i] = Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                normal[i].X /= (float)LongitudNormal[i]; normal[i].Y /= (float)LongitudNormal[i]; normal[i].Z /= (float)LongitudNormal[i];
            }
            Render();
        }

        public void RotacionY()
        {
            for (int i = 0; i < malla.MallaDeTriangulos.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    malla.MallaDeTriangulos[i].Vertices[j] = new Vertice((rotacion.rotacionEnY[0, 0] * malla.MallaDeTriangulos[i].Vertices[j].X) + (rotacion.rotacionEnY[0, 2] * malla.MallaDeTriangulos[i].Vertices[j].Z), rotacion.rotacionEnY[1, 1] * malla.MallaDeTriangulos[i].Vertices[j].Y, ((rotacion.rotacionEnY[2, 0] * malla.MallaDeTriangulos[i].Vertices[j].X) + (rotacion.rotacionEnY[2, 2] * malla.MallaDeTriangulos[i].Vertices[j].Z)));
                }
            }

            for (int i = 0; i < malla.MallaDeTriangulos.Count; i++)
            {
                lineaA[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[1].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[1].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[1].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                lineaB[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[2].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[2].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[2].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                normal[i] = new Vertice(lineaA[i].Y * lineaB[i].Z - lineaA[i].Z * lineaB[i].Y, lineaA[i].Z * lineaB[i].X - lineaA[i].X * lineaB[i].Z, lineaA[i].X * lineaB[i].Y - lineaA[i].Y * lineaB[i].X);
                LongitudNormal[i] = Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                normal[i].X /= (float)LongitudNormal[i]; normal[i].Y /= (float)LongitudNormal[i]; normal[i].Z /= (float)LongitudNormal[i];
            }
            Render();
        }

        public void RotacionZ()
        {

            for (int i = 0; i < malla.MallaDeTriangulos.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    malla.MallaDeTriangulos[i].Vertices[j] = new Vertice(((rotacion.rotacionEnZ[0, 0] * malla.MallaDeTriangulos[i].Vertices[j].X) + (rotacion.rotacionEnZ[0, 1] * malla.MallaDeTriangulos[i].Vertices[j].Y)), ((rotacion.rotacionEnZ[1, 0] * malla.MallaDeTriangulos[i].Vertices[j].X) + (rotacion.rotacionEnZ[1, 1] * malla.MallaDeTriangulos[i].Vertices[j].Y)), rotacion.rotacionEnZ[2, 2] * malla.MallaDeTriangulos[i].Vertices[j].Z);
                }
            }

            for (int i = 0; i < malla.MallaDeTriangulos.Count; i++)
            {
                lineaA[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[1].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[1].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[1].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                lineaB[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[2].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[2].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[2].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                normal[i] = new Vertice(lineaA[i].Y * lineaB[i].Z - lineaA[i].Z * lineaB[i].Y, lineaA[i].Z * lineaB[i].X - lineaA[i].X * lineaB[i].Z, lineaA[i].X * lineaB[i].Y - lineaA[i].Y * lineaB[i].X);
                LongitudNormal[i] = Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                normal[i].X /= (float)LongitudNormal[i]; normal[i].Y /= (float)LongitudNormal[i]; normal[i].Z /= (float)LongitudNormal[i];
            }
            Render();
        }


        //funcioes

        public void Ejes()
        {
            hwidth = (int)(PCT_CANVAS.Width/2f);
            hheight = (int)(PCT_CANVAS.Height / 2f);

            a = new Point(0, hheight);
            b = new Point(hwidth + hwidth, hheight);
            c = new Point(hwidth + 0);
            d = new Point(hwidth, hheight + hheight);

            canvas.DrawLine(a, b, Color.Red);
            canvas.DrawLine(c, d, Color.Red);

            PCT_CANVAS.Invalidate();
        }

        public void Render()
        {
            canvas.FastClear();
            Ejes();

            for (int i = 0; i < malla.MallaDeTriangulos.Count; i++)
            {
                malla.MallaDeTriangulos[i].points[0] = new Point((int)(hwidth + (150 * (malla.MallaDeTriangulos[i].Vertices[0].X / (3 - malla.MallaDeTriangulos[i].Vertices[0].Z)))), (int)(hheight + (150 * (malla.MallaDeTriangulos[i].Vertices[0].Y / (3 - malla.MallaDeTriangulos[i].Vertices[0].Z)))));
                malla.MallaDeTriangulos[i].points[1] = new Point((int)(hwidth + (150 * (malla.MallaDeTriangulos[i].Vertices[1].X / (3 - malla.MallaDeTriangulos[i].Vertices[1].Z)))), (int)(hheight + (150 * (malla.MallaDeTriangulos[i].Vertices[1].Y / (3 - malla.MallaDeTriangulos[i].Vertices[1].Z)))));
                malla.MallaDeTriangulos[i].points[2] = new Point((int)(hwidth + (150 * (malla.MallaDeTriangulos[i].Vertices[2].X / (3 - malla.MallaDeTriangulos[i].Vertices[2].Z)))), (int)(hheight + (150 * (malla.MallaDeTriangulos[i].Vertices[2].Y / (3 - malla.MallaDeTriangulos[i].Vertices[2].Z)))));
            }

            for ( int i = 0; i < malla.MallaDeTriangulos.Count; i++ )
            {
                if (normal[i].X * (malla.MallaDeTriangulos[i].Vertices[0].X - puntoDevista.X) + normal[i].Y * (malla.MallaDeTriangulos[i].Vertices[0].Y - puntoDevista.Y) + normal[i].Z * (malla.MallaDeTriangulos[i].Vertices[0].Z - puntoDevista.Z) < 0)
                {
                    canvas.DrawWireFrameTriangle(malla.MallaDeTriangulos[i].points[0], malla.MallaDeTriangulos[i].points[1], malla.MallaDeTriangulos[i].points[2], Color.White);
                }
            }

            PCT_CANVAS.Invalidate();
            
        }

        //figuras

        public void Cubo()
        {
            Cubo cubo = new Cubo(1, ref malla);
            lineaA = new Vertice[malla.MallaDeTriangulos.Count];
            lineaB = new Vertice[malla.MallaDeTriangulos.Count];
            normal = new Vertice[malla.MallaDeTriangulos.Count];
            LongitudNormal = new double[malla.MallaDeTriangulos.Count];
            puntoDevista = new Vertice(0, 0, 3);

            // calculamos los vectores normales
            for (int i = 0; i < malla.MallaDeTriangulos.Count; i++)
            {
                lineaA[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[1].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[1].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[1].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                lineaB[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[2].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[2].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[2].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                normal[i] = new Vertice(lineaA[i].Y * lineaB[i].Z - lineaA[i].Z * lineaB[i].Y, lineaA[i].Z * lineaB[i].X - lineaA[i].X * lineaB[i].Z, lineaA[i].X * lineaB[i].Y - lineaA[i].Y * lineaB[i].X);
                float longitudNormal = (float)Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                if (longitudNormal != 0)
                {
                    normal[i] = new Vertice(normal[i].X / longitudNormal, normal[i].Y / longitudNormal, normal[i].Z / longitudNormal);
                }
            }



        }

        public void Cono()
        {
            Cono cono = new Cono(1, 2, ref malla);
            lineaA = new Vertice[malla.MallaDeTriangulos.Count];
            lineaB = new Vertice[malla.MallaDeTriangulos.Count];
            normal = new Vertice[malla.MallaDeTriangulos.Count];
            LongitudNormal = new double[malla.MallaDeTriangulos.Count];
            puntoDevista = new Vertice(0, 0, 3);

            // calculamos los vectores normales
            for (int i = 0; i < malla.MallaDeTriangulos.Count; i++)
            {
                lineaA[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[1].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[1].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[1].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                lineaB[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[2].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[2].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[2].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                normal[i] = new Vertice(lineaA[i].Y * lineaB[i].Z - lineaA[i].Z * lineaB[i].Y, lineaA[i].Z * lineaB[i].X - lineaA[i].X * lineaB[i].Z, lineaA[i].X * lineaB[i].Y - lineaA[i].Y * lineaB[i].X);
                float longitudNormal = (float)Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                if (longitudNormal != 0)
                {
                    normal[i] = new Vertice(normal[i].X / longitudNormal, normal[i].Y / longitudNormal, normal[i].Z / longitudNormal);
                }
            }
        }

        public void Cilindro()
        {
            Cilindro cilindro = new Cilindro(1, 2, ref malla);
            lineaA = new Vertice[malla.MallaDeTriangulos.Count];
            lineaB = new Vertice[malla.MallaDeTriangulos.Count];
            normal = new Vertice[malla.MallaDeTriangulos.Count];
            LongitudNormal = new double[malla.MallaDeTriangulos.Count];
            puntoDevista = new Vertice(0, 0, 3);

            // calculamos los vectores normales
            for (int i = 0; i < malla.MallaDeTriangulos.Count; i++)
            {
                lineaA[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[1].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[1].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[1].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                lineaB[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[2].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[2].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[2].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                normal[i] = new Vertice(lineaA[i].Y * lineaB[i].Z - lineaA[i].Z * lineaB[i].Y, lineaA[i].Z * lineaB[i].X - lineaA[i].X * lineaB[i].Z, lineaA[i].X * lineaB[i].Y - lineaA[i].Y * lineaB[i].X);
                float longitudNormal = (float)Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                if (longitudNormal != 0)
                {
                    normal[i] = new Vertice(normal[i].X / longitudNormal, normal[i].Y / longitudNormal, normal[i].Z / longitudNormal);
                }
            }
        }

        public void Esfera()
        {
            Esfera esfera = new Esfera(2,25, malla);
            lineaA = new Vertice[malla.MallaDeTriangulos.Count];
            lineaB = new Vertice[malla.MallaDeTriangulos.Count];
            normal = new Vertice[malla.MallaDeTriangulos.Count];
            LongitudNormal = new double[malla.MallaDeTriangulos.Count];
            puntoDevista = new Vertice(0, 0, 3);

            // calculamos los vectores normales
            for (int i = 0; i < malla.MallaDeTriangulos.Count; i++)
            {
                lineaA[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[1].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[1].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[1].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                lineaB[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[2].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[2].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[2].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                normal[i] = new Vertice(lineaA[i].Y * lineaB[i].Z - lineaA[i].Z * lineaB[i].Y, lineaA[i].Z * lineaB[i].X - lineaA[i].X * lineaB[i].Z, lineaA[i].X * lineaB[i].Y - lineaA[i].Y * lineaB[i].X);
                float longitudNormal = (float)Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                if (longitudNormal != 0)
                {
                    normal[i] = new Vertice(normal[i].X / longitudNormal, normal[i].Y / longitudNormal, normal[i].Z / longitudNormal);
                }
            }

        }

        public void Icosahedro()
        {
            Icosahedro icosahedro = new Icosahedro(1,  malla);
            lineaA = new Vertice[malla.MallaDeTriangulos.Count];
            lineaB = new Vertice[malla.MallaDeTriangulos.Count];
            normal = new Vertice[malla.MallaDeTriangulos.Count];
            LongitudNormal = new double[malla.MallaDeTriangulos.Count];
            puntoDevista = new Vertice(0, 0, 3);

            // calculamos los vectores normales
            for (int i = 0; i < malla.MallaDeTriangulos.Count; i++)
            {
                lineaA[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[1].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[1].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[1].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                lineaB[i] = new Vertice(malla.MallaDeTriangulos[i].Vertices[2].X - malla.MallaDeTriangulos[i].Vertices[0].X, malla.MallaDeTriangulos[i].Vertices[2].Y - malla.MallaDeTriangulos[i].Vertices[0].Y, malla.MallaDeTriangulos[i].Vertices[2].Z - malla.MallaDeTriangulos[i].Vertices[0].Z);
                normal[i] = new Vertice(lineaA[i].Y * lineaB[i].Z - lineaA[i].Z * lineaB[i].Y, lineaA[i].Z * lineaB[i].X - lineaA[i].X * lineaB[i].Z, lineaA[i].X * lineaB[i].Y - lineaA[i].Y * lineaB[i].X);
                float longitudNormal = (float)Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                if (longitudNormal != 0)
                {
                    normal[i] = new Vertice(normal[i].X / longitudNormal, normal[i].Y / longitudNormal, normal[i].Z / longitudNormal);
                }
            }



        }

        //Para el ciclo for:
        //calcula los vectores normales de una malla de triángulos. En una malla de triángulos, cada triángulo se define por tres vértices.
        //Para calcular la normal de un triángulo, primero necesitamos calcular dos vectores a partir de dos de sus vértices, que llamamos lineaA y lineaB en el código.
        //Luego calculamos su producto cruz para obtener la normal.

        //Después, se calcula la longitud de la normal utilizando el teorema de Pitágoras en 3 dimensiones y se normaliza la normal dividiéndola por su longitud para que tenga una magnitud de 1.
        //Esto se hace porque las normales normalizadas se utilizan con frecuencia en los cálculos de iluminación en gráficos 3D.

        //Finalmente, esto se hace para cada triángulo de la malla utilizando un bucle for que recorre los elementos de la lista de triángulos de la malla de triángulos.

    }


}
