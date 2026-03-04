using System;
using System.Collections.Generic;
using System.Text;

namespace AngelicaGarayuaServices
{
        // ---------------------------------------------------------
        // CLASE BASE: StaffMember
        // Muestra: Primary Constructors, Property Validation
        // ---------------------------------------------------------
        public abstract class StaffMember(string name, string address, string phone, int
       noOfDependents)
        {
            // Propiedades con validación en la inicialización (init)
            public string EmployeeName { get; } = !string.IsNullOrWhiteSpace(name)
            ? name
            : throw new ArgumentException("El nombre no puede estar vacío.");
            public string Address { get; } = !string.IsNullOrWhiteSpace(address)
            ? address
            : throw new ArgumentException("La dirección no puede estar vacía.");
            public string Phone { get; } = !string.IsNullOrWhiteSpace(phone)
            ? phone
            : throw new ArgumentException("El teléfono no puede estar vacío.");
            public int NoOfDependents { get; } = (noOfDependents >= 0 && noOfDependents <= 5)
            ? noOfDependents
            : throw new ArgumentException("El número de dependientes debe estar entre 0 y 5.");
            public DateTime DateCreated { get; } = DateTime.Now;
            public override string ToString() =>
            $"""
            Fecha Creación: {DateCreated:g}
            Nombre: {EmployeeName}
            Dirección: {Address}
            Teléfono: {Phone}
            Dependientes: {NoOfDependents}
            """;
        }

}

