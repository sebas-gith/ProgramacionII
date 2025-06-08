using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Administrador : Docente
{
    public string CargoAdministrativo { get; set; }
    public List<string> ResponsabilidadesAdmin { get; set; } = new List<string>();
    public int PersonalACargo { get; set; }
    public double PresupuestoAsignado { get; set; }
    public List<string> ProyectosEnCurso { get; set; } = new List<string>();
    public Dictionary<string, double> PresupuestoPorProyecto { get; set; } = new Dictionary<string, double>();

    public override string ObtenerRol() => "Administrador Académico";

    public override double CalcularDescuento()
    {
       
        double descuento = 0.30; 
        if (PersonalACargo > 10) descuento += 0.05;
        if (CalcularAntiguedad() >= 8) descuento += 0.05;
        return Math.Min(descuento, 0.40);
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Cargo administrativo: {CargoAdministrativo}");
        Console.WriteLine($"Personal a cargo: {PersonalACargo}");
        Console.WriteLine($"Presupuesto total: ${PresupuestoAsignado:N2}");
        Console.WriteLine($"Proyectos activos: {ProyectosEnCurso.Count}");

        if (ResponsabilidadesAdmin.Any())
        {
            Console.WriteLine($"Responsabilidades: {string.Join(", ", ResponsabilidadesAdmin)}");
        }

        if (PresupuestoPorProyecto.Any())
        {
            Console.WriteLine("Presupuesto por proyecto:");
            foreach (var proyecto in PresupuestoPorProyecto)
            {
                Console.WriteLine($"  - {proyecto.Key}: ${proyecto.Value:N2}");
            }
        }
    }

    public void MostrarInformacion(bool soloAdministrativo)
    {
        if (soloAdministrativo)
        {
            Console.WriteLine($"Administrador: {Nombre}");
            Console.WriteLine($"Cargo: {CargoAdministrativo}");
            Console.WriteLine($"Personal a cargo: {PersonalACargo}");
            Console.WriteLine($"Presupuesto: ${PresupuestoAsignado:N2}");
            Console.WriteLine($"Proyectos activos: {ProyectosEnCurso.Count}");

            if (ResponsabilidadesAdmin.Any())
            {
                Console.WriteLine($"Responsabilidades: {string.Join(", ", ResponsabilidadesAdmin)}");
            }

            if (PresupuestoPorProyecto.Any())
            {
                Console.WriteLine("Presupuesto detallado por proyecto:");
                foreach (var item in PresupuestoPorProyecto)
                {
                    Console.WriteLine($"  - {item.Key}: ${item.Value:N2}");
                }
            }
        }
        else
        {
            MostrarInformacion();         }
    }

    public void AgregarProyecto(string nombreProyecto, double presupuesto)
    {
        if (!ProyectosEnCurso.Contains(nombreProyecto))
        {
            ProyectosEnCurso.Add(nombreProyecto);
            PresupuestoPorProyecto[nombreProyecto] = presupuesto;
            PresupuestoAsignado += presupuesto;
        }
    }
}
