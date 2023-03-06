
using System.Collections.Generic;

namespace Figuras3D
{
    public class Escena
    {
        public List<Malla> AlgunaFigura; //una lista de objetos tipos malla, esta lista almacena las mallas que ocnforman la escena
        public Escena() //constructor
        { 
            AlgunaFigura = new List<Malla>(); //inicializa la lista, osea que cuando un objeto tipo escena se crea tambien se crea una lista vacias de mallas
        }
    }
}

