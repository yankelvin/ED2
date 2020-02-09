namespace GenericTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var explorerTree = new ExplorerTree("/usuarios/rt/cursos", 1);
            explorerTree.AddFileFolder("/usuarios/rt/cursos", "cs016/", 2);
            explorerTree.AddFileFolder("/usuarios/rt/cursos", "cs252/", 1);

            explorerTree.AddFileFolder("cs016/", "notas", 8);
            explorerTree.AddFileFolder("cs016/", "temas/", 1);
            explorerTree.AddFileFolder("cs016/", "programas/", 1);

            explorerTree.AddFileFolder("temas/", "tm1", 3);
            explorerTree.AddFileFolder("temas/", "tm2", 2);
            explorerTree.AddFileFolder("temas/", "tm3", 4);

            explorerTree.AddFileFolder("programas/", "pr1", 57);
            explorerTree.AddFileFolder("programas/", "pr2", 97);
            explorerTree.AddFileFolder("programas/", "pr3", 74);

            explorerTree.AddFileFolder("cs252/", "projetos/", 1);
            explorerTree.AddFileFolder("cs252/", "notas", 3);

            explorerTree.AddFileFolder("projetos/", "trabalhos/", 1);
            explorerTree.AddFileFolder("projetos/", "demos/", 1);

            explorerTree.AddFileFolder("trabalhos/", "compre baixo", 26);
            explorerTree.AddFileFolder("trabalhos/", "venda alto", 55);

            explorerTree.AddFileFolder("demos/", "mercado", 4786);

            explorerTree.ShowExplorer();
        }
    }
}
