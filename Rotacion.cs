using System;

namespace Figuras3D
{
    public class Rotacion //es una clase que contiene tres matrices de rotacion
    {
        static float angulo = 0.01f;//la F es para indicar que es un flotante
        //angulo se utiliza para definir el angulo de rotacion en radianes

        //cada una de las matrices de rotacion son de 3x3 de numeros flotantes

        public float[,] rotacionEnX = new float[,]
        {
            {1,0,0}, 
            {0,(float)Math.Cos(angulo), -(float)Math.Sin(angulo)},
            {0,(float)Math.Sin(angulo), (float)Math.Cos(angulo)}

        };
        public float[,] rotacionEnY = new float[,] 
        {
            
            {(float)Math.Cos(angulo),0, (float)Math.Sin(angulo)},
            {0,1,0},
            {-(float)Math.Sin(angulo), 0,(float)Math.Cos(angulo)}
        };

        public float[,] rotacionEnZ = new float[,]
        {
            {(float)Math.Cos(angulo),-(float)Math.Sin(angulo),0},
            {(float)Math.Sin(angulo),(float)Math.Cos(angulo), 0},
            {0,0,1}
        };
     }

}
//en resumen la clase rotacion es una implementacion basica de una matriz de rotacion para rotar objetos en 3D
