using Speka.Models;
using System.IO;

namespace Speka.Services
{
    public class FileSystemService
    {
        public FileSystemNode ScanDirectory(string rootPath)
        {
            var dir = new DirectoryInfo(rootPath);
            var root = new FileSystemNode(rootPath, false, null, dir.Name);
            FillNodeRecursive(root, dir);
            return root;
        }

        private static void FillNodeRecursive(FileSystemNode node, DirectoryInfo dir)
        {
            foreach (var subDir in dir.GetDirectories())
            {
                var childNode = new FileSystemNode(subDir.FullName, false, node, subDir.Name);
                FillNodeRecursive(childNode, subDir);

                if (childNode.Children.Count > 0)
                    node.Children.Add(childNode);
            }

            foreach (var file in dir.GetFiles())
                if (file.Extension == ".yaml")
                    node.Children.Add(new(file.FullName, true, node, file.Name));
        }
    }
}
