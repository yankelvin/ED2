using System.Collections.Generic;

namespace DataBase.Class
{
    public class Db
    {
        private List<Table> Tables { get; set; }

        public Db()
        {
            Tables = new List<Table>();
        }

        public void CreateTable(string tableName)
        {
            var table = new Table(tableName);
            Tables.Add(table);
        }

        public bool Insert(string tableName, int key, object data)
        {
            foreach (var table in Tables)
            {
                if (table.Name.Equals(tableName))
                {
                    table.Data.Add(key, data);
                    return true;
                }
            }

            return false;
        }

        public object Select(string tableName, int key)
        {
            foreach (var table in Tables)
            {
                if (table.Name.Equals(tableName))
                {
                    var node = table.Data.Search(key);
                    return node.Data;
                }
            }

            return null;
        }

        public bool Update(string tableName, int key, object data)
        {
            foreach (var table in Tables)
            {
                if (table.Name.Equals(tableName))
                {
                    table.Data.Search(key).Data = data;
                    return true;
                }
            }

            return false;
        }

        public bool Delete(string tableName, int key)
        {
            foreach (var table in Tables)
            {
                if (table.Name.Equals(tableName))
                {
                    table.Data.Remove(key);
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            string info = "";

            foreach (var table in Tables)
                info += $"{table.ToString()} + \n";

            return info;
        }
    }
}
