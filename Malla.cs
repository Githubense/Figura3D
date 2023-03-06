
using System.Collections.Generic;


namespace Figuras3D
{
    public class Malla
    {
        public List<Triangulo> MallaDeTriangulos; //lista de objetos tipo triangulo, almacena los triangulos que conforman la malla
        public Malla() //constructor 
        {
            MallaDeTriangulos = new List<Triangulo>(); //inicializamos la lista de triangulos, o sea que cuando se crea un objeto Malla se crea automaticamnte una lista vacia de triangulos
        }
    }
}
//Esta clase representa una malla de triangulos en un sistema de coordenadas tridimensional y poporciona una lista de triangulos
// que conforman la malla. 