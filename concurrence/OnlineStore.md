# Sistema de Procesamiento de Pedidos de Tienda en Línea

Este código en C# simula un sistema de procesamiento de pedidos para una tienda en línea, donde los pedidos son procesados en paralelo.

## Descripción del Código

### Clase Principal
- `OnlineStore`: Clase principal que contiene el método `Main` y el método `ProcessOrder`.

### Método Main
1. Se imprime un mensaje de bienvenida al sistema de procesamiento de pedidos de la tienda en línea.
2. Se define el número de pedidos a procesar.
3. Se crean y ejecutan tareas en paralelo para procesar cada pedido.
4. Se espera a que todas las tareas se completen.
5. Se imprime un mensaje indicando que todos los pedidos han sido procesados.

### Método ProcessOrder
- `ProcessOrder(int orderNumber)`: Simula el procesamiento de un pedido. Imprime mensajes indicando que un cliente está realizando un pedido y que el pedido ha sido procesado.

## Diagrama de Secuencia

Aquí se generará un diagrama de secuencia para representar visualmente cómo funciona este código en la máquina.

![Sistema de Procesamiento de Pedidos de Tienda en Línea](https://showme.redstarplugin.com/d/d:FXzYRabF)

