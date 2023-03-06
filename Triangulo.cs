
using System.Collections.Generic;
using System.Drawing;

namespace Figuras3D
{
    public class Triangulo
    {
        public List <Vertice> Vertices = new List<Vertice>(); //lista de objetos vertice para los vertices del triangulo 3D
        public Point[] points = new Point[3]; // es un arreglo que representa los vertices en las coordenadas bidimencionales

        public void Add(Vertice vertice) //metodo que agrega un objeto vertice a la lista de vertices del triangulo
        {
            Vertices.Add(vertice);
        }
    }
}

// en resumen esta clase representa un triangulo en un sistema de coordenadas 3D y proporciona una lista de sus vertices en el espacio 3D
// y un sistema de coordenadas 2D, asi como un metodo para agregar nuevos vertices a la lista