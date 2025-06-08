using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Maestro : Docente
{
    public int GruposAsignados { get; set; }
    public List<string> TecnicasEnsenanza { get; set; } = new List<string>();
    public bool TutorPersonalizado { get; set; }
    public Dictionary<string, DateTime> TutoriasAgendadas { get; set; } = new Dictionary<string, DateTime>();
    public int HorasTutoria { get; set; }

    public override string ObtenerRol() => "Maestro";

    public override double CalcularDescuento()
    {
        double descuento = 0.12; 
        if (EvaluacionDocente >= 4.5) descuento += 0.08;
        if (CalcularAntiguedad() >= 5) descuento += 0.05;
        if (TutorPersonalizado) descuento += 0.03;
        return Math.Min(descuento, 0.28);
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Grupos asignados: {GruposAsignados}, Horas tutoría: {HorasTutoria}");
        Console.WriteLine($"Tutor personalizado: {(TutorPersonalizado ? "Sí" : "No")}");
        if (TecnicasEnsenanza.Any())
        {
            Console.WriteLine($"Técnicas de enseñanza: {string.Join(", ", TecnicasEnsenanza)}");
        }
        if (TutoriasAgendadas.Any())
        {
            Console.WriteLine($"Tutorías agendadas: {TutoriasAgendadas.Count}");
        }
    }

    public void MostrarInformacion(bool mostrarTutorias)
    {
        MostrarInformacion();
        if (mostrarTutorias && TutoriasAgendadas.Any())
        {
            Console.WriteLine("Próximas tutorías:");
            foreach (var tutoria in TutoriasAgendadas)
            {
                Console.WriteLine($"  {tutoria.Key}: {tutoria.Value:yyyy-MM-dd HH:mm}");
            }
        }
    }

    public void ProgramarTutoria(string estudianteNombre, DateTime fecha)
    {
        if (TutorPersonalizado)
        {
            TutoriasAgendadas[estudianteNombre] = fecha;
            Console.WriteLine($"Tutoría programada: {Nombre} con {estudianteNombre} el {fecha:yyyy-MM-dd HH:mm}");
        }
        else
        {
            Console.WriteLine($"{Nombre} no ofrece tutorías personalizadas");
        }
    }

    public void ProgramarTutoria(string estudianteNombre, DateTime fecha, int duracionMinutos)
    {
        ProgramarTutoria(estudianteNombre, fecha);
        Console.WriteLine($"Duración programada: {duracionMinutos} minutos");
    }

    public void AgregarTecnicaEnsenanza(string tecnica)
    {
        TecnicasEnsenanza.Add(tecnica);
        Console.WriteLine($"Técnica de enseñanza agregada a {Nombre}: {tecnica}");
    }

    public void CompletarTutoria(string estudianteNombre)
    {
        if (TutoriasAgendadas.Remove(estudianteNombre))
        {
            HorasTutoria++;
            Console.WriteLine($"Tutoría completada con {estudianteNombre}");
        }
    }
}

