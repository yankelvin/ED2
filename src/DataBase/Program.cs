using System;
using DataBase.Class;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Vantagens e Desvantagens
            /* Vantagens:
             * - Rápida consulta quando os índices estão organizados corretamente;
             * - Possibilidade de adicionar índices referentes as colunas mais pesquisadas;
             * 
             * Desvantagens:
             * - Se fizer busca pelo índice errado pode onerar a consulta;
             * - Para fazer a primeira consulta pelo índice de uma coluna será necessário criá-lo;
             * 
             */
            #endregion

            var db = new Db();

            db.CreateTable("Alunos");
            db.Insert("Alunos", 1, new { IdCurso = 1, Nome = "João" });

            db.CreateTable("Cursos");
            db.Insert("Cursos", 1, new { IdCurso = 1, Nome = "Engenharia", Periodos = 10 });

            Console.WriteLine(db.ToString());
        }
    }
}
