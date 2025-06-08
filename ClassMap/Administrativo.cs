using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Administrativo : Empleado
{
    public string AreaResponsabilidad { get; set; }
    public List<string> SoftwareManejado { get; set; } = new List<string>();
    public bool TieneAccesoSistemas { get; set; }
    public int NivelAcceso { get; set; } // 1=Básico, 2=Intermedio, 3=Avanzado
    public List<string> TareasAsignadas { get; set; } = new List<string>();

    public override string ObtenerRol() => "Administrativo";

    public override double CalcularDescuento()
    {
        double antiguedad = CalcularAntiguedad();
        double descuento = 0.10; // Base 10%

        if (antiguedad >= 10) descuento = 0.25;
        else if (antiguedad >= 5) descuento = 0.15;

        if (NivelAcceso >= 3) descuento += 0.05; // Bonus por alto nivel

        return Math.Min(descuento, 0.30);
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Área: {AreaResponsabilidad}, Nivel Acceso: {NivelAcceso}");
        Console.WriteLine($"Acceso Sistemas: {(TieneAccesoSistemas ? "Sí" : "No")}");
        if (SoftwareManejado.Any())
        {
            Console.WriteLine($"Software: {string.Join(", ", SoftwareManejado)}");
        }
        if (TareasAsignadas.Any())
        {
            Console.WriteLine($"Tareas: {string.Join(", ", TareasAsignadas)}");
        }
    }

    public void MostrarInformacion(string area)
    {
        if (AreaResponsabilidad.Equals(area, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Administrativo del área {area}: {Nombre}");
            Console.WriteLine($"Nivel de acceso: {NivelAcceso}");
            Console.WriteLine($"Tareas: {string.Join(", ", TareasAsignadas)}");
        }
    }

    public void AsignarAccesoSistema(bool acceso, int nivel = 1)
    {
        TieneAccesoSistemas = acceso;
        if (acceso)
        {
            NivelAcceso = nivel;
            Console.WriteLine($"Acceso nivel {nivel} concedido a {Nombre}");
        }
        else
        {
            NivelAcceso = 0;
            Console.WriteLine($"Acceso revocado para {Nombre}");
        }
    }

    public void AsignarTarea(string tarea)
    {
        TareasAsignadas.Add(tarea);
        Console.WriteLine($"Tarea asignada a {Nombre}: {tarea}");
    }

    public void AsignarTarea(List<string> tareas)
    {
        foreach (string tarea in tareas)
        {
            AsignarTarea(tarea);
        }
    }

    public void CompletarTarea(string tarea)
    {
        if (TareasAsignadas.Remove(tarea))
        {
            Console.WriteLine($"{Nombre} completó la tarea: {tarea}");
        }
        else
        {
            Console.WriteLine($"Tarea no encontrada: {tarea}");
        }
    }
}
