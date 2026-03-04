using System;
using System.Collections.Generic;
using System.Text;

namespace AngelicaGarayuaServices
{
    // ---------------------------------------------------------
    // RECORD: Para manejar los resultados financieros (Inmutable)
    // Muestra: Records, Positional Parameters, Operator Overloading
    // ---------------------------------------------------------
    public record Pay(
     decimal GrossPay,
     decimal SocialSecurity,
     decimal FederalTax,
     decimal AgencyFee,
     decimal NetPay
    )
    {
        // Sobrecarga de operador (+): Permite sumar dos records de pago directamente
        // Ejemplo: var total = pay1 + pay2;
        public static Pay operator +(Pay a, Pay b)
        {
            return new Pay(
            a.GrossPay + b.GrossPay,
            a.SocialSecurity + b.SocialSecurity,
            a.FederalTax + b.FederalTax,
            a.AgencyFee + b.AgencyFee,
            a.NetPay + b.NetPay
            );
        }
    }
}

