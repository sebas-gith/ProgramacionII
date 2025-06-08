using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════");
        Console.WriteLine("SISTEMA DE GESTIÓN DE COMUNIDAD ACADÉMICA");
        Console.WriteLine("═══════════════════════════════════════════════════════════");
        Console.WriteLine();

        List<MiembroDeLaComunidad> comunidad = new List<MiembroDeLaComunidad>();

        Console.WriteLine("GESTIÓN DE ESTUDIANTES");
        Console.WriteLine();

        var estudiante1 = new Estudiante
        {
            Nombre = "Ana García",
            Email = "ana.garcia@itla.edu.do",
            Telefono = "829-323-5123",
            Carrera = "Ingeniería de Software",
            Semestre = 6,
            BecaActiva = true
        };

        var estudiante2 = new Estudiante
        {
            Nombre = "Carlos López",
            Email = "carlos.lopez@itla.edu.do",
            Telefono = "829-323-5123",
            Carrera = "Administración de Empresas",
            Semestre = 4,
            BecaActiva = false
        };

        var estudiante3 = new Estudiante
        {
            Nombre = "María Rodríguez",
            Email = "maria.rodriguez@itla.edu.do",
            Telefono = "829-323-5123",
            Carrera = "Psicología",
            Semestre = 8,
            BecaActiva = true
        };

        Console.WriteLine("Inscribiendo materias a los estudiantes...");
        estudiante1.InscribirMateria("Programación Avanzada");
        estudiante1.InscribirMateria("Base de Datos");
        estudiante1.InscribirMateria(new List<string> { "Ingeniería de Software", "Arquitectura de Software" });

        estudiante2.InscribirMateria(new List<string> { "Contabilidad", "Marketing", "Finanzas" });

        estudiante3.InscribirMateria("Psicología Clínica");
        estudiante3.InscribirMateria("Neuropsicología");

        Console.WriteLine("\nRegistrando calificaciones...");
        estudiante1.RegistrarCalificacion("Programación Avanzada", 9.5);
        estudiante1.RegistrarCalificacion("Base de Datos", 8.8);
        estudiante1.RegistrarCalificacion("Ingeniería de Software", 9.2);

        estudiante2.RegistrarCalificacion("Contabilidad", 7.5);
        estudiante2.RegistrarCalificacion("Marketing", 8.0);
        estudiante2.RegistrarCalificacion("Finanzas", 7.8);

        estudiante3.RegistrarCalificacion("Psicología Clínica", 9.0);
        estudiante3.RegistrarCalificacion("Neuropsicología", 8.5);

        comunidad.AddRange(new[] { estudiante1, estudiante2, estudiante3 });

        Console.WriteLine("\nMostrando información de estudiantes:");
        estudiante1.MostrarInformacion(true, true); // Con calificaciones y materias
        Console.WriteLine();
        estudiante2.MostrarInformacion("completo");
        Console.WriteLine();

        Console.WriteLine("GESTIÓN DE EX-ALUMNOS");
        Console.WriteLine();

        var exAlumno1 = new ExAlumno
        {
            Nombre = "Dr. Roberto Sánchez",
            Email = "roberto.sanchez@techcorp.com",
            Telefono = "829-234-5134",
            AñoGraduacion = 2022,
            CarreraGraduada = "Ingeniería de Software",
            EmpresaActual = "TechCorp Solutions",
            PuestoActual = "Arquitecto de Software Senior",
            SalarioActual = 95000,
            CiudadResidencia = "Santiago de los Caballeros",
            MiembroAsociacion = true
        };

        Console.WriteLine("Registrando logros y certificaciones...");
        exAlumno1.AgregarLogro("Mejor Proyecto de Graduación 2018");
        exAlumno1.AgregarLogro("Premio Innovación Tecnológica 2022");
        exAlumno1.AgregarCertificacion("AWS Solutions Architect");
        exAlumno1.AgregarCertificacion("Scrum Master Certified");

        Console.WriteLine("\nActualizando información laboral...");
        exAlumno1.ActualizarInformacionLaboral("TechCorp Solutions", "Director de Tecnología", 110000);

        Console.WriteLine("\nInformación de ex-alumnos:");
        exAlumno1.MostrarInformacion();
        Console.WriteLine();

        Console.WriteLine("GESTIÓN DE PERSONAL ADMINISTRATIVO");
        Console.WriteLine();

        var admin1 = new Administrativo
        {
            Nombre = "Patricia Flores",
            Email = "patricia.flores@itla.edu.do",
            Telefono = "829-555-0301",
            Departamento = "Recursos Humanos",
            Salario = 45000,
            AreaResponsabilidad = "Gestión de Personal",
            TieneAccesoSistemas = true,
            NivelAcceso = 3,
            Supervisor = "Director de RRHH"
        };

        var admin2 = new Administrativo
        {
            Nombre = "Miguel Torres",
            Email = "miguel.torres@itla.edu.do",
            Telefono = "829-555-0302",
            Departamento = "Servicios Académicos",
            Salario = 42000,
            AreaResponsabilidad = "Registro Estudiantil",
            TieneAccesoSistemas = true,
            NivelAcceso = 2,
            Supervisor = "Jefe de Servicios Académicos"
        };

        Console.WriteLine("Configurando accesos y tareas...");
        admin1.SoftwareManejado.AddRange(new[] { "SAP HR", "Microsoft Office", "Sistema Nómina" });
        admin1.AsignarTarea(new List<string>
        {
            "Proceso de nómina mensual",
            "Evaluaciones de desempeño",
            "Capacitación del personal"
        });

        admin2.SoftwareManejado.AddRange(new[] { "Sistema Estudiantil", "Office 365", "Portal Académico" });
        admin2.AsignarTarea("Registro de nuevos estudiantes");
        admin2.AsignarTarea("Generación de reportes académicos");

        Console.WriteLine("\nGestión de beneficios...");
        admin1.TomarVacaciones(5, new DateTime(2025, 7, 15));
        admin1.AumentarSalario(8.5); // Aumento porcentual

        admin2.TomarVacaciones(3);
        admin2.AumentarSalario(2000, true); // Aumento fijo

        comunidad.AddRange(new[] { admin1, admin2 });

        Console.WriteLine("\nInformación del personal administrativo:");
        admin1.MostrarInformacion();
        Console.WriteLine();
        admin2.MostrarInformacion("Servicios Académicos");
        Console.WriteLine();

        Console.WriteLine("GESTIÓN DE DOCENTES");
        Console.WriteLine();

        Console.WriteLine("DEMOSTRACIÓN DE POLIMORFISMO");
        Console.WriteLine();

        Console.WriteLine("Información básica de todos los miembros (polimorfismo):");
        foreach (var miembro in comunidad)
        {
            Console.WriteLine($"• {miembro.ObtenerInformacionBasica()} - Descuento: {miembro.CalcularDescuento():P2}");
        }

        Console.WriteLine("\nNotificaciones masivas:");
        foreach (var miembro in comunidad)
        {
            miembro.EnviarNotificacion("Reunión general de la comunidad académica", "email");
        }

        Console.WriteLine("\nDiferentes formatos de información:");
        comunidad[0].MostrarInformacion("basico");
        comunidad[1].MostrarInformacion("id");
        comunidad[2].MostrarInformacion(false); // Sin contacto

        Console.WriteLine("\nREPORTES Y ESTADÍSTICAS");
        Console.WriteLine();

        var estudiantes = comunidad.OfType<Estudiante>().ToList();
        var exAlumnos = comunidad.OfType<ExAlumno>().ToList();
        var empleados = comunidad.OfType<Empleado>().ToList();

        Console.WriteLine("Resumen de la Comunidad:");
        Console.WriteLine($"   • Total de miembros: {comunidad.Count}");
        Console.WriteLine($"   • Estudiantes activos: {estudiantes.Count}");
        Console.WriteLine($"   • Ex-alumnos registrados: {exAlumnos.Count}");
        Console.WriteLine($"   • Empleados: {empleados.Count}");

        if (estudiantes.Any())
        {
            Console.WriteLine("\nEstadísticas Estudiantiles:");
            Console.WriteLine($"   • Promedio general: {estudiantes.Average(e => e.PromedioGeneral):F2}");
            Console.WriteLine($"   • Estudiantes con beca: {estudiantes.Count(e => e.BecaActiva)}");
            Console.WriteLine($"   • Mejor estudiante: {estudiantes.OrderByDescending(e => e.PromedioGeneral).First().Nombre}");
        }

        if (exAlumnos.Any())
        {
            Console.WriteLine("\nEstadísticas de Ex-alumnos:");
            Console.WriteLine($"   • Salario promedio: ${exAlumnos.Average(e => e.SalarioActual):N2}");
            Console.WriteLine($"   • Miembros de asociación: {exAlumnos.Count(e => e.MiembroAsociacion)}");
            Console.WriteLine($"   • Experiencia promedio: {exAlumnos.Average(e => e.CalcularExperienciaProfesional()):F1} años");
        }

        if (empleados.Any())
        {
            Console.WriteLine("\nEstadísticas de Empleados:");
            Console.WriteLine($"   • Salario promedio: ${empleados.Average(e => e.Salario):N2}");
            Console.WriteLine($"   • Antigüedad promedio: {empleados.Average(e => e.CalcularAntiguedad()):F1} años");
        }

        Console.WriteLine("\nFUNCIONALIDADES ADICIONALES");
        Console.WriteLine();

        Console.WriteLine("Materias aprobadas por estudiantes:");
        foreach (var est in estudiantes)
        {
            var materiasAprobadas = est.ObtenerMateriasAprobadas();
            if (materiasAprobadas.Any())
            {
                Console.WriteLine($"   • {est.Nombre}: {string.Join(", ", materiasAprobadas)}");
            }
        }

        Console.WriteLine("\nDías de vacaciones disponibles (empleados):");
        foreach (var emp in empleados)
        {
            Console.WriteLine($"   • {emp.Nombre}: {emp.ObtenerDiasVacacionesDisponibles()} días disponibles");
        }

        Console.WriteLine("\nCambios de estado de miembros:");
        comunidad[5].CambiarEstado(false); // Desactivar un miembro
        comunidad[5].CambiarEstado(true);  // Reactivar

        Console.WriteLine("\n═══════════════════════════════════════════════════════════");
        Console.WriteLine("DEMONSTRACIÓN COMPLETADA");
        Console.WriteLine("Se han mostrado todas las funcionalidades del sistema:");
        Console.WriteLine("• Herencia y Polimorfismo");
        Console.WriteLine("• Sobrecarga de métodos");
        Console.WriteLine("• Encapsulación y abstracción");
        Console.WriteLine("• Gestión completa de la comunidad académica");
        Console.WriteLine("═══════════════════════════════════════════════════════════");

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}

