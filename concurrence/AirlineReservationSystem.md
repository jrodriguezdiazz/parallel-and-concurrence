# Sistema de Reservación de Aerolínea

Este código en C# simula un sistema de reservación de aerolínea, donde los pasajeros hacen reservaciones en paralelo para vuelos disponibles.

## Descripción del Código

### Clase Principal

- `AirlineReservationSystem`: Clase principal que contiene el método `Main` y el método `MakeReservation`.

### Método Main

1. Se imprime un mensaje de bienvenida al sistema de reservación de aerolínea y se muestran los vuelos disponibles.
2. Se define el número de pasajeros haciendo reservaciones.
3. Se crean y ejecutan tareas en paralelo para cada reservación.
4. Se espera a que todas las tareas se completen.
5. Se imprime un mensaje indicando que todas las reservaciones están completas.

### Método MakeReservation

- `MakeReservation(int passengerNumber)`: Simula el proceso de hacer una reservación. Se selecciona un vuelo disponible y se simula el proceso de reservación para un pasajero.

## Diagrama de Secuencia

Aquí se generará un diagrama de secuencia para representar visualmente cómo funciona este código en la máquina.

![Sistema de Reservación de Aerolínea](https://showme.redstarplugin.com/d/d:V3Xljagi)
