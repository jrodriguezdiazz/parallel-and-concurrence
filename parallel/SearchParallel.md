# Búsqueda Paralela en CSV

Este código en C# realiza una búsqueda paralela de términos en un archivo CSV y muestra los resultados.

## Descripción del Código

### Clases Principales
- `SearchParallel`: Clase principal que contiene el método `Main` y otros métodos para la búsqueda paralela.
- `Item`: Representa un ítem en el archivo CSV con propiedades como `ItemCode`, `ItemName`, `CategoryCode`, y `CategoryName`.

### Método Main
1. Se inicia el método `Foo` que contiene la lógica principal del programa.

### Método Foo
1. Se imprime un mensaje indicando que es un ejemplo de búsqueda paralela en CSV.
2. Se lee el archivo CSV y se almacena la data en una lista de objetos `Item`.
3. Se realiza una búsqueda paralela con un término de búsqueda específico.
4. Se imprimen los resultados de la búsqueda.

### Métodos Adicionales
- `ReadCsvAsync(string filePath)`: Lee el archivo CSV y retorna una lista de objetos `Item`.
- `ParallelSearchAsync(List<Item> items, string searchTerm)`: Realiza una búsqueda paralela en la lista de ítems y retorna los resultados.

## Diagrama de Secuencia

Aquí se generará un diagrama de secuencia para representar visualmente cómo funciona este código en la máquina.

![Búsqueda Paralela en CSV](https://showme.redstarplugin.com/d/d:DGF08mg0)

