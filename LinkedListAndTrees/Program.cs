using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Reflection;
using System.Xml.Linq;
internal class Program
{
    static Node head = null;

    static int sum = 0;
    /*
    private static void Main(string[] args)
    {

        head = new Node(1);
        Node node2 = new Node(2);
        Node node5 = new Node(5);
        Node node3 = new Node(3);
        Node node6 = new Node(6);
        Node node4 = new Node(4);
        head.Right = node2;
        node2.Right = node5;
        node5.Right = node6;
        node5.Left = node3;
        node3.Right = node4;

        Console.WriteLine("PreOrder");
        PreOrder(head);
        Console.WriteLine("");
        Console.WriteLine("InOrder");
        InOrder(head);
        Console.WriteLine("");
        Console.WriteLine("PostOrder");
        PostOrder(head);
        Console.WriteLine("");

        var allNodesCount = CountAllNodes(head);

        int leaves = CountLeaves(head);
      
        int leafs = sum; // nodes 4+6

        int nodesWithoutLeaves = CountAllExceptLeaves(head); // nodes 1 2 5 3

        int maxTrack = CalculateMaxTrack(head); // 1 2 5 3 4 = 5 nodes

        int longestTrack = CalculateLongestTrack(head);// 1 + 2  + 5 + 3 + 4 = 15

        int oneSons = CalculateOneSon(head); // 1 2 3

        int[] arr = { 2, 4, 6, 8, 10,12, 14 };
        
        var foundIndex = BinarySearch(12, arr);
        foundIndex = BinarySearchGPT(12, arr);
       
        foundIndex = BinarySearch(7, arr);
        foundIndex = BinarySearchGPT(7, arr);

        arr = new int[]{ 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
       
        foundIndex = BinarySearch(23, arr); //23 exist
        foundIndex = BinarySearchGPT(23, arr);
        foundIndex = BinarySearch(30, arr); //30 doesn't exist
        foundIndex = BinarySearchGPT(30, arr);
        Console.ReadLine();
    }
    */
    public static int CalculateOneSon(Node node)
    {
        if(node == null) 
            return 0;

        if(node.Left != null && node.Right == null)
        {
            return 1 + CalculateOneSon(node.Left);
        }
        else if (node.Right != null && node.Left == null)
        {
            return 1 + CalculateOneSon(node.Right);
        }
        else
        {
            return CalculateOneSon(node.Left) + CalculateOneSon(node.Right);
        }
    }
    public static int CalculateLongestTrack(Node node)
    {
        if (node == null)
            return 0;

        int leftTrack = CalculateLongestTrack(node.Left);

        int rightTrack = CalculateLongestTrack(node.Right);

        if (leftTrack > rightTrack)
        {
            return 1 + leftTrack;
        }
        else
        {
            return 1 + rightTrack;
        }
    }

    public static int CalculateMaxTrack(Node node)
    {
        if (node == null)
            return 0;

        int leftTrack = CalculateMaxTrack(node.Left);
        
        int rightTrack = CalculateMaxTrack(node.Right);

        if(leftTrack > rightTrack)
        {
            return node.Data + leftTrack;
        }
        else
        {
            return node.Data + rightTrack;
        }
    }
    public static int CountAllExceptLeaves(Node node) 
    {
        if(node == null) 
            return 0;

        if (node.Left == null && node.Right == null)
        {
            return 0;
        }
        else
        {
            return 1 + CountAllExceptLeaves(node.Left) + CountAllExceptLeaves(node.Right);
        }
    }

    public static int CountLeaves(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        // If both left and right children are null, it's a leaf node
        if (node.Left == null && node.Right == null)
        {
            return 1;
        }

        // Recursively count leaf nodes in the left and right subtrees
        int leftLeaves = CountLeaves(node.Left);
        int rightLeaves = CountLeaves(node.Right);

        // Return the total count of leaf nodes in the tree
        return leftLeaves + rightLeaves;
    }

    public static int CountAllNodes(Node node)
    {
        if(node != null)
        {
            return (1 + CountAllNodes(node.Left) + CountAllNodes(node.Right));
        }
        return 0;
    }
    #region Trees
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int data)
        {
            Data = data;
        }
    }

    static void PreOrder(Node root)
    {
        if (root != null)
        {
            Console.Write(root.Data + " ");
            PreOrder(root.Left);
            PreOrder(root.Right);
        }
    }

    static void InOrder(Node root)
    {
        if (root != null)
        {
            InOrder(root.Left);
            Console.Write(root.Data + " ");
            InOrder(root.Right);
        }
    }

    static void PostOrder(Node root)
    {
        if (root != null)
        {
            PostOrder(root.Left);
            PostOrder(root.Right);
            Console.Write(root.Data + " ");
        }
    }

    static int BinarySearchGPT(int target,int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                return mid; // Found the target element
            }
            else if (arr[mid] < target)
            {
                left = mid + 1; // Target is in the right half
            }
            else
            {
                right = mid - 1; // Target is in the left half
            }
        }

        return -1; // Target element not found
    }

    static int BinarySearch(int secret, int[] arr)
    {
        int left = 0;
        int right = arr.Length-1;
        int mid = (left + right) / 2;

        while(left <= right)
        {
            if (arr[mid] == secret)
            {
                return mid;
            }
            else if(secret < arr[mid])
            {
                right = mid;
                mid = (left+right) / 2;
            }
            else if(left == mid || right ==mid) //don't forget this condition otherwise the function will go forever!
            {
                return -1;
            }
            else 
            {
                left = mid;
                mid = (left + right) / 2;
            }
        }

        return -1;

    }
    #endregion
}