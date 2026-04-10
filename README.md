# Proyecto 1 -Arreglos Paginados

Proyecto desarrollado en C++ para el curso **Algoritmos y Estructuras de Datos II (CE 1103)** del **ITCR**.

La solución implementa una clase `PagedArray` que permite trabajar con arreglos grandes almacenados en disco, cargando en memoria únicamente un número limitado de páginas a la vez. Sobre esta estructura se ejecutan distintos algoritmos de ordenamiento, manteniendo encapsulada toda la lógica de paginación.

## Descripción general

El proyecto está compuesto por dos programas principales: `generator`, encargado de generar archivos binarios con números enteros aleatorios, y `sorter`, encargado de ordenar archivos binarios utilizando la clase `PagedArray`, sin modificar el archivo original de entrada. El archivo primero se copia a una ruta de salida y sobre esa copia se realiza el ordenamiento. Además, al finalizar la ejecución, `sorter` genera una versión en texto del archivo ordenado para facilitar la verificación de correctitud.

## Estructura del repositorio

Este repositorio incluye los siguientes archivos fuente:

~~~text
generator.cpp
sorter.cpp
PagedArray.hpp
PagedArray.cpp
algoritmos_ordenamiento.hpp
algoritmos_ordenamiento.cpp
README.md
~~~

## Requisitos

Para compilar y ejecutar el proyecto se necesita `g++`, soporte para **C++11** o superior, terminal o consola, y permisos de lectura y escritura sobre los archivos utilizados.

## Compilación

Para compilar el generador:

~~~bash
g++ generator.cpp -o generator
~~~

Para compilar el sorter:

~~~bash
g++ sorter.cpp PagedArray.cpp algoritmos_ordenamiento.cpp -o sorter
~~~

## Uso del generador

El generador crea un archivo binario con enteros aleatorios.

Sintaxis:

~~~bash
./generator -size <SIZE> -output <OUTPUT_FILE_PATH>
~~~

Parámetros:

- `-size`: tamaño del archivo a generar
- `-output`: ruta del archivo binario de salida

Tamaños soportados:

- `SMALL` para 32 Mb
- `MEDIUM` para 64 Mb
- `LARGE` para 128 Mb

Ejemplo de uso:

~~~bash
./generator -size SMALL -output entrada.bin
~~~

Este comando genera un archivo binario llamado `entrada.bin` con números enteros aleatorios.

## Uso del sorter

El programa `sorter` recibe un archivo binario de entrada, lo copia a un archivo de salida y ejecuta el ordenamiento sobre esa copia usando `PagedArray`.

Sintaxis:

~~~bash
./sorter -input <INPUT_FILE_PATH> -output <OUTPUT_FILE_PATH> -alg <ALGORITMO> -pageSize <PAGE_SIZE> -pageCount <PAGE_COUNT>
~~~

Parámetros:

- `-input`: ruta del archivo binario de entrada
- `-output`: ruta del archivo binario de salida
- `-alg`: algoritmo de ordenamiento a utilizar
- `-pageSize`: tamaño de página en bytes
- `-pageCount`: cantidad de páginas que se mantienen en memoria

Restricciones de uso:

- `pageSize` debe ser múltiplo de 2
- el archivo de entrada no se modifica
- el ordenamiento se realiza sobre el archivo indicado en `-output`
- para efectos del proyecto se estandarizó un `pageCount` de 4 

## Algoritmos soportados

El proyecto incluye soporte para los siguientes algoritmos de ordenamiento:

- `MERGE` para Natural MergeSort
- `QUICK` para Quicksort
- `DUALQ` para Dual Pivot Quicksort
- `THREEWAY` para 3-Way quicksort
- `INTRO` para Introsort

Ejemplo de uso:

~~~bash
./sorter -input entrada.bin -output salida.bin -alg QUICK -pageSize 65536 -pageCount 4
~~~

## Funcionamiento de `PagedArray`

La clase `PagedArray` encapsula la lógica de administración de páginas para que los algoritmos de ordenamiento puedan trabajar con una interfaz similar a la de un arreglo tradicional.

Características principales:

- sobrecarga del operador `[]`
- acceso transparente a elementos del arreglo
- carga de páginas desde disco cuando no están en memoria
- escritura de páginas modificadas al disco
- conteo de `page hits` y `page faults`
- reemplazo de páginas cuando no hay espacio disponible en memoria

De esta forma, los algoritmos de ordenamiento no necesitan conocer detalles internos de la paginación y pueden operar sobre `PagedArray` como si fuera un arreglo normal.

## Salida generada por `sorter`

Al finalizar la ejecución, el programa produce lo siguiente.

### 1. Archivo binario ordenado

Se guarda en la ruta especificada en `-output`.

### 2. Archivo de texto legible

Se genera automáticamente un archivo de texto con los enteros ordenados y separados por comas.

El nombre generado sigue este formato:

~~~text
<OUTPUT_FILE_PATH>.txt
~~~

Por ejemplo, si el archivo de salida es:

~~~text
salida.bin
~~~

también se genera:

~~~text
salida.bin.txt
~~~

### 3. Resumen en consola

El programa imprime un resumen con información como:

- algoritmo utilizado
- tamaño del archivo
- tamaño de página
- cantidad de páginas en memoria
- tiempo de ordenamiento
- tiempo de exportación a texto
- cantidad de page hits
- cantidad de page faults

## Ejemplo completo de ejecución

Paso 1: compilar

~~~bash
g++ generator.cpp -o generator
g++ sorter.cpp PagedArray.cpp algoritmos_ordenamiento.cpp -o sorter
~~~

Paso 2: generar un archivo de prueba

~~~bash
./generator -size SMALL -output entrada.bin
~~~

Paso 3: ordenar el archivo

~~~bash
./sorter -input entrada.bin -output salida.bin -alg INTRO -pageSize 65536 -pageCount 4
~~~

Paso 4: revisar la salida

Archivos generados:

~~~text
entrada.bin
salida.bin
salida.bin.txt
~~~

## Observaciones finales

- `generator` produce archivos binarios puros, no texto
- `sorter` copia el archivo de entrada antes de ordenarlo
- la lógica de paginación está completamente encapsulada dentro de `PagedArray`
- los algoritmos de ordenamiento operan sobre `PagedArray` como si fuera un arreglo normal
- se pueden realizar pruebas variando el tamaño de página y la cantidad de páginas en memoria para analizar el comportamiento en page hits y page faults

## Autor

**Nombre:** Olman Alonso SIbaja Ramos  
**Curso:** Algoritmos y Estructuras de Datos II (CE 1103)  
**Institución:** Instituto Tecnológico de Costa Rica  
**Semestre:** I Semestre 2026
