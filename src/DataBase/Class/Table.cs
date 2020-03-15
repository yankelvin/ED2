using BinaryTree.Class;

namespace DataBase.Class
{
    public class Table
    {
        public string Name { get; set; }
        public BinaryTree<int, object> Data { get; private set; }

        public Table() { }

        public Table(string name)
        {
            Name = name;
            Data = new BinaryTree<int, object>();
        }

        public override string ToString()
        {
            return $"TableName: {Name} | Data: {Data}";
        }
    }
}
