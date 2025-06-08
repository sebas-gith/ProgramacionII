using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Empleado : MiembroDeLaComunidad
{
    public string Departamento { get; set; }
    public DateTime FechaContratacion { get; set; }
    public double Salario { get; set; }
    public string NumeroEmpleado { get; set; }
    public List<string> Certificaciones { get; set; } = new List<string>();
    public int DiasVacaciones { get; set; }
    public int DiasVacacionesTomados { get; set; }
    public string Supervisor { get; set; }
    public List<string> Capacitaciones { get; set; } = new List<string>();

    protected Empleado()
    {
        FechaContratacion = DateTime.Now;
        NumeroEmpleado = $"EMP{Id:D6}";
        DiasVacaciones = 20;
    }

    public virtual double CalcularAntiguedad()
    {
        return (DateTime.Now - FechaContratacion).TotalDays / 365.25;
    }

    public virtual void TomarVacaciones(int dias)
    {
        if (DiasVacacionesTomados + dias <= DiasVacaciones)
        {
            DiasVacacionesTomados += dias;
            Console.WriteLine($"{Nombre} tomó {dias} días de vacaciones");
        }
        else
        {
            Console.WriteLine($"No hay suficientes días de vacaciones disponibles para {Nombre}");
        }
    }

    public virtual void TomarVacaciones(int dias, DateTime fechaInicio)
    {
        TomarVacaciones(dias);
        Console.WriteLine($"Vacaciones programadas desde: {fechaInicio:yyyy-MM-dd}");
    }

    public virtual void AumentarSalario(double porcentaje)
    {
        double salarioAnterior = Salario;
        Salario += Salario * (porcentaje / 100);
        Console.WriteLine($"Salario de {Nombre} aumentado {porcentaje}%: ${salarioAnterior:N2} → ${Salario:N2}");
    }

    public virtual void AumentarSalario(double monto, bool esMontoFijo)
    {
        if (esMontoFijo)
        {
            double salarioAnterior = Salario;
            Salario += monto;
            Console.WriteLine($"Aumento fijo aplicado a {Nombre}: ${salarioAnterior:N2} → ${Salario:N2}");
        }
        else
        {
            AumentarSalario(monto); 
        }
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Departamento: {Departamento}, Empleado #: {NumeroEmpleado}");
        Console.WriteLine($"Contratación: {FechaContratacion:yyyy-MM-dd}, Antigüedad: {CalcularAntiguedad():F1} años");
        Console.WriteLine($"Salario: ${Salario:N2}, Supervisor: {Supervisor}");
        Console.WriteLine($"Vacaciones: {DiasVacacionesTomados}/{DiasVacaciones} días tomados");
        if (Certificaciones.Any())
        {
            Console.WriteLine($"Certificaciones: {string.Join(", ", Certificaciones)}");
        }
    }

    public void AgregarCertificacion(string certificacion)
    {
        Certificaciones.Add(certificacion);
        Console.WriteLine($"Certificación agregada a {Nombre}: {certificacion}");
    }

    public void CompletarCapacitacion(string capacitacion)
    {
        Capacitaciones.Add(capacitacion);
        Console.WriteLine($"{Nombre} completó la capacitación: {capacitacion}");
    }

    public int ObtenerDiasVacacionesDisponibles()
    {
        return DiasVacaciones - DiasVacacionesTomados;
    }
}
