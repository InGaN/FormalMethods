using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalMethods
{
    public class Node
    {
        public string NodeName;
        public Dictionary<Node, char> transistions = new Dictionary<Node, char>();

        public Node(string NodeName)
        {
            this.NodeName = NodeName;
        }
        public Node(Node node)
        {
            this.NodeName = node.NodeName;
            this.transistions = node.transistions;
        }

    }
}
