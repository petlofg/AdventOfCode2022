using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _7
{
	internal class Node
	{
		internal Node? Parent { get; }

		internal string Name { get; }

		internal List<Node> ChildNodes = new();

		internal List<int> FileSizes { get; } = new();


		public Node(string name)
		{
			Name = name;
			Parent = null;
		}

		internal Node(string name, Node parent)
		{
			Name = name;
			Parent = parent;
		}

		internal void AddNode(Node node)
		{
			ChildNodes.Add(node);
		}

		internal int GetTotalSize()
		{
			int totalSize = FileSizes.Sum();

			foreach(Node child in ChildNodes)
			{
				totalSize += child.GetTotalSize();
			}

			return totalSize;
		}
	}
}
