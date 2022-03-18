using System;

//Alıntı: geeksforgeeks.org

namespace DS_Proje_4
{
    class Program
    {
        public static void Main(string[] args)
        {
            var tree = new AVLTree();
            var random = new Random();

            for (int i = 0; i < 6; i++)
            {
                tree.root = tree.Insert(tree.root, random.Next(10, 99));
            }

            Console.Write("Ağacın Preorder dolaşılması: ");
            tree.PreOrder(tree.root);
            Console.WriteLine();

            Console.ReadKey();
        }
    }

    public class Node
    {
        public int key, height;
        public Node left, right;

        public Node(int d)
        {
            key = d;
            height = 1;
        }
    }

    public class AVLTree
    {
        internal Node root;

        // Ağacın yüksekliğini bul
        private int Height(Node N)
        {
            if (N == null)
                return 0;

            return N.height;
        }

        private int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        private Node RightRotate(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;

            // Rotasyon işlemi
            x.right = y;
            y.left = T2;

            // Yükseklik güncelleme 
            y.height = Max(Height(y.left), Height(y.right)) + 1;
            x.height = Max(Height(x.left), Height(x.right)) + 1;

            // Yeni kök
            return x;
        }

        Node LeftRotate(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            // Rotasyon işlemi
            y.left = x;
            x.right = T2;

            // Yükseklikleri güncelle 
            x.height = Max(Height(x.left), Height(x.right)) + 1;
            y.height = Max(Height(y.left), Height(y.right)) + 1;

            // Yeni kök
            return y;
        }

        // N düğümü için denge faktörü döndür
        private int GetBalance(Node N)
        {
            if (N == null)
                return 0;

            return Height(N.left) - Height(N.right);
        }

        public Node Insert(Node node, int key)
        {
            // Standart BST ekleme işlemi
            // Birden fazla aynı değere izin verilmiyor
            if (node == null)
                return (new Node(key));

            if (key < node.key)
                node.left = Insert(node.left, key);
            else if (key > node.key)
                node.right = Insert(node.right, key);
            else 
                return node;

            // Ancestor için yükseklik güncelleme
            node.height = 1 + Max(Height(node.left), Height(node.right));

            int balance = GetBalance(node);

            // Düğümde dengenin bozulması durumunda yapılacaklar
            
            // Sol-Sol durumu
            if (balance > 1 && key < node.left.key)
                return RightRotate(node);

            // Sağ-Sağ durumu 
            if (balance < -1 && key > node.right.key)
                return LeftRotate(node);

            // Sol-Sağ durumu 
            if (balance > 1 && key > node.left.key)
            {
                node.left = LeftRotate(node.left);
                return RightRotate(node);
            }

            // Sağ-Sol durumu 
            if (balance < -1 && key < node.right.key)
            {
                node.right = RightRotate(node.right);
                return LeftRotate(node);
            }

            return node;
        }

        // PreOrder dolaşım
        internal void PreOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.key + " ");
                PreOrder(node.left);
                PreOrder(node.right);
            }
        }
    }
}
