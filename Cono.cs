using System;

namespace Figuras3D
{

    public class Cono
    {
        public Vertice top;

        public Cono(int radius, int height, ref Malla mesh)
        {
            top = new Vertice(0, 0, height);

            Base @base = new Base(radius, 0, ref mesh, false);

            int triangleNumber = mesh.MallaDeTriangulos.Count;

            for (int i = 0; i < triangleNumber; i++)
            {
                Triangulo t = new Triangulo();
                t.Add(mesh.MallaDeTriangulos[i].Vertices[1]);
                t.Add(top);
                t.Add(mesh.MallaDeTriangulos[i].Vertices[2]);

                mesh.MallaDeTriangulos.Add(t);
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


