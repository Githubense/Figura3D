using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras3D
{
    public class Cilindro
    {
        public Vertice top;
        public Vertice bottom;

        public Cilindro(int radius, int height, ref Malla mesh)
        {
            
            Base base1 = new Base(radius, -1, ref mesh, false);
            int numeroDeTriangulos1 = mesh.MallaDeTriangulos.Count;

            Base base2 = new Base(radius, height-1, ref mesh, true);

            int numeroDeTriangulos2 = mesh.MallaDeTriangulos.Count;

            for (int i = 0; i < numeroDeTriangulos2; i++)
            {
                Triangulo t1 = new Triangulo();

                t1.Add(mesh.MallaDeTriangulos[i].Vertices[1]);
                t1.Add(mesh.MallaDeTriangulos[i + numeroDeTriangulos1].Vertices[1]);
                t1.Add(mesh.MallaDeTriangulos[i].Vertices[2]);

                mesh.MallaDeTriangulos.Add(t1);
            }

            for (int i = 0; i < numeroDeTriangulos1; i++)
            {
                Triangulo t2 = new Triangulo();

                
                t2.Add(mesh.MallaDeTriangulos[i + numeroDeTriangulos1].Vertices[1]);
                t2.Add(mesh.MallaDeTriangulos[i].Vertices[1]);
                t2.Add(mesh.MallaDeTriangulos[i + numeroDeTriangulos1].Vertices[2]);

                mesh.MallaDeTriangulos.Add(t2);
            }
        }

        public class Base
        {
            public int radious;
            public int height;

            public Base(int rad, int height, ref Malla mesh, bool front)
            {
                this.radious = rad;
                this.height = height;

                int particiones = 20;
                double anguloInicial = 0;
                double anguloFinal = (360 / particiones) * (Math.PI / 180);

                if (front)
                {
                    for (int i = 0; i < particiones; i++)
                    {
                        Triangulo triangulo = new Triangulo();
                        triangulo.Add(new Vertice(0, 0, height));
                        triangulo.Add(new Vertice((float)(radious * Math.Cos(anguloInicial)), (float)(radious * Math.Sin(anguloInicial)), height));
                        triangulo.Add(new Vertice((float)(radious * Math.Cos(anguloFinal)), (float)(radious * Math.Sin(anguloFinal)), height));

                        mesh.MallaDeTriangulos.Add(triangulo);

                        anguloInicial = anguloFinal;
                        anguloFinal += (360.0 / particiones) * (Math.PI / 180.0);
                    }
                }
                else
                {
                    for (int i = 0; i < particiones; i++)
                    {
                        Triangulo triangulo = new Triangulo();
                        triangulo.Add(new Vertice(0, 0, height));
                        triangulo.Add(new Vertice((float)(radious * Math.Cos(anguloFinal)), (float)(radious * Math.Sin(anguloFinal)), height));
                        triangulo.Add(new Vertice((float)(radious * Math.Cos(anguloInicial)), (float)(radious * Math.Sin(anguloInicial)), height));

                        mesh.MallaDeTriangulos.Add(triangulo);

                        anguloInicial = anguloFinal;
                        anguloFinal += (360.0 / particiones) * (Math.PI / 180.0);
                    }
                }
            }
        }
    }

}
