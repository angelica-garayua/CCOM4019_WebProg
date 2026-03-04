using System;
using System.Collections.Generic;
using System.Text;

namespace AngelicaGarayuaServices
{
    // ---------------------------------------------------------
    // CLASE DERIVADA: Employee
    // Muestra: Herencia con Primary Constructors, Constantes, Lógica Financiera
    // ---------------------------------------------------------
    public class Employee(string name, string address, string phone, int noOfDependents, int
   hours)
    : StaffMember(name, address, phone, noOfDependents)
    {
        // Constantes de negocio (usando decimal para precisión financiera)
        private const decimal HOURLY_RATE = 37.25m;
        private const decimal FEDERAL_TAX_RATE = 0.165m;
        private const decimal SOCIAL_SECURITY_RATE = 0.095m;
        private const decimal AGENCY_CHARGE_RATE = 0.1225m;
        private const decimal DEPENDENT_ALLOWANCE_RATE = 0.0475m;
        // Validación de horas en propiedad
        public int Hours { get; } = (hours > 0 && hours <= 160)
        ? hours
        : throw new ArgumentException("Las horas deben ser entre 1 y 160.");
        // Método para calcular y generar el Record (PaySlip)
        // Usamos 'Expression Body' (=>) para limpieza
        public Pay CalculatePayroll()
        {
            decimal grossPay = Hours * HOURLY_RATE;
            decimal socialSecurity = grossPay * SOCIAL_SECURITY_RATE;
            decimal agencyFee = grossPay * AGENCY_CHARGE_RATE;
            // Cálculo de impuesto federal con descuento por dependientes
            // Lógica original: (gross - (gross * (0.0475 * deps))) * 0.165
            decimal taxableAmount = grossPay - (grossPay * (DEPENDENT_ALLOWANCE_RATE *
           NoOfDependents));
            // Math.Max(0, ...) asegura que no cobremos impuestos negativos si tiene muchos dependientes(seguridad)
        decimal federalTax = Math.Max(0, taxableAmount * FEDERAL_TAX_RATE);
            decimal netPay = grossPay - socialSecurity - federalTax - agencyFee;
            return new Pay(grossPay, socialSecurity, federalTax, agencyFee, netPay);
        }
        public override string ToString()
        {
            var slip = CalculatePayroll();
            // Uso de Raw String Literals (""") para formato multilinea limpio
            return $"""
            {base.ToString()}
            ----------------------------------
            DETALLE DE PAGO (Horas: {Hours})
            Pago Bruto: {slip.GrossPay:C2}
            Seguro Social: {slip.SocialSecurity:C2}
            Impuesto Fed: {slip.FederalTax:C2}
            Tarifa Agencia: {slip.AgencyFee:C2}
            ----------------------------------
            PAGO NETO: {slip.NetPay:C2}
            """;
        }

    }
}

