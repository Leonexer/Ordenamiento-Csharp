using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurbujaProyectoAGC
{
    // Programa en C# que implementa diversos métodos de ordenamiento.
    // Métodos incluidos: Burbuja, Shaker, Inserción, Inserción Binaria, Selección, Shell, Quicksort y Heapsort.
    // Desarrollado para practicar técnicas de ordenación y análisis de algoritmos.
    internal class Program
    {
        // Método Bubble Sort: compara y ordena pares adyacentes, empujando los mayores al final.

        static int[] BubbleSort(int[] A)
        {
            int N = A.Length;
            int AUX;

            for (int i = 0; i < N - 1; i++)
            {
                for (int j = N - 1; j > i; j--)
                {
                    if (A[j - 1] > A[j])
                    {
                        AUX = A[j - 1];
                        A[j - 1] = A[j];
                        A[j] = AUX;
                    }
                }
            }
            return A;
        }

        // Método Shaker Sort (Burbuja bidireccional): ordena de izquierda a derecha y luego de derecha a izquierda.

        static int[] ShakerSort(int[] A)
        {
            int N = A.Length-1;
            int IZQ = 1, DER = N-1, K = N-1;
            int AUX;

            while (DER >= IZQ)
            {
                for (int i = DER; i >= IZQ; i--)
                {
                    if (A[i - 1] > A[i])
                    {
                        AUX = A[i - 1];
                        A[i - 1] = A[i];
                        A[i] = AUX;
                        K = i;
                    }
                }

                IZQ = K + 1;
                for (int i = IZQ; i <= DER; i++)
                {
                    if (A[i - 1] > A[i])
                    {
                        AUX = A[i - 1];
                        A[i - 1] = A[i];
                        A[i] = AUX;
                        K = i;
                    }
                }
                DER = K - 1;
            }
            return A;
        }

        // Método de Inserción: toma un elemento y lo inserta en su lugar correcto en la parte ordenada.

        static int[] Insercion(int[] A)
        {
            int AUX, K;
            int N = A.Length;
            for (int I = 1; I < N; I++)
            {
                AUX = A[I];
                K = I - 1;

                while (K >= 0 && AUX < A[K])
                {
                    A[K + 1] = A[K];
                    K--;
                }

                A[K + 1] = AUX;
            }
            return A;
        }

        // Método de Inserción Binaria: mejora el método de inserción utilizando búsqueda binaria para ubicar la posición.

        static int[] BinaryInsertion(int[] A)
        {
            int N = A.Length;
            int IZQ, DER, M, J, AUX = 0;

            for (int i = 2; i < N; i++)
            {
                AUX = A[i];
                IZQ = 1;
                DER = i - 1;

                while (IZQ <= DER)
                {
                    M = (IZQ + DER) / 2;
                    if (AUX <= A[M])
                    {
                        DER = M - 1;
                    }
                    else
                    {
                        IZQ = M + 1;
                    }
                }

                J = i - 1;
                while (J >= IZQ)
                {
                    A[J + 1] = A[J];
                    J--;
                }
                A[IZQ] = AUX;
            }
            return A;
        }

        // Método de Selección: selecciona el menor elemento y lo coloca en su posición correspondiente.

        static int[] Seleccion(int[] A)        
        {
            int K, J, MENOR;
            int N = A.Length;
            for (int I = 0; I < N - 1; I++)
            {
                K = I;
                MENOR = A[I];

                for (J = I + 1; J < N; J++)
                {
                    if (A[J] < MENOR)
                    {
                        MENOR = A[J];
                        K = J;
                    }
                }

                A[K] = A[I];
                A[I] = MENOR;
            }
            return A;
        }

        // Método Shell Sort: mejora inserción utilizando saltos para ordenar subgrupos.

        static int[] ShellSort(int[] A)
        {
            int INT, I, AUX;
            int N = A.Length;
            bool BAND;

            INT = N + 1;

            while (INT > 1)
            {
                INT = INT / 2;
                BAND = true;

                while (BAND)
                {
                    BAND = false;
                    I = 0;

                    while ((I + INT) < N)
                    {
                        if (A[I] > A[I + INT])
                        {
                            AUX = A[I];
                            A[I] = A[I + INT];
                            A[I + INT] = AUX;
                            BAND = true;
                        }

                        I++;
                    }
                }
            }
            return A;
        }

        // Método QuickSort: algoritmo recursivo que divide y ordena los subarreglos alrededor de un pivote.

        static int[] Quicksort(int[] A)
        {
            Quicksort(A, 0, A.Length - 1);
            return A;
        }

        static void Quicksort(int[] A, int INI, int FIN)
        {
            if (INI >= FIN) return;

            int IZQ = INI, DER = FIN, POS = INI;
            int AUX;
            bool BAND = true;

            while (BAND)
            {
                BAND = false;

                while (A[POS] <= A[DER] && POS != DER)
                {
                    DER--;
                }

                if (POS != DER)
                {
                    AUX = A[POS];
                    A[POS] = A[DER];
                    A[DER] = AUX;
                    POS = DER;
                }

                while (A[POS] >= A[IZQ] && POS != IZQ)
                {
                    IZQ++;
                }

                if (POS != IZQ)
                {
                    BAND = true;
                    AUX = A[POS];
                    A[POS] = A[IZQ];
                    A[IZQ] = AUX;
                    POS = IZQ;
                }
            }

            Quicksort(A, INI, POS - 1);
            Quicksort(A, POS + 1, FIN);
        }

        // InsertaMonticulo: transforma el arreglo en un montículo máximo.

        static void InsertaMonticulo(int[] A, int N)
        {
            int K, AUX;
            bool BAND;

            for (int I = 1; I < N; I++) 
            {
                K = I;
                BAND = true;

                while (K > 0 && BAND)
                {
                    BAND = false;
                    int padre = (K - 1) / 2; 

                    if (A[K] > A[padre])
                    {
                        AUX = A[padre];
                        A[padre] = A[K];
                        A[K] = AUX;
                        K = padre;
                        BAND = true;
                    }
                }
            }
        }

        // EliminaMonticulo: extrae el máximo y reacomoda el montículo para ordenar.

        static void EliminaMonticulo(int[] A, int N)
        {
            int AUX, IZQ, DER, K, AP;
            bool BAND;

            for (int I = N - 1; I >= 1; I--)
            {
                AUX = A[I];
                A[I] = A[0];
                IZQ = 1;
                DER = 2;
                K = 0;
                BAND = true;

                while (IZQ < I && BAND)
                {
                    int MAYOR = A[IZQ];
                    AP = IZQ;

                    if (DER < I && A[DER] > MAYOR)
                    {
                        MAYOR = A[DER];
                        AP = DER;
                    }

                    if (AUX < MAYOR)
                    {
                        A[K] = A[AP];
                        K = AP;
                    }
                    else
                    {
                        BAND = false;
                    }

                    IZQ = 2 * K + 1;
                    DER = IZQ + 1;
                }

                A[K] = AUX;
            }
        }

        // Método HeapSort: construye un montículo (heap) y lo va desarmando para ordenar el arreglo.

        static int[] HeapSort(int[] A)
        {
            InsertaMonticulo(A, A.Length);
            EliminaMonticulo(A, A.Length);
            return A;
        }

        // Método para mostrar un arreglo dado en los parámetros
        static void MostrarArreglo(int[] arreglo)
        {
            foreach (int num in arreglo)
                Console.Write(num + " ");
            Console.WriteLine("\n");
        }

        // Función principal: Genera un arreglo de enteros aleatorios (en el rango del 0 al 100) con un tamaño dependiente de la entrada del usuario, para despues mostrar un menu en el que se puedan usar los metodos de ordenamiento implementados.
        static void Main(string[] args)
        {
            bool seguir = true;

            while (seguir)
            {
                Console.Clear();
                Console.Write("Ingrese el tamaño del arreglo: ");
                int N = Convert.ToInt32(Console.ReadLine());

                int[] arreglo = new int[N];
                Random rnd = new Random();

                for (int i = 0; i < N; i++)
                {
                    arreglo[i] = rnd.Next(50); 
                }

                Console.WriteLine("\nArreglo generado:");
                MostrarArreglo(arreglo);

                Console.WriteLine("Seleccione un método de ordenamiento:");
                Console.WriteLine("1. Bubble Sort");
                Console.WriteLine("2. Shaker Sort");
                Console.WriteLine("3. Inserción");
                Console.WriteLine("4. Inserción Binaria");
                Console.WriteLine("5. Selección");
                Console.WriteLine("6. Shell Sort");
                Console.WriteLine("7. QuickSort");
                Console.WriteLine("8. HeapSort");
                Console.WriteLine("9. Salir");

                Console.Write("\nOpción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                int[] resultado = new int[N];
                Array.Copy(arreglo, resultado, N); 

                switch (opcion)
                {
                    case 1:
                        resultado = BubbleSort(resultado);
                        break;
                    case 2:
                        resultado = ShakerSort(resultado);
                        break;
                    case 3:
                        resultado = Insercion(resultado);
                        break;
                    case 4:
                        resultado = BinaryInsertion(resultado);
                        break;
                    case 5:
                        resultado = Seleccion(resultado);
                        break;
                    case 6:
                        resultado = ShellSort(resultado);
                        break;
                    case 7:
                        resultado = Quicksort(resultado);
                        break;
                    case 8:
                        resultado = HeapSort(resultado);
                        break;
                    case 9:
                        seguir = false;
                        continue;
                    default:
                        Console.WriteLine("Opción inválida.");
                        continue;
                }

                Console.WriteLine("\nArreglo ordenado:");
                MostrarArreglo(resultado);

                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}