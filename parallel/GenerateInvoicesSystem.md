# Sistema de Generación de Facturas

Este código simula el cálculo de facturas en un sistema de facturación utilizando paralelismo en C#.

## Descripción del Código

### Clases Principales
- `GenerateInvoicesSystem`: Clase principal que contiene el método `Main`.
- `Invoice`: Representa una factura con ítems.
- `InvoiceItem`: Representa un ítem en una factura.

### Método Main
1. Se imprime un mensaje de simulación de cálculo de facturas.
2. Se generan 100 facturas de ejemplo con `GenerateInvoices(100)`.
3. Las facturas se dividen en lotes para el cálculo paralelo.
4. Se calcula el total de cada lote en paralelo con `Parallel.ForEach`.
5. Se imprime un mensaje indicando que el cálculo de las facturas se ha completado.
6. Se muestran los detalles de algunas facturas como ejemplos.

### Métodos Adicionales
- `GenerateInvoices(int count)`: Genera una lista de facturas de ejemplo con ítems.
- `PartitionInvoices(List<Invoice> invoices, int batchSize)`: Divide una lista de facturas en lotes.
- `CalculateBatchTotal(List<Invoice> batch)`: Calcula el total para un lote de facturas.

## Diagrama de Secuencia

Aquí está el diagrama de secuencia que representa cómo funciona este código en la máquina:

![Sistema de Generación de Facturas](https://showme.redstarplugin.com/d/d:mLcuYqTy)
