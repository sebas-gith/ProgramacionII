# Sistema de Gestión de Comunidad Académica

## Descripción

Este proyecto en C# implementa un sistema completo para gestionar una comunidad académica, que incluye estudiantes, ex-alumnos y personal administrativo. El sistema aprovecha conceptos fundamentales de la Programación Orientada a Objetos (POO) como herencia, polimorfismo, encapsulación y sobrecarga de métodos, para proporcionar funcionalidades avanzadas de administración, registro y reporte de información académica y laboral.


---

## Mapa de Clases

A continuación se puede incluir la imagen que representa el mapa de clases del sistema para facilitar la comprensión de la estructura y relaciones entre las clases.

![Mapa de Clases](./mapa_de_clase.png)


---

## Funcionalidades principales

- **Gestión de Estudiantes**  
  Registro de estudiantes con detalles personales, inscripción de materias, registro de calificaciones, y visualización de información académica.

- **Gestión de Ex-Alumnos**  
  Administración de información laboral, logros, certificaciones y actualización de datos profesionales.

- **Gestión de Personal Administrativo**  
  Control de datos del personal administrativo, asignación de tareas, manejo de software utilizado, control de vacaciones y aumentos salariales.

- **Polimorfismo**  
  Tratamiento uniforme de diferentes tipos de miembros para mostrar información básica, enviar notificaciones y calcular descuentos aplicables.

- **Reportes y estadísticas**  
  Resúmenes generales y estadísticas detalladas para estudiantes, ex-alumnos y empleados, incluyendo promedios, conteos y ranking.

- **Otras funcionalidades**  
  Gestión de materias aprobadas, días de vacaciones disponibles, y cambios de estado activo/inactivo de miembros.

---

## Tecnologías utilizadas

- Lenguaje: C#  
- Plataforma: .NET (compatible con versiones modernas de .NET Core o .NET Framework)  
- Conceptos: Programación Orientada a Objetos, Colecciones genéricas, LINQ para consultas y estadísticas

---

## Estructura del código

El código principal está contenido en la clase `Program` con un método `Main` que demuestra:

- Creación y configuración de objetos para estudiantes, ex-alumnos y administrativos.  
- Inscripción y registro de materias y calificaciones.  
- Registro de logros, certificaciones y cambios laborales para ex-alumnos.  
- Asignación de tareas, manejo de vacaciones y aumentos para administrativos.  
- Uso de polimorfismo para manejar miembros de la comunidad de forma uniforme.  
- Generación de reportes estadísticos.  
- Demostración de funcionalidades avanzadas como sobrecarga y encapsulación.

---

## Cómo ejecutar

1. Clona o descarga este repositorio.  
2. Abre el proyecto en un entorno compatible con C# (Visual Studio, Visual Studio Code con extensión C#, JetBrains Rider, etc.).  
3. Compila y ejecuta el programa.  
4. Observa la salida en la consola, donde se muestran los procesos y resultados de la gestión de la comunidad académica.

---

## Posibles mejoras

- Implementar persistencia de datos en base de datos o archivos.  
- Crear interfaz gráfica para facilitar la interacción con el usuario.  
- Añadir manejo de excepciones para robustecer el programa.  
- Integrar autenticación y control de acceso para distintos roles.  
- Ampliar el sistema con módulos para docentes, horarios, eventos y más.

---

