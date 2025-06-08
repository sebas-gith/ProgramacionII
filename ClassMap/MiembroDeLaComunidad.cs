using System;
using System.Collections.Generic;
using System.Linq;

public abstract class MiembroDeLaComunidad
{
    private static int siguienteId = 1;

    public int Id { get; private set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public DateTime FechaRegistro { get; set; }
    public bool Activo { get; set; }

    protected MiembroDeLaComunidad()
    {
        Id = siguienteId++;
        FechaRegistro = DateTime.Now;
        Activo = true;
    }

    public abstract string ObtenerRol();
    public abstract double CalcularDescuento();

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"ID: {Id}, Nombre: {Nombre}, Rol: {ObtenerRol()}");
        Console.WriteLine($"Email: {Email}, Teléfono: {Telefono}");
        Console.WriteLine($"Fecha Registro: {FechaRegistro:yyyy-MM-dd}, Activo: {Activo}");
    }

    public virtual void MostrarInformacion(bool incluirContacto)
    {
        Console.WriteLine($"ID: {Id}, Nombre: {Nombre}, Rol: {ObtenerRol()}");
        if (incluirContacto)
        {
            Console.WriteLine($"Email: {Email}, Teléfono: {Telefono}");
        }
    }

    public virtual void MostrarInformacion(string formato)
    {
        switch (formato.ToLower())
        {
            case "completo":
                MostrarInformacion();
                break;
            case "basico":
                Console.WriteLine($"{Nombre} - {ObtenerRol()}");
                break;
            case "id":
                Console.WriteLine($"ID: {Id} - {Nombre}");
                break;
            default:
                MostrarInformacion();
                break;
        }
    }

    public virtual void EnviarNotificacion(string mensaje)
    {
        Console.WriteLine($"📧 Notificación enviada a {Nombre} ({Email}): {mensaje}");
    }

    public virtual void CambiarEstado(bool nuevoEstado)
    {
        Activo = nuevoEstado;
        Console.WriteLine($"Estado de {Nombre} cambiado a: {(Activo ? "Activo" : "Inactivo")}");
    }

    public virtual string ObtenerInformacionBasica()
    {
        return $"{Nombre} - {ObtenerRol()} (ID: {Id})";
    }

    public virtual void EnviarNotificacion(string mensaje, string tipoNotificacion)
    {
        string icono = tipoNotificacion.ToLower() switch
        {
            "email" => "📧",
            "sms" => "📱",
            "push" => "🔔",
            _ => "📢"
        };
        Console.WriteLine($"{icono} {tipoNotificacion} enviado a {Nombre}: {mensaje}");
    }
}
