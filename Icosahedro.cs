using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras3D
{
    public class Icosahedro
    {
        public Icosahedro(float radius, Malla malla) 
        {
            float phi = (float)(1 + Math.Sqrt(5)) / 2; // razón áurea
            float a = (radius  / (float)Math.Sqrt(phi * phi + 1)) + 0.3f;
            float b = a * phi;

            Vertice[] vertices = new Vertice[]
            {
                new Vertice(-a, 0, b),
                new Vertice(a, 0, b),
                new Vertice(-a, 0, -b),
                new Vertice(a, 0, -b),
                new Vertice(0, b, a),
                new Vertice(0, b, -a),
                new Vertice(0, -b, a),
                new Vertice(0, -b, -a),
                new Vertice(b, a, 0),
                new Vertice(-b, a, 0),
                new Vertice(b, -a, 0),
                new Vertice(-b, -a, 0)
            };

            int[,] faces = new int[,]
            {
                {0,4,1}, {0,9,4}, {9,5,4}, {4,5,8}, {4,8,1},
                {8,10,1}, {8,3,10}, {5,3,8}, {5,2,3}, {2,7,3},
                {7,10,3}, {7,6,10}, {7,11,6}, {11,0,6}, {0,1,6},
                {6,1,10}, {9,0,11}, {9,11,2}, {9,2,5}, {7,2,11}
            };

            for (int i = 0; i < faces.GetLength(0); i++)
            {
                Triangulo t = new Triangulo();
                

                for (int j = 2; j >= 0; j--)
                {
                    t.Add(vertices[faces[i, j]]);
                }

                malla.MallaDeTriangulos.Add(t);
            }
        }
    }
}
