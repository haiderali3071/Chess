using System.Collections.Generic;
using System.Windows.Controls;

namespace Chess
{
    public class Node
    {
        public Image piece;
        public StackPanel h_add;
        public StackPanel d_add;
        public string type;
        public int score;
        public string[,] board;
        public List<Node> childs = new List<Node>();

        public Node()
        {
            //this constructor only be used for first node.
            type = "max";
            piece = new Image();
            piece.Name = "Parent";
        }

        public Node(Image piece, StackPanel h_add, StackPanel d_add, string type, int score)
        {
            this.piece = piece;
            this.h_add = h_add;
            this.d_add = d_add;
            this.type = type; ;
            this.score = score;
        }


    }
}
