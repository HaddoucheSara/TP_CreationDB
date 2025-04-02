using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TP_CreationDB.Data;
using TP_CreationDB.Models;


namespace TP_CreationDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer("Server=OUJDKZJN53;Database=TP_CreationDB;Trusted_Connection=True;TrustServerCertificate=True;"))
                .BuildServiceProvider();

            using (var dbContext = serviceProvider.GetService<ApplicationDbContext>())
            {
                if (dbContext == null)
                {
                    Console.WriteLine("Erreur : Impossible d'initialiser le contexte de base de données.");
                    return;
                }

                try
                {
                    Console.WriteLine("📌Liste des enseignants :");
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine("| {0,-5} | {1,-15} | {2,-15} | {3,-10} |", "ID", "Prénom", "Nom", "Matière");
                    Console.WriteLine(new string('-', 50));

                    var teachers = dbContext.Persons
                        .OfType<Teacher>()
                        .Include(t => t.Subject)  // Inclure les matières enseignées
                        .Select(t => new { t.Id, t.FirstName, t.LastName, SubjectName = t.Subject.Name })
                        .ToList();

                    foreach (var teacher in teachers)
                    {
                        Console.WriteLine("| {0,-5} | {1,-15} | {2,-15} | {3,-10} |",
                            teacher.Id, teacher.FirstName, teacher.LastName, teacher.SubjectName);
                    }
                    Console.WriteLine(new string('-', 50));

                    Console.WriteLine("\n📌 Liste des étudiants :");
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine("| {0,-5} | {1,-15} | {2,-15} | {3,-10} |", "ID", "Prénom", "Nom", "Numéro");
                    Console.WriteLine(new string('-', 50));

                    var students = dbContext.Persons
                        .OfType<Student>()
                        .Select(s => new { s.Id, s.FirstName, s.LastName, s.StudentNumber })
                        .ToList();

                    foreach (var student in students)
                    {
                        Console.WriteLine("| {0,-5} | {1,-15} | {2,-15} | {3,-10} |",
                            student.Id, student.FirstName, student.LastName, student.StudentNumber);
                    }
                    Console.WriteLine(new string('-', 50));

                    Console.WriteLine("\n📌 Liste des classes :");
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine("| {0,-5} | {1,-25} | {2,-12} | {3,-10} |", "ID", "Nom de la classe", "Niveau", "Enseignant");
                    Console.WriteLine(new string('-', 50));

                    var classes = dbContext.Classes
                        .Join(dbContext.Persons,
                            c => c.TeacherId,
                            t => t.Id,
                            (c, t) => new { c.Id, c.Name, c.Level, TeacherName = t.FirstName + " " + t.LastName })
                        .ToList();

                    foreach (var classe in classes)
                    {
                        Console.WriteLine("| {0,-5} | {1,-25} | {2,-12} | {3,-10} |",
                            classe.Id, classe.Name, classe.Level, classe.TeacherName);
                    }
                    Console.WriteLine(new string('-', 50));

                    Console.WriteLine("\n📌 Liste des inscriptions :");
                    Console.WriteLine(new string('-', 70));
                    Console.WriteLine("| {0,-5} | {1,-20} | {2,-25} | {3,-15} |", "ID", "Étudiant", "Classe", "Date");
                    Console.WriteLine(new string('-', 70));

                    var enrollments = dbContext.Enrollments
                        .Join(dbContext.Persons,
                            e => e.StudentId,
                            s => s.Id,
                            (e, s) => new { e.ID, StudentName = s.FirstName + " " + s.LastName, e.ClassId, e.EnrollmentDate })
                        .Join(dbContext.Classes,
                            e => e.ClassId,
                            c => c.Id,
                            (e, c) => new { e.ID, e.StudentName, ClassName = c.Name, e.EnrollmentDate })
                        .ToList();

                    foreach (var enrollment in enrollments)
                    {
                        Console.WriteLine("| {0,-5} | {1,-20} | {2,-25} | {3,-15} |",
                            enrollment.ID, enrollment.StudentName, enrollment.ClassName, enrollment.EnrollmentDate.ToShortDateString());
                    }
                    Console.WriteLine(new string('-', 70));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la récupération des données : {ex.Message}");
                }
            }

        }

    }
}
