using System;
using System.ComponentModel;


namespace Graphs3 // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            int flag = 0;
            IGraph? graph = null;
            StreamWriter? sw = null;

            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < args.Length; j++)
                    if (args[j] == "-h")
                    {
                        ShowHelp();
                        flag = 1;
                        break;
                    }
                if (flag == 1)
                {
                    break;
                }
            }
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-m")
                {
                    graph = new GraphMatrix(args[i + 1]);


                }
                else if (args[i] == "-e")
                {
                    graph = new EdgeList(args[i + 1]);

                }
                else if (args[i] == "-l")
                {
                    graph = new AdjacencyGraph(args[i + 1]);
                }
                else if (args[i] == "-o")
                {
                    sw = new StreamWriter(args[i + 1]);
                }

            }
            if (graph == null)
            {
                return;
            }
            if (sw == null)
            {
                sw = new StreamWriter(Console.OpenStandardOutput());
                sw.AutoFlush = true;
                Console.SetOut(sw);
            }
            
            var bridges = graph.find_bridges();
            Console.Write("Bridges:");
            foreach (var bridge in bridges)
            {
                for (int i = 0; i < bridge.Count; i++)
                    Console.WriteLine(bridge[i].Item1 + " " + bridge[i].Item2);

            }
            var ap = graph.GetAP();
            
            Console.Write("Cut vertices:");
            foreach (var item in ap )
            {
                Console.Write(item.ToString() + " "); 
            }


            void ShowHelp()
            {
                Console.WriteLine("Выполнил: Луганский Артем\n Группа: М3О-225Бк-21 \n Задание №1 \n Ключи: \n -m - adjacency_matrix_file_path \n -e - edges_list_file_path \n -l - adjacency_list_file_path \n -o - output_file_path\n");
            }
        }






    }

}