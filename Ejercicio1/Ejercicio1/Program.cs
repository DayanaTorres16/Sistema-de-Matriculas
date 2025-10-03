using System;
using System.Collections.Generic;

public interface IMatricula
{
    void MatricularAsignatura(string asignatura);
}

public abstract class Persona
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Correo { get; set; }
    public int Telefono { get; set; }
    private int Documento { get; set; }

    public Persona(string nombre, string apellido, int edad, string correo, int telefono, int documento)
    {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
        Correo = correo;
        Telefono = telefono;
        Documento = documento;
    }

    public int ObtenerDocumento()
    {
        return Documento;
    }

    public virtual void MostrarDetalles()
    {
        Console.WriteLine("--- Detalles de la Persona ---");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Apellido: {Apellido}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine($"Correo: {Correo}");
        Console.WriteLine($"Telefono: {Telefono}");
        Console.WriteLine($"Documento: {Documento}");
    }
}

public class Estudiante : Persona, IMatricula
{
    public string Carrera { get; set; }
    public int Semestre { get; set; }
    private List<string> AsignaturasMatriculadas { get; set; }

    public Estudiante(string nombre, string apellido, int edad, string correo, int telefono,
        int documento, string carrera, int semestre)
        : base(nombre, apellido, edad, correo, telefono, documento)
    {
        Carrera = carrera;
        Semestre = semestre;
        AsignaturasMatriculadas = new List<string>();
    }

    public void MatricularAsignatura(string asignatura)
    {
        if (!AsignaturasMatriculadas.Contains(asignatura))
        {
            AsignaturasMatriculadas.Add(asignatura);
            Console.WriteLine($"Asignatura '{asignatura}' matriculada exitosamente para {Nombre}");
        }
        else
        {
            Console.WriteLine($"El estudiante {Nombre} ya está matriculado en '{asignatura}'");
        }
    }

    public override void MostrarDetalles()
    {
        Console.WriteLine("--- Detalles del Estudiante ---");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Apellido: {Apellido}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine($"Correo: {Correo}");
        Console.WriteLine($"Telefono: {Telefono}");
        Console.WriteLine($"Documento: {ObtenerDocumento()}");
        Console.WriteLine($"Carrera: {Carrera}");
        Console.WriteLine($"Semestre: {Semestre}");
        Console.WriteLine($"Asignaturas Matriculadas ({AsignaturasMatriculadas.Count}):");
        
        if (AsignaturasMatriculadas.Count > 0)
        {
            foreach (var asignatura in AsignaturasMatriculadas)
            {
                Console.WriteLine($"  • {asignatura}");
            }
        }
        else
        {
            Console.WriteLine("  (Sin asignaturas matriculadas)");
        }
    }
}

class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA DE MATRICULACION UNIVERSITARIA ===\n");
        
        Estudiante estudiante1 = new Estudiante("Brayan", "Peña", 20, "brayanp@correo.com", 123456, 1001, "Ingenieria", 7);

        Console.WriteLine("\n--- MATRICULANDO ASIGNATURAS ---");
        estudiante1.MatricularAsignatura("Programacion");
        estudiante1.MatricularAsignatura("Matematicas");
        estudiante1.MatricularAsignatura("Base de Datos");

        Console.WriteLine("\n\n=== DETALLES DE LAS PERSONAS ===");
        estudiante1.MostrarDetalles();

        Console.WriteLine("\n\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}

