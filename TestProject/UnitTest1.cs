using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab15;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass] 
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Graph graph = new Graph("G.grf");
            graph.BellmanFord(0);
            List<KeyValuePair<Node, Node>> MinSpan = new List<KeyValuePair<Node, Node>>();
            MinSpan.Add(new KeyValuePair<Node, Node>(graph.Verts[0], graph.Verts[1]));
            CollectionAssert.AreEqual(MinSpan, graph.MinSpan);
            Assert.AreEqual(MinSpan.Count, graph.MinSpan.Count);
        }
    }
}