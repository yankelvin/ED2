using System;
using DataBase.Class;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Db();

            db.CreateTable("Alunos");
            db.Insert("Alunos", 1, new { IdCurso = 1, Nome = "João" });

            db.CreateTable("Cursos");
            db.Insert("Cursos", 1, new { IdCurso = 1, Nome = "Engenharia", Periodos = 10 });

            Console.WriteLine(db.ToString());
        }
    }
}
