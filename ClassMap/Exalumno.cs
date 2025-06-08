using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExAlumno : MiembroDeLaComunidad
{
    public int AñoGraduacion { get; set; }
    public string CarreraGraduada { get; set; }
    public string EmpresaActual { get; set; }
    public string PuestoActual { get; set; }
    public bool MiembroAsociacion { get; set; }
    public List<string> Logros { get; set; } = new List<string>();
    public double SalarioActual { get; set; }
    public string CiudadResidencia { get; set; }
    public List<string> CertificacionesProfesionales { get; set; } = new List<string>();

    public override string ObtenerRol() => "Ex-Alumno";

    public override double CalcularDescuento()
    {
        int añosGraduado = DateTime.Now.Year - AñoGraduacion;
        double descuento = 0.15; 

        if (MiembroAsociacion) descuento += 0.05; 
        if (añosGraduado <= 5) descuento += 0.05; 
        if (añosGraduado >= 20) descuento += 0.10; 

        return Math.Min(descuento, 0.35); 
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Graduado en: {AñoGraduacion}, Carrera: {CarreraGraduada}");
        Console.WriteLine($"Empresa: {EmpresaActual}, Puesto: {PuestoActual}");
        Console.WriteLine($"Ciudad: {CiudadResidencia}, Salario: ${SalarioActual:N2}");
        Console.WriteLine($"Miembro Asociación: {(MiembroAsociacion ? "Sí" : "No")}");
        if (Logros.Any())
        {
            Console.WriteLine($"Logros: {string.Join(", ", Logros)}");
        }
        if (CertificacionesProfesionales.Any())
        {
            Console.WriteLine($"Certificaciones: {string.Join(", ", CertificacionesProfesionales)}");
        }
    }

    public void MostrarInformacion(bool soloProfesional)
    {
        if (soloProfesional)
        {
            Console.WriteLine($"Ex-Alumno: {Nombre} ({AñoGraduacion})");
            Console.WriteLine($"Carrera: {CarreraGraduada}");
            Console.WriteLine($"Trabajo actual: {PuestoActual} en {EmpresaActual}");
            Console.WriteLine($"Salario: ${SalarioActual:N2}");
        }
        else
        {
            MostrarInformacion();
        }
    }

    public void ActualizarInformacionLaboral(string empresa, string puesto)
    {
        EmpresaActual = empresa;
        PuestoActual = puesto;
        Console.WriteLine($"Información laboral actualizada para {Nombre}");
    }

    public void ActualizarInformacionLaboral(string empresa, string puesto, double salario)
    {
        ActualizarInformacionLaboral(empresa, puesto);
        SalarioActual = salario;
        Console.WriteLine($"Salario actualizado: ${salario:N2}");
    }

    public void AgregarLogro(string logro)
    {
        Logros.Add(logro);
        Console.WriteLine($"Logro agregado para {Nombre}: {logro}");
    }

    public void AgregarCertificacion(string certificacion)
    {
        CertificacionesProfesionales.Add(certificacion);
        Console.WriteLine($"Certificación agregada para {Nombre}: {certificacion}");
    }

    public int CalcularExperienciaProfesional()
    {
        return DateTime.Now.Year - AñoGraduacion;
    }
}
