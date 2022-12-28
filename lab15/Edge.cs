namespace lab15
{
    public class Edge
    {
        public Node Source;
        public Node Destination;
        public int Value;

        public Edge(Node Source, Node Destination, int Value)
        {
            this.Source = Source;
            this.Destination = Destination;
            this.Value = Value;
        }
    }
}