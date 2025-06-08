using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Docente : Empleado
{
    public List<string> Asignaturas { get; set; } = new List<string>();
    public Dictionary<string, List<string>> HorarioClases { get; set; } = new Dictionary<string, List<string>>();
    public int HorasSemanales { get; set; }
    public List<string> GradosAcademicos { get; set; } = new List<string>();
    public double EvaluacionDocente { get; set; }
    public int EstudiantesAtendidos { get; set; }
    public List<string> PublicacionesAcademicas { get; set; } = new List<string>();

    public virtual void AsignarMateria(string materia, List<string> horarios)
    {
        if (!Asignaturas.Contains(materia))
        {
            Asignaturas.Add(materia);
        }
        HorarioClases[materia] = horarios;
        Console.WriteLine($"Materia {materia} asignada a {Nombre}");
        ActualizarHorasSemanales();
    }

    public virtual void AsignarMateria(string materia)
    {
        if (!Asignaturas.Contains(materia))
        {
            Asignaturas.Add(materia);
            Console.WriteLine($"Materia {materia} asignada a {Nombre}");
        }
    }

    public virtual void AsignarMateria(List<string> materias)
    {
        foreach (string materia in materias)
        {
            AsignarMateria(materia);
        }
    }

    public virtual void CalificarEstudiante(Estudiante estudiante, string materia, double calificacion)
    {
        if (Asignaturas.Contains(materia))
        {
            estudiante.RegistrarCalificacion(materia, calificacion);
            Console.WriteLine($"{Nombre} calificó a {estudiante.Nombre} en {materia}: {calificacion}");
        }
        else
        {
            Console.WriteLine($"{Nombre} no está asignado a la materia {materia}");
        }
    }

    public virtual void CalificarEstudiante(List<Estudiante> estudiantes, string materia, double calificacion)
    {
        foreach (var estudiante in estudiantes)
        {
            CalificarEstudiante(estudiante, materia, calificacion);
        }
    }

    private void ActualizarHorasSemanales()
    {
        HorasSemanales = HorarioClases.Values.Sum(horarios => horarios.Count * 2); 
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Asignaturas: {string.Join(", ", Asignaturas)}");
        Console.WriteLine($"Horas semanales: {HorasSemanales}, Estudiantes atendidos: {EstudiantesAtendidos}");
        Console.WriteLine($"Evaluación docente: {EvaluacionDocente:F2}");
        if (GradosAcademicos.Any())
        {
            Console.WriteLine($"Grados académicos: {string.Join(", ", GradosAcademicos)}");
        }
        if (PublicacionesAcademicas.Any())
        {
            Console.WriteLine($"Publicaciones: {PublicacionesAcademicas.Count} artículos");
        }
    }

    public void AgregarPublicacion(string publicacion)
    {
        PublicacionesAcademicas.Add(publicacion);
        Console.WriteLine($"Publicación agregada a {Nombre}: {publicacion}");
    }

    public void ActualizarEvaluacion(double nuevaEvaluacion)
    {
        EvaluacionDocente = nuevaEvaluacion;
        Console.WriteLine($"Evaluación docente actualizada para {Nombre}: {nuevaEvaluacion:F2}");
    }
}
