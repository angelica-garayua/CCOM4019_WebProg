# 📘 Sistema de Pagos - Angelica Garayua Services
> **Versión:** 1.0.0 | **Tecnología:** .NET 10 / C# 14 | **Tipo:** Console App
Aplicación moderna para la gestión de pagos de empleados temporales (Analistas y Programadores).
El sistema automatiza el cálculo de salarios netos, aplicando deducciones de ley, impuestos
federales y tarifas de agencia basándose en reglas de negocio espec íficas.
---
## 🚀 Características Principales
* **Cálculo Automatizado:** Procesa Salario Bruto, Seguro Social, Impuestos y Tarifas.
* **Reglas de Negocio:**
 * Tarifa fija por hora: **$37.25**
 * Agencia no paga beneficios (salud/retiro).
 * Incentivos locales (0% impuestos locales).
* **Tecnología de Punta (C# 14):**
 * Uso de `Records` para inmutabilidad financiera.
 * `Primary Constructors` para código limpio.
 * Cálculos con tipo `decimal` para precisión monetaria.
 * Reportes con LINQ y sobrecarga de operadores.

 ## 🛠️ Instalación y Ejecución

 ### Prerequisitos
 * [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
 * Visual Studio 2026.

 ### Manual de Uso Rápido 

 El sistema cuenta con un menú interactivo en consola:

 ### 1. Agregar Empleado
 Selecciones la ***Opción 1** El sistema solicitará:
 * **Datos Personales: ** Nombre, Dirección, Teléfono.
 * **Dependientes: ** Número entre 0 y 5 (afecta el impuesto federal)
 * **Horas:** Número entre 1 y 160.
 
 > **Nota:** El sistema valida los datos automaticamente. Si ingresa un dato erróneo, se le notificará.

 ### 2. Ver Reporte Total
 Seleccione la ***Opción 2** para ver el acumulado del día.
 Muestra la suma total de lo que la empresa debe pagar (NETO), lo retenido (IMPUESTOS), y la ganancia de la agencia.

 ### Arquitectura del Código

 El proyecto sigue una estructura orientada a objetos moderna:
 |  Archivo  | Responsabilidad |
 |-----------|-----------------|
 | 'Program.cs' | **UI/Controlador** Maneja flujo del menú y la interacción con el usuario.|
 | 'StaffMember.cs' | **Clase Base** Maneja datos comunes y validaciones de entrada. |
 | 'Employee.cs' | **Lógica de negocio** Contiene las fórmulas de impuestos y genera el pago. |
 | 'Pay.cs' | **Record (DTO)** Objeto inmutable que transporta los resultados financieros. |

 ### Fórmulas de Financieras
 El cálculo de los impuestos sigue la siguiente fórmula:

 $$
 Impuesto = ((Bruto - (Bruto \times (0.0475 \times Dependientes))) \times 16.5%
 $$

 ### Licencia
 Este software es para uso privado y propiedad de Angelica Garayua Services.