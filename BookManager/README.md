﻿# 📚 BookManager

**BookManager** es una API REST construida con ASP.NET Core que permite gestionar libros de manera sencilla. Este proyecto forma parte del curso **Programación II** y está enfocado en la práctica de conceptos como controladores, entidades, Entity Framework Core y operaciones CRUD.

## 🧱 Estructura del Proyecto

- **Entities/Book.cs**  
  Define la entidad Book, que representa un libro en la base de datos.

- **Controllers/BookController.cs**  
  Controlador principal que maneja las solicitudes relacionadas con libros.

## 📦 Funcionalidades Principales

### 🔍 Buscar libros

http
GET /api/book?title=example&author=example
## 🔍 Buscar libros

Busca libros por **título** y/o **autor** (parámetros opcionales).

---

## ➕ Agregar un libro

**POST** `/api/book`  
Envía un objeto JSON con los datos del libro a agregar.

---

## 📚 Agregar múltiples libros

**POST** `/api/book/MoreThanOne`  
Envía un array de objetos `Book` para agregarlos en lote.

---

## 📝 Actualizar un libro

**PUT** `/api/book/{id}`  
Actualiza los campos de un libro específico mediante su `id`.

---

## 🗑️ Eliminar un libro

**DELETE** `/api/book/{id}`  
Elimina un libro específico de la base de datos.

---

## 📘 Modelo de Libro (Entidad)

```csharp
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublishedYear { get; set; }
}

```
## 🛠️ Tecnologías Utilizadas

- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server (para persistencia de datos)  
- LINQ  

## 🚀 Cómo Ejecutar

1. Clona el repositorio:
```bash
git clone https://github.com/sebas-gith/ProgramacionII.git
```
2. Ve a la carpeta del proyecto:

```bash
cd ProgramacionII/BookManager
```
3. Configura tu cadena de conexión en appsettings.json.

4. Ejecuta la migración y crea la base de datos:

```bash
dotnet ef database update
```
5. Inicia la API:

```bash
dotnet run
```
## 🧑‍🎓 Autor
Este proyecto fue desarrollado como parte de la asignatura Programación II.
