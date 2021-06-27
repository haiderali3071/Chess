using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Chess
{


    public class Pieces
    {
        private Grid Board;

        public Pieces(Grid grid)
        {

            Board = grid;
        }
        private StackPanel getPanelByName(string name)
        {
            if (name == null)
            {
                return null;
            }

            StackPanel panel = null;
            foreach (StackPanel p in Board.Children)
            {
                if (p.Name == name)
                {
                    panel = p;
                    break;
                }
            }
            return panel;
        }
        public List<String> knightMoves(string box)
        {
            List<String> moves = new List<String>();
            Box b = new Box(box);
            StackPanel panel;

            string curr_box = b.top(2);
            if (curr_box != null)
            {
                b.reset(curr_box);
                panel = getPanelByName(b.left());

                for (int i = 0; i < 2; i++)
                {
                    if (panel != null && panel.Children.Count == 0)
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                        ((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);

                    }
                    else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                        !((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);

                    }
                    panel = getPanelByName(b.right());
                }



            }
            b.reset();

            curr_box = b.bottom(2);
            if (curr_box != null)
            {
                b.reset(curr_box);

                panel = getPanelByName(b.left());

                for (int i = 0; i < 2; i++)
                {
                    if (panel != null && panel.Children.Count == 0)
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                        ((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);

                    }
                    else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                        !((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);

                    }
                    panel = getPanelByName(b.right());
                }
            }
            b.reset();

            curr_box = b.left(2);
            if (curr_box != null)
            {
                b.reset(curr_box);

                panel = getPanelByName(b.top());

                for (int i = 0; i < 2; i++)
                {
                    if (panel != null && panel.Children.Count == 0)
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                        ((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);

                    }
                    else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                        !((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);

                    }
                    panel = getPanelByName(b.bottom());
                }
            }
            b.reset();

            curr_box = b.right(2);
            if (curr_box != null)
            {
                b.reset(curr_box);

                panel = getPanelByName(b.top());

                for (int i = 0; i < 2; i++)
                {
                    if (panel != null && panel.Children.Count == 0)
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                        ((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);

                    }
                    else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                        !((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);

                    }
                    panel = getPanelByName(b.bottom());
                }
            }
            b.reset();

            moves = cleanList(moves); //remove nulls false moves out of board

            return moves;
        }
        public List<String> bishopMoves(string box)
        {
            List<String> moves = new List<String>();
            Box b = new Box(box);
            StackPanel panel = null;


            for (int i = 1; i <= 7; i++)
            {
                string curr_box = b.topLeft();
                panel = getPanelByName(curr_box);

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                   ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                    !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else
                {
                    break;
                }


            }
            b.reset();

            for (int i = 1; i <= 7; i++)
            {
                string curr_box = b.topRight();
                panel = getPanelByName(curr_box);

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                   ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                    !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }
            b.reset();

            for (int i = 1; i <= 7; i++)
            {
                string curr_box = b.bottomLeft();
                panel = getPanelByName(curr_box);

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                   ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                    !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }
            b.reset();


            for (int i = 1; i <= 7; i++)
            {
                string curr_box = b.bottomRight();
                panel = getPanelByName(curr_box);

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                   ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                    !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }
            b.reset();

            return moves;

        }
        public List<String> rookMoves(string box)
        {
            List<String> moves = new List<String>();
            Box b = new Box(box);
            StackPanel panel = null;

            for (int i = 1; i <= 7; i++)
            {

                panel = getPanelByName(b.top(i));

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                   ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                    !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 7; i++)
            {

                panel = getPanelByName(b.bottom(i));

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                   ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                    !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 7; i++)
            {

                panel = getPanelByName(b.left(i));

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                   ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                    !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 7; i++)
            {
                panel = getPanelByName(b.right(i));

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                   ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                    !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }

            return moves;

        }
        public List<String> queenMoves(string box)
        {
            List<String> moves = new List<String>();
            Box b = new Box(box);
            StackPanel panel = null;

            for (int i = 1; i <= 7; i++)
            {

                panel = getPanelByName(b.top(i));

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                    !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 7; i++)
            {
                panel = getPanelByName(b.bottom(i));

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 7; i++)
            {
                panel = getPanelByName(b.left(i));

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 7; i++)
            {
                panel = getPanelByName(b.right(i));

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 7; i++)
            {
                string curr_box = b.topLeft();
                panel = getPanelByName(curr_box);

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                    break;
                }
                else
                {

                    break;
                }


            }
            b.reset();

            for (int i = 1; i <= 7; i++)
            {
                string curr_box = b.topRight();
                panel = getPanelByName(curr_box);

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }
            b.reset();

            for (int i = 1; i <= 7; i++)
            {
                string curr_box = b.bottomLeft();
                panel = getPanelByName(curr_box);

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);

                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }
            b.reset();


            for (int i = 1; i <= 7; i++)
            {
                string curr_box = b.bottomRight();
                panel = getPanelByName(curr_box);

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                   ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                    b.reset(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }
            b.reset();


            return moves;

        }
        public List<String> pawnMoves(string box)
        {
            List<String> moves = new List<String>();
            Box b = new Box(box);

            //If pawns are light color
            if (!MainWindow.selectedPiece.Name.Contains("black"))
            {
                StackPanel pane = null;
                if (b.getRow() == 1)
                {
                    // Can be two step or 1


                    string curr_box1 = b.top();

                    //following code is for two steps
                    for (int i = 0; i < 2; i++)
                    {

                        pane = getPanelByName(curr_box1);

                        if (pane != null && pane.Children.Count == 0) // panel can't be null
                        {
                            moves.Add(pane.Name);
                        }
                        else
                        {
                            break;
                        }
                        curr_box1 = b.doubleTop();
                    }

                }
                else
                {
                    string curr_box1 = b.top();
                    pane = null;

                    pane = getPanelByName(curr_box1);

                    if (pane != null && pane.Children.Count == 0) // panel can't be null
                    {
                        moves.Add(pane.Name);
                    }

                }

                StackPanel panel = null;
                string curr_box = b.topLeft();
                b.reset();

                for (int i = 0; i < 2; i++)
                {

                    panel = getPanelByName(curr_box);

                    if (panel != null && panel.Children.Count == 1 && ((Image)panel.Children[0]).Name.Contains("black")) // panel can't be null
                    {
                        moves.Add(panel.Name);
                    }
                    b.reset();
                    curr_box = b.topRight();
                }


            }

            //else If pawns are black color
            else
            {
                StackPanel panel = null;
                if (b.getRow() == 6)
                {
                    // Can be two step or 1


                    string curr_box1 = b.bottom();

                    //following code is for two steps

                    for (int i = 0; i < 2; i++)
                    {
                        panel = getPanelByName(curr_box1);

                        if (panel != null && panel.Children.Count == 0) // panel can't be null
                        {
                            moves.Add(panel.Name);
                        }
                        else
                        {
                            break;
                        }
                        curr_box1 = b.bottom(2);
                    }

                }
                else
                {
                    string curr_box1 = b.bottom();
                    panel = getPanelByName(curr_box1);

                    if (panel != null && panel.Children.Count == 0) // panel can't be null
                    {
                        moves.Add(panel.Name);
                    }
                }

                StackPanel pane = null;
                string curr_box = b.bottomLeft();
                b.reset();

                for (int i = 0; i < 2; i++)
                {
                    pane = getPanelByName(curr_box);

                    if (pane != null && pane.Children.Count == 1 && !((Image)pane.Children[0]).Name.Contains("black")) // panel can't be null
                    {
                        moves.Add(pane.Name);
                    }
                    b.reset();
                    curr_box = b.bottomRight();
                }
            }

            return moves;
        }
        public List<String> kingMoves(string box)
        {

            List<String> moves = new List<String>();
            Box b = new Box(box);

            for (int i = 0; i < 6; i++)
            {
                StackPanel panel = null;
                switch (i)
                {
                    case 0:
                        panel = getPanelByName(b.top());
                        break;
                    case 1:

                        panel = getPanelByName(b.bottom());

                        break;
                    case 2:
                        panel = getPanelByName(b.topLeft());

                        break;
                    case 3:
                        panel = getPanelByName(b.topRight());

                        break;
                    case 4:
                        panel = getPanelByName(b.bottomLeft());

                        break;
                    case 5:
                        panel = getPanelByName(b.bottomRight());
                        break;
                }

                if (panel != null && panel.Children.Count == 0)
                {
                    moves.Add(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                       ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                }
                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                        !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    moves.Add(panel.Name);
                }
            }




            if (!MainWindow.kingMoved_black && MainWindow.selectedPiece.Name.Contains("black"))
            {
                StackPanel panel = null;
                int count = 0;

                if (!MainWindow.rook2Moved_black)
                {
                    for (int i = 1; i <= 2; i++)
                    {
                        string curr_box = b.right(i);

                        panel = getPanelByName(curr_box);

                        if (panel != null && panel.Children.Count == 0)
                        {

                            moves.Add(panel.Name);
                        }
                        else
                        {
                            if (i == 1)
                            {
                                panel = getPanelByName(b.right());


                                if (panel != null && panel.Children.Count == 0)
                                {
                                    moves.Add(panel.Name);
                                }
                                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                                       ((Image)panel.Children[0]).Name.Contains("black"))
                                {
                                    moves.Add(panel.Name);
                                }
                                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                                        !((Image)panel.Children[0]).Name.Contains("black"))
                                {
                                    moves.Add(panel.Name);
                                }
                            }
                            break;
                        }
                    }

                }
                else
                {

                    panel = getPanelByName(b.right());


                    if (panel != null && panel.Children.Count == 0)
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                           ((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                            !((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);
                    }


                }


                if (!MainWindow.rook1Moved_black)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        string curr_box = b.left(i);

                        panel = getPanelByName(curr_box);

                        if (panel != null && panel.Children.Count == 0)
                        {
                            count++;
                            moves.Add(panel.Name);
                        }
                        else
                        {
                            if (i == 1)
                            {
                                panel = getPanelByName(b.left());


                                if (panel != null && panel.Children.Count == 0)
                                {
                                    moves.Add(panel.Name);
                                }
                                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                                       ((Image)panel.Children[0]).Name.Contains("black"))
                                {
                                    moves.Add(panel.Name);
                                }
                                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                                        !((Image)panel.Children[0]).Name.Contains("black"))
                                {
                                    moves.Add(panel.Name);
                                }
                            }
                            break;
                        }
                    }

                    if (count > 1)
                    {
                        moves.RemoveAt(moves.Count - 1);
                    }
                }
                else
                {
                    panel = getPanelByName(b.left());


                    if (panel != null && panel.Children.Count == 0)
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                           ((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                            !((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);
                    }
                }


            }
            else if (!MainWindow.kingMoved_white && !MainWindow.selectedPiece.Name.Contains("black"))
            {
                StackPanel panel = null;
                int count = 0;

                if (!MainWindow.rook2Moved)
                {
                    for (int i = 1; i <= 2; i++)
                    {
                        string curr_box = b.right(i);

                        panel = getPanelByName(curr_box);

                        if (panel != null && panel.Children.Count == 0)
                        {

                            moves.Add(panel.Name);
                        }
                        else
                        {
                            if (i == 1)
                            {
                                panel = getPanelByName(b.right());


                                if (panel != null && panel.Children.Count == 0)
                                {
                                    moves.Add(panel.Name);
                                }
                                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                                       ((Image)panel.Children[0]).Name.Contains("black"))
                                {
                                    moves.Add(panel.Name);
                                }
                                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                                        !((Image)panel.Children[0]).Name.Contains("black"))
                                {
                                    moves.Add(panel.Name);
                                }
                            }
                            break;
                        }
                    }

                }
                else
                {
                    panel = getPanelByName(b.right());


                    if (panel != null && panel.Children.Count == 0)
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                           ((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                            !((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);
                    }
                }


                if (!MainWindow.rook1Moved)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        string curr_box = b.left(i);
                        panel = getPanelByName(curr_box);

                        if (panel != null && panel.Children.Count == 0)
                        {
                            count++;
                            moves.Add(panel.Name);
                        }
                        else
                        {
                            if (i == 1)
                            {
                                panel = getPanelByName(b.left());


                                if (panel != null && panel.Children.Count == 0)
                                {
                                    moves.Add(panel.Name);
                                }
                                else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                                       ((Image)panel.Children[0]).Name.Contains("black"))
                                {
                                    moves.Add(panel.Name);
                                }
                                else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                                        !((Image)panel.Children[0]).Name.Contains("black"))
                                {
                                    moves.Add(panel.Name);
                                }
                            }
                            break;
                        }
                    }

                    if (count > 1)
                    {
                        moves.RemoveAt(moves.Count - 1);
                    }
                }
                else
                {
                    panel = getPanelByName(b.left());


                    if (panel != null && panel.Children.Count == 0)
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                           ((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                            !((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);
                    }
                }


            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    StackPanel panel = null;
                    switch (i)
                    {
                        case 0:
                            panel = getPanelByName(b.left());
                            break;
                        case 1:

                            panel = getPanelByName(b.right());

                            break;

                    }

                    if (panel != null && panel.Children.Count == 0)
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && !MainWindow.selectedPiece.Name.Contains("black") &&
                           ((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);
                    }
                    else if (panel != null && panel.Children.Count != 0 && MainWindow.selectedPiece.Name.Contains("black") &&
                            !((Image)panel.Children[0]).Name.Contains("black"))
                    {
                        moves.Add(panel.Name);
                    }
                }

            }

            StackPanel p = getPanelByName(box);
            string color = getPieceColor(((Image)p.Children[0]).Name);

            moves = cleanList(moves);
            List<string> moves_modified = new List<string>();
            foreach (var item in moves)
            {
                if (!isBothKingAdjacent(item, color))
                {
                    moves_modified.Add(item);
                }
            }
            return moves_modified;
        }
        private string getPieceColor(string name)
        {
            return name.Split('_')[1];
        }
        private bool isBothKingAdjacent(string move, string color)
        {
            Box box = new Box(move);
            List<string> adjacentBoxes = new List<string>();
            adjacentBoxes.Add(box.top());
            adjacentBoxes.Add(box.bottom());
            adjacentBoxes.Add(box.left());
            adjacentBoxes.Add(box.right());
            adjacentBoxes.Add(box.topLeft());
            adjacentBoxes.Add(box.topRight());
            adjacentBoxes.Add(box.bottomLeft());
            adjacentBoxes.Add(box.bottomRight());



            adjacentBoxes = cleanList(adjacentBoxes);



            foreach (var item in adjacentBoxes)
            {
                StackPanel tmp = getPanelByName(item);
                if (tmp.Children.Count != 0)
                {
                    Image piece = (Image)tmp.Children[0];
                    if (getPieceColor(piece.Name) != color && piece.Name.Contains("king"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private List<string> cleanList(List<String> l)
        {
            List<string> clean_list = new List<string>();
            foreach (string item in l)
            {
                if (!(item == null))
                {
                    clean_list.Add(item);
                }
            }
            return clean_list;
        }
        public List<string> getAllMoves(string color, string king_moves)
        {
            List<List<string>> all_moves = new List<List<string>>();



            foreach (StackPanel block in Board.Children)
            {
                if (block.Children.Count != 0)
                {

                    Image piece = (Image)block.Children[0];
                    if (piece.Name.Contains(color))
                    {
                        MainWindow.selectedPiece = piece;
                        if (piece.Name.Contains("pawn"))
                        {
                            List<string> moves = pawnMoves(block.Name);
                            moves = cleanList(moves);
                            if (moves.Count != 0)
                            {
                                List<string> n = new List<string>();
                                n.Add(piece.Name + " " + block.Name);
                                all_moves.Add(n);
                                all_moves.Add(moves);
                            }

                        }

                        else if (piece.Name.Contains("rook"))
                        {
                            List<string> moves = rookMoves(block.Name);
                            moves = cleanList(moves);
                            if (moves.Count != 0)
                            {
                                List<string> n = new List<string>();
                                n.Add(piece.Name + " " + block.Name);
                                all_moves.Add(n);
                                all_moves.Add(moves);
                            }
                        }

                        else if (piece.Name.Contains("knight"))
                        {
                            List<string> moves = knightMoves(block.Name);
                            moves = cleanList(moves);
                            if (moves.Count != 0)
                            {
                                List<string> n = new List<string>();
                                n.Add(piece.Name + " " + block.Name);
                                all_moves.Add(n);
                                all_moves.Add(moves);
                            }

                        }

                        else if (piece.Name.Contains("bishop"))
                        {
                            List<string> moves = bishopMoves(block.Name);
                            moves = cleanList(moves);
                            if (moves.Count != 0)
                            {
                                List<string> n = new List<string>();
                                n.Add(piece.Name + " " + block.Name);
                                all_moves.Add(n);
                                all_moves.Add(moves);
                            }

                        }

                        else if (piece.Name.Contains("queen"))
                        {
                            List<string> moves = queenMoves(block.Name);
                            moves = cleanList(moves);
                            if (moves.Count != 0)
                            {
                                List<string> n = new List<string>();
                                n.Add(piece.Name + " " + block.Name);
                                all_moves.Add(n);
                                all_moves.Add(moves);
                            }

                        }

                        else if (piece.Name.Contains("king"))
                        {
                            if (king_moves == "no")
                            {
                                continue;
                            }
                            List<string> moves = kingMoves(block.Name);
                            moves = cleanList(moves);
                            if (moves.Count != 0)
                            {
                                List<string> n = new List<string>();
                                n.Add(piece.Name + " " + block.Name);
                                all_moves.Add(n);
                                all_moves.Add(moves);
                            }

                        }
                    }

                }
            }


            List<string> tmp = new List<string>();
            foreach (var list in all_moves)
            {
                foreach (var item in list)
                {
                    tmp.Add(item);
                }
            }
            MainWindow.selectedPiece = null;
            return tmp;
        }
        public StackPanel getRandomPiecePanel(string color)
        {
            List<string> moves = getAllMoves(color, "yes");
            var pieces = from m in moves where m.Contains(color) select m;

            Random random = new Random();
            int index = random.Next(pieces.Count());
            string panel_name = pieces.ElementAt(index).Split(' ')[1];


            return getPanelByName(panel_name);
        }
        public StackPanel getRandomMovePanel(string selected_piece_panel_name, string piece)
        {
            List<string> moves = null;
            if (piece.Contains("pawn"))
            {
                moves = pawnMoves(selected_piece_panel_name);
            }
            else if (piece.Contains("rook"))
            {
                moves = rookMoves(selected_piece_panel_name);
            }
            else if (piece.Contains("knight"))
            {
                moves = knightMoves(selected_piece_panel_name);
            }
            else if (piece.Contains("bishop"))
            {
                moves = bishopMoves(selected_piece_panel_name);
            }
            else if (piece.Contains("king"))
            {
                moves = kingMoves(selected_piece_panel_name);
            }
            else if (piece.Contains("queen"))
            {
                moves = queenMoves(selected_piece_panel_name);
            }

            Random random = new Random();
            int index = random.Next(moves.Count());
            string move_panel_name = moves.ElementAt(index);
            return getPanelByName(move_panel_name);
        }
        public void movePiece(Image piece, StackPanel home_panel, StackPanel dest_panel)
        {
            home_panel.Children.RemoveAt(0);

            if (dest_panel.Children.Count == 0)
            {
                dest_panel.Children.Add(piece);
            }
            else
            {
                dest_panel.Children.RemoveAt(0);
                dest_panel.Children.Add(piece);
            }
        }

    }
}
