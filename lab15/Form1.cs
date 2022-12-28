using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab15
{
    public partial class Form1 : Form
    {
        Graph graph;
        private MouseMode mouseMode = MouseMode.MOVE_VERTEX;
        private Node grabbedVertex;
        private float mouseX;
        private float mouseY;

        Bitmap buffer;
        public Form1()
        {
            InitializeComponent();
            graph = new Graph();
        }

        private enum MouseMode
        {
            MOVE_VERTEX, ADD_VERTEX, REMOVE_VERTEX, ADD_EDGE, REMOVE_EDGE
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (buffer == null)
                buffer = new Bitmap(Width, Height);
            Graphics gfx = Graphics.FromImage(buffer);
            gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            gfx.Clear(Color.White);
            
            
            KeyValuePair<Node, Node> edge = new KeyValuePair<Node, Node>(null, null);
            KeyValuePair<Node, Node> edge2 = new KeyValuePair<Node, Node>(null, null);
            List<KeyValuePair<Node, Node>> drawn = new List<KeyValuePair<Node, Node>>();
            
            
            foreach (Node v in graph.Verts)
            {
                for(int i = 0; i < v.edges.Count; i++)
                {
                    Node adj = v.edges[i];
                    edge = new KeyValuePair<Node, Node>(v, adj);
                    edge2 = new KeyValuePair<Node, Node>(adj, v);
                    if (!drawn.Contains(edge))
                    {
                        DrawUtils.DrawLineFromTo(gfx, (graph.MinSpan.IndexOf(edge) == -1) && (graph.MinSpan.IndexOf(edge2) == -1) ? DrawUtils.penBlack : DrawUtils.penBlue, v, adj, v.values[i]);
                        drawn.Add(edge);
                        drawn.Add(edge2);
                    }
                }
                DrawUtils.DrawVertex(gfx, v, v.x, v.y);
            }
            
            if (mouseMode == MouseMode.ADD_EDGE || mouseMode == MouseMode.REMOVE_EDGE)
            {
                if (grabbedVertex != null)
                    DrawUtils.DrawLineFromTo(gfx, mouseMode == MouseMode.ADD_EDGE ? DrawUtils.penBlack : DrawUtils.penRed, grabbedVertex.x, grabbedVertex.y, this.mouseX, this.mouseY, false, 0);
            }
            
            pb_GraphCanvas.Image = buffer;
        }

        private void pb_GraphCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.mouseMode == MouseMode.MOVE_VERTEX || this.mouseMode == MouseMode.ADD_EDGE || this.mouseMode == MouseMode.REMOVE_EDGE)
            {
                this.grabbedVertex = this.graph.Verts.Find(v => Math.Abs(v.x - e.X) <= 14 && Math.Abs(v.y - e.Y) <= 14);
            }
            if (this.mouseMode == MouseMode.REMOVE_VERTEX)
            {
                Node clickedVertex = this.graph.Verts.Find(v => Math.Abs(v.x - e.X) <= 14 && Math.Abs(v.y - e.Y) <= 14);
                if (clickedVertex != null)
                {
                    this.graph.RemoveVertex(clickedVertex);
                    this.mouseMode = MouseMode.MOVE_VERTEX;
                }
            }
            if (this.mouseMode == MouseMode.ADD_VERTEX)
            {
                this.graph.AddVertex(e.X, e.Y);
                this.mouseMode = MouseMode.MOVE_VERTEX;
            }
        }

        private void pb_GraphCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.mouseMode == MouseMode.MOVE_VERTEX)
            {
                this.grabbedVertex = null;
            }
            if (this.mouseMode == MouseMode.ADD_EDGE)
            {
                Node secondVertex = this.graph.Verts.Find(v => Math.Abs(v.x - e.X) <= 14 && Math.Abs(v.y - e.Y) <= 14);
                if (this.grabbedVertex != null && secondVertex != null)
                {
                    try
                    {
                        if (this.grabbedVertex.id != secondVertex.id)
                            this.graph.AddEdge(grabbedVertex, secondVertex, int.Parse(tb_Value.Text));
                    } catch { MessageBox.Show("Неверное значение веса ребра.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                this.grabbedVertex = null;
                this.mouseMode = MouseMode.MOVE_VERTEX;
            }
            if (this.mouseMode == MouseMode.REMOVE_EDGE)
            {
                Node secondVertex = this.graph.Verts.Find(v => Math.Abs(v.x - e.X) <= 14 && Math.Abs(v.y - e.Y) <= 14);
                if (this.grabbedVertex != null && secondVertex != null)
                {
                    if (this.grabbedVertex.id != secondVertex.id)
                        this.graph.RemoveEdge(grabbedVertex, secondVertex);
                }
                this.grabbedVertex = null;
                this.mouseMode = MouseMode.MOVE_VERTEX;
            }
        }

        private void pb_GraphCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMode == MouseMode.MOVE_VERTEX && this.grabbedVertex != null)
            {
                this.grabbedVertex.x = Math.Min(Math.Max(e.X, 14), pb_GraphCanvas.Width - 14);
                this.grabbedVertex.y = Math.Min(Math.Max(e.Y, 14), pb_GraphCanvas.Height - 14);
            }
            this.mouseX = e.X;
            this.mouseY = e.Y;
        }

        private void btn_AddVert_Click(object sender, EventArgs e)
        {
            mouseMode = MouseMode.ADD_VERTEX;
        }

        private void brn_RemoveVert_Click(object sender, EventArgs e)
        {
            mouseMode = MouseMode.REMOVE_VERTEX;
        }

        private void btn_RemoveEdge_Click(object sender, EventArgs e)
        {
            mouseMode = MouseMode.REMOVE_EDGE;
        }

        private void btn_AddEdge_Click(object sender, EventArgs e)
        {
            mouseMode = MouseMode.ADD_EDGE;
        }

        private void btn_MinSpan_Click(object sender, EventArgs e)
        {
            tb_QEdges.Text = graph.BellmanFord(0);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            try
            {
                graph.SaveToFile(filename);
            }
            catch (IOException)
            {
                MessageBox.Show("Не удалось записать граф в файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            try
            {
                graph = new Graph(filename);
            }
            catch (IOException)
            {
                MessageBox.Show("Не удалось прочитать файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_QEdges_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
