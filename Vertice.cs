
namespace Figuras3D
{
    public class Vertice //representa un punto en un sistema de coordenadas tridimencionales 
    {
        float coordenadaX, coordenadaY, coordenadaZ;

        public Vertice (float X, float Y, float Z) //constructor 
        {
            this.coordenadaX = X;
            this.coordenadaY = Y;
            this.coordenadaZ = Z;

        }
        //cada propiedad tiene un getter y un setter para acceder y modificar los valores
        public float X
        {
            get { return coordenadaX; }
            set { coordenadaX=value; }
        }
        public float Y
        {
            get { return coordenadaY; }
            set { coordenadaY=value;}
        }
        public float Z
        {
            get { return coordenadaZ; }
            set { coordenadaZ = value;}
        }
    }
}

// en resumen esta clase representa un punto tridimensional y proporciona m[etodos para acceder y modificar las cordenadas X, Y y Z