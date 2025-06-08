using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Estudiante : MiembroDeLaComunidad
{
    public string Carrera { get; set; }
    public int Semestre { get; set; }
    public double PromedioGeneral { get; set; }
    public List<string> MateriasInscritas { get; set; } = new List<string>();
    public Dictionary<string, double> Calificaciones { get; set; } = new Dictionary<string, double>();
    public string CodigoEstudiante { get; set; }
    public DateTime FechaInscripcion { get; set; }
    public bool BecaActiva { get; set; }

    public Estudiante()
    {
        CodigoEstudiante = $"EST{Id:D6}";
        FechaInscripcion = DateTime.Now;
    }

    public override string ObtenerRol() => "Estudiante";

    public override double CalcularDescuento()
    {
        double descuento = 0.05; // Base 5%
        if (PromedioGeneral >= 9.0) descuento = 0.20; // 20% para excelencia
        else if (PromedioGeneral >= 8.0) descuento = 0.10; // 10% para buen rendimiento

        if (BecaActiva) descuento += 0.05; // 5% adicional por beca

        return Math.Min(descuento, 0.25); // Máximo 25%
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Código: {CodigoEstudiante}, Carrera: {Carrera}, Semestre: {Semestre}");
        Console.WriteLine($"Promedio: {PromedioGeneral:F2}, Beca: {(BecaActiva ? "Activa" : "No")}");
        Console.WriteLine($"Materias inscritas: {string.Join(", ", MateriasInscritas)}");
        Console.WriteLine($"Fecha inscripción: {FechaInscripcion:yyyy-MM-dd}");
    }

    public void MostrarInformacion(bool incluirCalificaciones, bool incluirMaterias)
    {
        base.MostrarInformacion();
        Console.WriteLine($"Carrera: {Carrera}, Semestre: {Semestre}, Promedio: {PromedioGeneral:F2}");

        if (incluirMaterias && MateriasInscritas.Any())
        {
            Console.WriteLine($"Materias: {string.Join(", ", MateriasInscritas)}");
        }

        if (incluirCalificaciones && Calificaciones.Any())
        {
            Console.WriteLine("Calificaciones:");
            foreach (var cal in Calificaciones)
            {
                Console.WriteLine($"  {cal.Key}: {cal.Value:F2}");
            }
        }
    }

    public void InscribirMateria(string materia)
    {
        if (!MateriasInscritas.Contains(materia))
        {
            MateriasInscritas.Add(materia);
            Console.WriteLine($"Materia {materia} inscrita para {Nombre}");
        }
        else
        {
            Console.WriteLine($"{Nombre} ya está inscrito en {materia}");
        }
    }

    public void InscribirMateria(List<string> materias)
    {
        foreach (string materia in materias)
        {
            InscribirMateria(materia);
        }
    }

    public void RegistrarCalificacion(string materia, double calificacion)
    {
        if (MateriasInscritas.Contains(materia))
        {
            Calificaciones[materia] = calificacion;
            ActualizarPromedio();
            Console.WriteLine($"Calificación registrada: {materia} = {calificacion:F2}");
        }
        else
        {
            Console.WriteLine($"{Nombre} no está inscrito en {materia}");
        }
    }

    private void ActualizarPromedio()
    {
        if (Calificaciones.Any())
        {
            PromedioGeneral = Calificaciones.Values.Average();
        }
    }

    public void ActivarBeca(bool activar)
    {
        BecaActiva = activar;
        Console.WriteLine($"Beca {(activar ? "activada" : "desactivada")} para {Nombre}");
    }

    public List<string> ObtenerMateriasAprobadas()
    {
        return Calificaciones.Where(c => c.Value >= 6.0).Select(c => c.Key).ToList();
    }
}
