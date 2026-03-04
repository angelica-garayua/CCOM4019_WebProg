// ---------------------------------------------------------
// PROGRAMA PRINCIPAL
// Muestra: Top-level statements, Pattern Matching, Switch Expressions
// ---------------------------------------------------------

// Configuración para mostrar moneda correctamente ($)
using AngelicaGarayuaServices;
using System.Collections.Generic;
using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;
CultureInfo.CurrentCulture = new CultureInfo("en-US");
List<Employee> employees = new();
bool keepRunning = true;
Console.WriteLine("=== SISTEMA DE PAGOS: NOMBRE APELLIDO SERVICES ===");
while (keepRunning)
{
    Console.WriteLine("\nSeleccione una opción:");
    Console.WriteLine("1. Agregar Empleado y Calcular");
    Console.WriteLine("2. Ver Reporte Total (Suma de pagos)");
    Console.WriteLine("3. Salir");
    Console.Write("> ");
    var input = Console.ReadLine();
    // Modern Switch Expression para controlar el flujo
    string statusMessage = input switch
    {
        "1" => ProcessNewEmployee(employees),
        "2" => ShowTotalReport(employees),
        "3" => ExitApp(out keepRunning),
        _ => "Opción no válida."
    };
    Console.WriteLine($"\n>> {statusMessage}");
}
// Método estático local para procesar entrada
static string ProcessNewEmployee(List<Employee> list)
{
    try
    {
        Console.WriteLine("\n--- Ingrese Datos del Empleado ---");
        Console.Write("Nombre: ");
        string name = Console.ReadLine() ?? "Desconocido"; // Null coalescing
        Console.Write("Dirección: ");
        string address = Console.ReadLine() ?? "Sin dirección";
        Console.Write("Teléfono: ");
        string phone = Console.ReadLine() ?? "N/A";
        Console.Write("Dependientes (0-5): ");
        // Int32.TryParse moderno en línea
        if (!int.TryParse(Console.ReadLine(), out int deps)) deps = 0;
        Console.Write("Horas Trabajadas (1-160): ");
        if (!int.TryParse(Console.ReadLine(), out int hours)) hours = 0;
        // Instanciación usando Constructor Primario
        var emp = new Employee(name, address, phone, deps, hours);
        list.Add(emp);
        Console.WriteLine("\n--- Resultado Individual ---");
        Console.WriteLine(emp.ToString());
        return "Empleado procesado exitosamente.";
    }
    catch (ArgumentException ex)
    {
        return $"Error de validación: {ex.Message}";
    }
    catch (Exception ex)
    {
        return $"Error inesperado: {ex.Message}";
    }
}

static string ShowTotalReport(List<Employee> list)
 {
 if (list.Count == 0) return "No hay empleados registrados.";
// Uso de LINQ y la sobrecarga de operadores (+) en PaySlip
// Agregamos (sumamos) todos los PaySlips empezando desde cero
var totalPayroll = list
.Select(e => e.CalculatePayroll())
.Aggregate(new Pay(0, 0, 0, 0, 0), (acc, next) => acc + next);
Console.WriteLine("\n========================================");
Console.WriteLine(" REPORTE CONSOLIDADO DE LA EMPRESA");
Console.WriteLine("========================================");
Console.WriteLine($"Total Empleados: {list.Count}");
Console.WriteLine($"Total Bruto: {totalPayroll.GrossPay:C2}");
Console.WriteLine($"Total SS: {totalPayroll.SocialSecurity:C2}");
Console.WriteLine($"Total Fees: {totalPayroll.AgencyFee:C2}");
Console.WriteLine($"Total Neto: {totalPayroll.NetPay:C2}");
return "Reporte generado.";
 }
 static string ExitApp(out bool runState)
{
    runState = false;
    return "Cerrando sistema...";
}
