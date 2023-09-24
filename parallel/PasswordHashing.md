# Sistema de Hashing de Contraseñas

Este código en C# simula un sistema de hashing de contraseñas, donde las contraseñas son hasheadas y verificadas en paralelo.

## Descripción del Código

### Clase Principal
- `PasswordHashing`: Clase principal que contiene los métodos para hashear y verificar contraseñas, y el método `Main`.

### Métodos
- `HashPassword(string password)`: Hashea una contraseña proporcionada y devuelve la contraseña hasheada.
- `VerifyPassword(string hashedPassword, string userPassword)`: Verifica si una contraseña proporcionada coincide con una contraseña hasheada almacenada.
- `Main()`: Método principal que simula el almacenamiento y la verificación de contraseñas.

### Método Main
1. Se crean y almacenan contraseñas originales en una lista `originalPasswords`.
2. Se hashean las contraseñas originales en paralelo y se almacenan en una lista `hashedPasswords`.
3. Se verifica en paralelo si una contraseña ingresada por el usuario coincide con alguna de las contraseñas hasheadas almacenadas.

### Métodos de Hashing y Verificación
- `HashPassword` genera un salt aleatorio, crea el hash de la contraseña con PBKDF2 y SHA-256, y combina el salt y el hash en una cadena base64.
- `VerifyPassword` extrae el salt y el hash de la contraseña almacenada, calcula el hash de la contraseña proporcionada y compara los hashes para verificar la contraseña.

## Diagrama de Secuencia

Aquí se generará un diagrama de secuencia para representar visualmente cómo funciona este código en la máquina.

![Sistema de Hashing de Contraseñas](https://showme.redstarplugin.com/d/d:ym7InAzd)
