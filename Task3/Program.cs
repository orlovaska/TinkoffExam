using System;
using System.Collections.Generic;

namespace Task3
{
    class DirectoryNode
    {
        public string Name { get; set; }
        public SortedDictionary<string, DirectoryNode> Children { get; set; }

        public DirectoryNode(string name)
        {
            Name = name;
            Children = new SortedDictionary<string, DirectoryNode>();
        }
    }

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> paths = new List<string>();

            for (int i = 0; i < n; i++)
            {
                paths.Add(Console.ReadLine());
            }

            DirectoryNode root = BuildDirectoryTree(paths);

            PrintDirectoryTree(root, 0);
        }

        static DirectoryNode BuildDirectoryTree(List<string> paths)
        {
            DirectoryNode root = new DirectoryNode("root");

            foreach (var path in paths)
            {
                string[] parts = path.Split('\\');
                DirectoryNode currentNode = root;

                foreach (var part in parts)
                {
                    if (!currentNode.Children.ContainsKey(part))
                    {
                        currentNode.Children.Add(part, new DirectoryNode(part));
                    }
                    currentNode = currentNode.Children[part];
                }
            }

            return root;
        }

        static void PrintDirectoryTree(DirectoryNode node, int depth)
        {
            foreach (var child in node.Children.Values)
            {
                Console.WriteLine(new string(' ', depth * 2) + child.Name);
                PrintDirectoryTree(child, depth + 1);
            }
        }
    }
}