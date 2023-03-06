

namespace Figuras3D
{
    public class Cubo
    {

        public Cubo(float tamaño, ref Malla malla) 
        {
            //creamos los vertices del cubo

            Vertice[] vertices =
            {
                new Vertice (-tamaño,-tamaño,-tamaño),
                new Vertice (-tamaño,-tamaño,tamaño),
                new Vertice (-tamaño,tamaño,-tamaño),
                new Vertice (-tamaño,tamaño,tamaño),
                new Vertice (tamaño,-tamaño,-tamaño),
                new Vertice (tamaño,-tamaño,tamaño),
                new Vertice (tamaño,tamaño,-tamaño),
                new Vertice (tamaño,tamaño,tamaño),
            };

            //creamos las caras del cubo

            int[][] caras =
            {
                new int[] {0, 1, 3},
                new int[] {0, 3, 2},
                new int[] {4, 6, 7},
                new int[] {4, 7, 5},
                new int[] {1, 5, 7},
                new int[] {1, 7, 3},
                new int[] {0, 2, 6},
                new int[] {0, 6, 4},
                new int[] {2, 3, 7},
                new int[] {2, 7, 6},
                new int[] {0, 4, 5},
                new int[] {0, 5, 1}
            };

            //creamos los triangulos para cada cara
            for (int i = 0;  i < caras.Length; i++)
            {
                Triangulo triangulo = new Triangulo ();

                for (int j = 0;j<3; j++)
                {
                    int vertexIndex = caras[i][j];
                    Vertice vertice = vertices[vertexIndex];
                    triangulo.Add(vertice);
                }
                malla.MallaDeTriangulos.Add(triangulo);
            }
        }
    }
}
