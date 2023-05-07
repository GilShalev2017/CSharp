using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class HackerProgram
{ 
    /*
    private static void Main(string[] args)
    {
        Node head = new Node(null, 11);
        Node nodeA = new Node("A", 5);
        Node node6 = new Node(null, 6);
        Node nodeR = new Node("R", 2);
        Node node4 = new Node(null, 4);
        Node node2 = new Node(null, 2);
        Node nodeB = new Node("B", 2);
        Node nodeq2 = new Node(null, 2);
        Node nodeC = new Node("C", 1);
        Node nodeD = new Node("D", 1);
        head.Left = nodeA;
        head.Right = node6;
        node6.Left = nodeR;
        node6.Right = node4;
        node4.Left = nodeq2;
        node4.Right = nodeB;
        nodeq2.Left = nodeC;
        nodeq2.Right = nodeD;

        Decode_huff(head,"01111001100011010111100");
    }
    */
    static void BuildEdges(Node node,Dictionary<string, string> dic)
    {
        if (node != null)
        {
            if(node.Left == null && node.Right == null)
            {
                //This is a leaf
                if(node.Data != null)
                    dic.Add(node.BinaryPath, node.Data);
            }
            if (node.Left != null)
            {
                node.Left.BinaryPath = node.BinaryPath + "0";
                BuildEdges(node.Left, dic);
            }
            if (node.Right != null)
            {
                node.Right.BinaryPath = node.BinaryPath + "1";
                BuildEdges(node.Right, dic);
            }
        }
    }
    static string Decode_huff(Node root, string encoded)
    {
        string decoded = "";
      
        Dictionary<string, string> dic = new Dictionary<string, string>();//key = "binary" path, value = charcater

        BuildEdges(root, dic);
        
        int counter = 1;

        while (encoded.Length > 0)
        {
            var curSegment = encoded.Substring(0, counter);

            if (dic.ContainsKey(curSegment))
            {
                var foundChar = dic[curSegment];
                decoded = decoded + foundChar;
                encoded = encoded.Remove(0,counter);
                counter = 1;
            }
            else
            {
                counter++;
            }
        }
        return decoded;
    }
    internal class Node
    {
        public string? Data { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public int ChildrenCount { get; set; }
        public string BinaryPath { get; set; }
        public Node(string data, int count)
        {
            Data = data;
            ChildrenCount = count;
            BinaryPath = "";
            Left = null;
            Right = null;
        }
    }
}
