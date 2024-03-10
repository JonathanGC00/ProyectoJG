using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJG
{
    public class Matriz
    {
        private readonly int[,] elementos;

        public int Filas { get; }
        public int Columnas { get; }

        public Matriz(int filas, int columnas)
        {
            Filas = filas;
            Columnas = columnas;
            elementos = new int[filas, columnas];
        }

        public int this[int fila, int columna]
        {
            get { return elementos[fila, columna]; }
            set { elementos[fila, columna] = value; }
        }

        public static Matriz Sumar(Matriz matriz1, Matriz matriz2)
        {
            if (matriz1.Filas != matriz2.Filas || matriz1.Columnas != matriz2.Columnas)
                throw new ArgumentException("Las matrices deben tener las mismas dimensiones.");

            Matriz resultado = new Matriz(matriz1.Filas, matriz1.Columnas);
            for (int i = 0; i < matriz1.Filas; i++)
            {
                for (int j = 0; j < matriz1.Columnas; j++)
                {
                    resultado[i, j] = matriz1[i, j] + matriz2[i, j];
                }
            }

            return resultado;
        }

        public static Matriz Restar(Matriz matriz1, Matriz matriz2)
        {
            if (matriz1.Filas != matriz2.Filas || matriz1.Columnas != matriz2.Columnas)
                throw new ArgumentException("Las matrices deben tener las mismas dimensiones.");

            Matriz resultado = new Matriz(matriz1.Filas, matriz1.Columnas);
            for (int i = 0; i < matriz1.Filas; i++)
            {
                for (int j = 0; j < matriz1.Columnas; j++)
                {
                    resultado[i, j] = matriz1[i, j] - matriz2[i, j];
                }
            }

            return resultado;
        }

        public static Matriz Multiplicar(Matriz matriz1, Matriz matriz2)
        {
            if (matriz1.Columnas != matriz2.Filas)
            {
                throw new ArgumentException("El número de columnas de la primera matriz debe ser igual al número de filas de la segunda matriz.");
            
            }
            
            Matriz resultado = new Matriz(matriz1.Filas, matriz2.Columnas);
            for (int i = 0; i < matriz1.Filas; i++)
            {
                for (int j = 0; j < matriz2.Columnas; j++)
                {
                    int suma = 0;
                    for (int k = 0; k < matriz1.Columnas; k++)
                    {
                        suma += matriz1[i, k] * matriz2[k, j];
                    }
                    resultado[i, j] = suma;
                }
            }

            return resultado;
        }
    }


}

