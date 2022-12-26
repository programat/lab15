using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab15
{
    public class Node
    {
        public int id;
        public List<Node> edges;
        public List<int> values;

        public float x;
        public float y;

        public Node(int id, float x, float y)
        {
            edges = new List<Node>();
            values = new List<int>();
            this.id = id;
            this.x = x;
            this.y = y;
        }
        public void AddEdge(Node node, int value)
        {
            if (!edges.Contains(node))
            {
                edges.Add(node);
                values.Add(value);
                node.edges.Add(this);
                node.values.Add(value);
            }
        }

        public void RemoveEdge(Node node)
        {
            if(edges.Contains(node))
            {
                values.RemoveAt(edges.IndexOf(node));
                edges.Remove(node);
                node.values.RemoveAt(node.edges.IndexOf(this));
                node.edges.Remove(this);
            }
        }
    }
}