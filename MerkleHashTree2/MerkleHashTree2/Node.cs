using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MerkleHashTree2
{
    public class Node
    {
        int key;
        string value;
        Node left, right;
        bool isCopied;

        public Node(string value, Node left = null, Node right = null, bool isCopied = false)
        {
            this.key = key;
            this.value = value;
            this.left = left;
            this.right = right;
            this.isCopied = isCopied;
        }
    }
}
