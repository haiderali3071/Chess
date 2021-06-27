using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Chess
{
    class AI
    {
        private MainWindow main;
        public AI(MainWindow m)
        {
            this.main = m;
        }
        public Image getPieceByName(string name)
        {
            switch (name)
            {
                case "pawn1_white":
                    return main.pawn1_white;

                case "pawn2_white":
                    return main.pawn2_white;

                case "pawn3_white":
                    return main.pawn3_white;

                case "pawn4_white":
                    return main.pawn4_white;

                case "pawn5_white":
                    return main.pawn5_white;

                case "pawn6_white":
                    return main.pawn6_white;

                case "pawn7_white":
                    return main.pawn7_white;

                case "pawn8_white":
                    return main.pawn8_white;

                case "rook1_white":
                    return main.rook1_white;

                case "rook2_white":
                    return main.rook2_white;

                case "knight1_white":
                    return main.knight1_white;

                case "knight2_white":
                    return main.knight2_white;

                case "bishop1_white":
                    return main.bishop1_white;

                case "bishop2_white":
                    return main.bishop2_white;

                case "king_white":
                    return main.king_white;

                case "queen_white":
                    return main.queen_white;


                case "pawn1_black":
                    return main.pawn1_black;

                case "pawn2_black":
                    return main.pawn2_black;

                case "pawn3_black":
                    return main.pawn3_black;

                case "pawn4_black":
                    return main.pawn4_black;

                case "pawn5_black":
                    return main.pawn5_black;

                case "pawn6_black":
                    return main.pawn6_black;

                case "pawn7_black":
                    return main.pawn7_black;

                case "pawn8_black":
                    return main.pawn8_black;

                case "rook1_black":
                    return main.rook1_black;

                case "rook2_black":
                    return main.rook2_black;

                case "knight1_black":
                    return main.knight1_black;

                case "knight2_black":
                    return main.knight2_black;

                case "bishop1_black":
                    return main.bishop1_black;

                case "bishop2_black":
                    return main.bishop2_black;

                case "king_black":
                    return main.king_black;

                case "queen_black":
                    return main.queen_black;

            }

            foreach (var item in main.promotedPieces)
            {
                if (item.Name.Equals(name))
                {
                    return item;
                }
            }

            return null;
        }
        private void saveBoardState(string[,] board)
        {
            Box box = new Box("a1");
            foreach (StackPanel item in main.MyGrid.Children)
            {
                box.reset(item.Name);

                if (item.Children.Count != 0)
                {
                    Image piece = (Image)item.Children[0];


                    board[box.row, box.col] = piece.Name.ToString();

                }
            }
        }
        private void restoreBoardState(string[,] board)
        {
            Box box = new Box("a1");

            foreach (StackPanel item in main.MyGrid.Children)
            {
                if (item.Children.Count != 0)
                {
                    item.Children.RemoveAt(0);
                }

            }


            foreach (StackPanel item in main.MyGrid.Children)
            {
                box.reset(item.Name);
                Image piece = null;

                if (board[box.row, box.col] != null)
                {

                    string piece_name = board[box.row, box.col];
                    piece = getPieceByName(piece_name);
                    item.Children.Add(piece);

                }

            }

        }
        private int getScore(string name)
        {
            int score = 0;

            // AI will favour black
            if (name.Contains("king"))
            {
                score = name.Contains(MainWindow.user_mode) ? 900 : -900;
            }
            else if (name.Contains("queen"))
            {
                score = name.Contains(MainWindow.user_mode) ? 90 : -90;
            }
            else if (name.Contains("rook"))
            {
                score = name.Contains(MainWindow.user_mode) ? 50 : -50;
            }
            else if (name.Contains("bishop"))
            {
                score = name.Contains(MainWindow.user_mode) ? 30 : -30;
            }
            else if (name.Contains("knight"))
            {
                score = name.Contains(MainWindow.user_mode) ? 30 : -30;
            }
            else if (name.Contains("pawn"))
            {
                score = name.Contains(MainWindow.user_mode) ? 10 : -10;
            }

            return score;
        }
        public Node get_computer_turn_node()
        {

            main.local_board = new string[8, 8];
            saveBoardState(main.local_board);


            Node parent = tree();
            balanceScore(parent);
            Node move = getMove(parent);

            restoreBoardState(main.local_board);
            return move;
        }
        private Node getMove(Node parent)
        {
            List<Node> tmp = new List<Node>();
            Node max = parent.childs[0];

            foreach (var item in parent.childs)
            {

                if (item.score >= max.score)
                {
                    if (item.score == max.score)
                    {
                        tmp.Add(item);
                    }
                    max = item;
                }
            }

            // Code to remove low score piece 
            Node last = tmp.Last();
            List<Node> tmp2 = new List<Node>();

            for (int i = tmp.Count - 1; i >= 0; i--)
            {
                if (last.score == tmp.ElementAt(i).score)
                {
                    tmp2.Add(tmp.ElementAt(i));
                }
                else
                {
                    break;
                }
            }

            //If more than one pieces have same score than return random piece
            if (tmp2.Count != 0)
            {
                if (tmp2.ElementAt(0).score == max.score)
                {
                    Random random = new Random();
                    int index = random.Next(tmp2.Count());
                    return tmp2.ElementAt(index);
                }
            }

            return max;
        }
        private void balanceScore(Node parent)
        {
            /*if(parent == null)
            {
                return;
            }

            else{
                Console.WriteLine(parent.piece.Name);
                foreach (Node item in parent.childs)
                {
                    balanceScore(item);
                }

            }*/
            List<int> child_Score = new List<int>();


            foreach (Node item in parent.childs)
            {
                child_Score = new List<int>();


                foreach (var item2 in item.childs)
                {

                    child_Score.Add(item2.score);
                }
                item.score += child_Score.Min();
            }
        }
        private Node tree()
        {
            Node current = new Node(); // Parent Node
            make_tree(current, main.ai_mode, "min");
            make_tree_child(current, MainWindow.user_mode);

            return current;
        }
        private void make_tree_child(Node current, string color)
        {
            foreach (Node item in current.childs)
            {


                main.pieces.movePiece(item.piece, item.h_add, item.d_add);
                make_tree(item, color, "max");





                restoreBoardState(main.local_board);
            }
        }
        private void make_tree(Node current, string color, string type)
        {
            List<string> all = new List<string>();

            all = main.pieces.getAllMoves(color, "yes");


            List<Node> childs = new List<Node>();
            Image piece = null;
            StackPanel h_add_panel = null;
            foreach (var item in all)
            {


                if (item.Contains(color))
                {

                    string piece_name = item.Split(' ')[0];
                    string h_add = item.Split(' ')[1];
                    piece = getPieceByName(piece_name);
                    h_add_panel = getPanelByName(h_add);


                }
                else
                {
                    string d_add_name = item;
                    int score = 0;
                    StackPanel d_add_panel = getPanelByName(d_add_name);

                    if (d_add_panel.Children.Count != 0)
                    {
                        string child_piece_name = ((Image)d_add_panel.Children[0]).Name;
                        score = getScore(child_piece_name);
                    }

                    Node tmp = new Node(piece, h_add_panel, d_add_panel, type, score);
                    childs.Add(tmp);


                }
            }

            current.childs = childs;

        }
        private StackPanel getPanelByName(string name)
        {
            if (name == null)
            {
                return null;
            }

            StackPanel panel = null;
            foreach (StackPanel p in main.MyGrid.Children)
            {
                if (p.Name == name)
                {
                    panel = p;
                    break;
                }
            }
            return panel;
        }

    }
}
