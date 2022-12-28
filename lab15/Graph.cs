using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace lab15
{
    public class Graph
    {
        public List<Node> Verts;
        public List<KeyValuePair<Node, Node>> MinSpan;
        public Graph()
        {
            Verts = new List<Node>();
            MinSpan = new List<KeyValuePair<Node, Node>>();
        }

        public Graph(string path)
        {
            Verts = new List<Node>();
            MinSpan = new List<KeyValuePair<Node, Node>>();
            StreamReader input = new StreamReader(path);
            for (int i = 0; i < System.IO.File.ReadAllLines(path).Length; i++)
            {
                string[] str = input.ReadLine().Split('|');
                Node n = new Node(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]));
                Verts.Add(n);
            }
            input.Close();
            input = new StreamReader(path);
            for (int i = 0; i < Verts.Count; i++)
            {
                string[] edgs = input.ReadLine().Split('|')[3].Split(',');
                for(int j = 0; j < edgs.Count()-1; j++)
                {
                    string[] b = edgs[j].Split('-');
                    Verts[i].AddEdge(FindById(int.Parse(b[0])), int.Parse(b[1]));
                }
            }
            input.Close();
        }

        public void AddVertex(float x, float y)
        {
            int new_id = 0;
            bool found = false;
            for (int i = 0; i < Verts.Count; i++)
            {
                if (!found)
                {
                    found = true;
                    foreach (Node node in Verts)
                    {
                        if (node.id == new_id)
                        {
                            new_id++;
                            found = false;
                            break;
                        }
                    }
                }
            }
            Verts.Add(new Node(new_id, x, y));
        }

        public void RemoveVertex(Node node)
        {
            while(node.edges.Count != 0)
            {
                node.RemoveEdge(node.edges[0]);
            }
            Verts.Remove(node);
        }

        public void AddEdge(Node node1, Node node2, int value)
        {
            node1.AddEdge(node2, value);
        }

        public void RemoveEdge(Node node1, Node node2)
        {
            node1.RemoveEdge(node2);
        }

        public string BellmanFord(int source)
        {
            int verticesCount = Verts.Count;
            int[] distance = new int[verticesCount];

            for (int i = 0; i < verticesCount; i++)
                distance[i] = int.MaxValue;

            distance[source] = 0;
            //создали массив ребер
            // List<KeyValuePair<Node, Node>> edges = new List<KeyValuePair<Node, Node>>();
            List <Edge> edges = new List<Edge>();
            //создали матрицу смежности
            foreach (Node node in Verts)
            {
                foreach(Node n in node.edges)
                {
                    edges.Add(new Edge(node, n, node.values[node.edges.IndexOf(n)]));
                }
            }

            int edgesCount = edges.Count; 

            for (int i = 1; i <= verticesCount - 1; ++i)
            {
                for (int j = 0; j < edgesCount; ++j)
                {
                    int u = edges[j].Source.id;
                    int v = edges[j].Destination.id;
                    int weight = edges[j].Value;

                    if (distance[u] != int.MaxValue && distance[u] + weight < distance[v]) {
                        distance[v] = distance[u] + weight;
                    }
                }
            }
            
            string text_msg = "No negative weight cycle!";
            for (int i = 0; i < edgesCount; ++i)
            {
                int u = edges[i].Source.id;
                int v = edges[i].Destination.id;
                int weight = edges[i].Value;

                if (distance[u] != int.MaxValue && distance[u] + weight < distance[v]) {
                    text_msg = "Graph contains negative weight cycle.";
                    
                }
            }
            
            // MinSpan.Add(new KeyValuePair<Node, Node>(edges[0].Source, edges[0].Destination));
            // MinSpan = new List<KeyValuePair<Node, Node>>();
            // List<KeyValuePair<Node, Node>> all = new List<KeyValuePair<Node, Node>>();
            // KeyValuePair<Node, Node> edge = new KeyValuePair<Node, Node>(null, null);
            //
            // //создали матрицу смежности
            // foreach (Node node in Verts)
            // {
            //     foreach(Node n in node.edges)
            //     {
            //         all.Add(new KeyValuePair<Node, Node>(node, n));
            //     }
            // }
            //
            // List<int> dist = new List<int>();
            // for (int i = 0; i < Verts.Count(); ++i)
            //     dist[i] = int.MaxValue;
            // dist[src] = 0;
            //
            // for (int i = 1; i < Verts.Count(); ++i)
            // {
            //     for (int j = 0; j < all.Count(); ++j)
            //     {
            //         int u = all[j].Key.id;
            //         int v = all[j].Value.id;
            //         int weight = all[j].Key.values;
            //         if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
            //             dist[v] = dist[u] + weight;
            //     }
            // }
            //
            // string text_msg = "No negative weight cycle!";
            // for (int i = 0; i < Verts.Count(); ++i) {
            //     int u = all[i].Key.id;
            //     int v = all[i].Value.id;
            //     int weight = all[i].Key.values;
            //
            //     if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
            //          text_msg = "Graph contains negative weight cycle.";
            // }
        
            // for(int i = 0; i < dist.Count; i++) {
            //     MinSpan.Add(i, Verts[i].values[i]);
            // }

            foreach (var i in edges) {
                if (i.Value < 0) {
                    MinSpan.Add(new KeyValuePair<Node, Node>(i.Source, i.Destination));
                    break;
                }
            }
            
            return text_msg;
        }
        
        // public void FindMinSpan2()
        // {
        //     MinSpan = new List<KeyValuePair<Node, Node>>();
        //     List<KeyValuePair<Node, Node>> all = new List<KeyValuePair<Node, Node>>();
        //     KeyValuePair<Node, Node> edge = new KeyValuePair<Node, Node>(null, null);
        //     foreach (Node node in Verts)
        //     {
        //         foreach(Node n in node.edges)
        //         {
        //             all.Add(new KeyValuePair<Node, Node>(node, n));
        //         }
        //     }
        //     int value;
        //     while(all.Count != 0)
        //     {
        //         value = int.MaxValue;
        //         edge = new KeyValuePair<Node, Node>(null, null);
        //         foreach (Node node in Verts)
        //         {
        //             for (int j = 0; j < node.edges.Count; j++)
        //             {
        //                 if (node.values[j] < value)
        //                 {
        //                     if (all.Contains(new KeyValuePair<Node, Node>(node, node.edges[j])))
        //                     {
        //                         value = node.values[j];
        //                         edge = new KeyValuePair<Node, Node>(node, node.edges[j]);
        //                     }
        //                 }
        //             }
        //         }
        //         if (edge.Key != null) {
        //             MinSpan.Add(edge);
        //             all.Remove(edge);
        //             edge = new KeyValuePair<Node, Node>(edge.Value, edge.Key);
        //             MinSpan.Add(edge);
        //             all.Remove(edge);
        //         }
        //         bool cycle = false;
        //         bool changed = false;
        //         KeyValuePair<Node, Node> next = new KeyValuePair<Node, Node>(null, null);
        //         List<KeyValuePair<Node, Node>> cycler;
        //         foreach (KeyValuePair<Node, Node> minedge in MinSpan)
        //         {
        //             cycler = new List<KeyValuePair<Node, Node>>();
        //             next = minedge;
        //             cycler.Add(next);
        //             do
        //             {
        //                 changed = false;
        //                 foreach (KeyValuePair<Node, Node> nextedge in MinSpan)
        //                 {
        //                     if (next.Value == nextedge.Key && !(next.Key == nextedge.Value && next.Value == nextedge.Key))
        //                     {
        //                         if (cycler.Contains(nextedge) || nextedge.Value == minedge.Key) { cycle = true; break; }
        //                         else {
        //                             cycler.Add(nextedge);
        //                             changed = true;
        //                         }
        //                         next = nextedge;
        //                         break;
        //                     }
        //                 }
        //             } while (changed && !cycle);
        //             if (cycle)
        //             {
        //                 MinSpan.RemoveAt(MinSpan.Count - 1);
        //                 MinSpan.RemoveAt(MinSpan.Count - 1);
        //                 break;
        //             }
        //         }
        //     }
        //     int bruh = MinSpan.Count;
        //     for (int i = 0; i < bruh/2; i++)
        //     {
        //         MinSpan.RemoveAt(i);
        //     }
        // }
        
        public int rebra_k(Graph gr)
        {
            int k = 0;
            foreach(Node node in Verts)
            {
                k+=node.edges.Count;
            }
            return k/2;
        }
        public void SaveToFile(string path)
        {
            StreamWriter output = new StreamWriter(path);
            foreach (Node node in Verts) {
                output.Write(node.id + "|" + node.x + "|" + node.y + "|");
                for(int i = 0; i < node.edges.Count; i++)
                {
                    output.Write(node.edges[i].id + "-" + node.values[i] + ",");
                }
                output.Write("\n");
            }
            output.Close();
        }

        public Node FindById(int id)
        {
            foreach(Node node in Verts)
            {
                if (node.id == id) return node;
            }
            return null;
        }

    }
}