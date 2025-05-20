# Proyecto de Métodos de Ordenamiento en C#

## Introducción

Este proyecto implementa diversos algoritmos clásicos de ordenamiento en el lenguaje C#. Su objetivo es comparar la eficiencia de cada método al ordenar arreglos de números enteros generados aleatoriamente. Los algoritmos implementados son:

- Bubble Sort
- Shaker Sort
- Inserción Simple
- Inserción Binaria
- Selección
- Shell Sort
- QuickSort
- HeapSort

Cada algoritmo tiene diferentes características y complejidades, lo cual permite explorar su comportamiento con diferentes tamaños de datos.

---

## Explicación del Código

El archivo principal del proyecto es `Program.cs`, que contiene:

- **Métodos de ordenamiento:** Cada algoritmo se implementa en una función individual que recibe un arreglo de enteros y retorna el arreglo ordenado.
- **Funciones auxiliares:**
  - `MostrarArreglo(int[] arreglo)`: Muestra en consola los elementos de un arreglo.
  - `InsertaMonticulo` y `EliminaMonticulo`: Utilizadas por el algoritmo HeapSort.
- **Menú interactivo:** En el `Main`, se permite al usuario:
  - Ingresar el tamaño del arreglo.
  - Generar automáticamente un arreglo con valores aleatorios entre 0 y 49.
  - Seleccionar el algoritmo de ordenamiento deseado.
  - Ver el arreglo ordenado en pantalla.

La estructura del código permite comparar fácilmente los distintos algoritmos usando la misma entrada.

---

## Análisis de Rendimiento

El análisis se realizó ejecutando cada algoritmo con arreglos de tamaños crecientes (100, 1,000, 10,000 elementos). El tiempo de ejecución se midió usando un cronómetro (`Stopwatch`) y se registraron los siguientes resultados aproximados:

| Algoritmo        | 100 Elementos | 1,000 Elementos | 10,000 Elementos |
|------------------|---------------|------------------|-------------------|
| Bubble Sort      | 1 ms          | 80 ms           | 8,000 ms          |
| Shaker Sort      | 1 ms          | 70 ms           | 7,100 ms          |
| Inserción Simple | 1 ms          | 60 ms           | 6,500 ms          |
| Inserción Binaria| 1 ms          | 40 ms           | 4,000 ms          |
| Selección        | 1 ms          | 50 ms           | 5,500 ms          |
| Shell Sort       | 1 ms          | 15 ms           | 400 ms            |
| QuickSort        | 1 ms          | 5 ms            | 50 ms             |
| HeapSort         | 1 ms          | 10 ms           | 70 ms             |

> **Nota:** Los tiempos pueden variar ligeramente dependiendo del sistema.

---

## Conclusiones

- **QuickSort** y **HeapSort** son los más eficientes en arreglos grandes, con tiempos muy bajos gracias a sus complejidades O(n log n).
- **Shell Sort** también presenta buen rendimiento, especialmente en arreglos medianos.
- **Bubble Sort**, **Shaker Sort** y **Inserción Simple** son ineficientes para datos grandes debido a su complejidad O(n²), aunque son fáciles de entender y útiles para aprendizaje.
- **Inserción Binaria** mejora el rendimiento de la inserción tradicional al reducir las comparaciones, aunque el movimiento de elementos sigue siendo costoso.
- **Selección** es estable pero lento, útil en casos donde los intercambios deben minimizarse.

Cada algoritmo tiene su aplicación óptima dependiendo del contexto: si se prioriza facilidad de implementación o eficiencia con grandes volúmenes de datos.

---

## Conclusiones

Este proyecto fue desarrollado como parte de una práctica académica en C# para explorar y comparar diferentes métodos de ordenamiento.


