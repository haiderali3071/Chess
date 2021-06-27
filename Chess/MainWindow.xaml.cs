using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum Mode { with_Human, with_Computer };
    public partial class MainWindow : Window
    {
        public Pieces pieces;
        public static Mode mode;
        public static string user_mode;
        public string[,] local_board = new string[8, 8];
        private string selectedBox;
        private StackPanel selectedPanel;
        private string selectedPanelColor;
        public static Image selectedPiece;
        private bool pieceSelected;
        public static bool kingMoved_white = false;
        public static bool rook1Moved = false;
        public static bool rook2Moved = false;
        public static bool kingMoved_black = false;
        public static bool rook1Moved_black = false;
        public static bool rook2Moved_black = false;
        private string promotePiece = null;
        private StackPanel p;
        private bool promotionDone = true;
        private bool whiteTurn;
        private string kingBox_white = "e1";
        private string kingBox_black = "e8";
        private List<String> checkRoad = new List<string>();
        public string ai_mode;
        private int user_promotion = 3;
        private int ai_promotion = 0;
        private List<string> moves_to_use_in_promotion_section;
        private Image piece_to_use_in_promotion_section;
        private bool isPieceRemoved_to_use_in_promotion_section;
        public List<Image> promotedPieces = new List<Image>();
        private int ai_moves_counter = 0;

        //bool isBlackMoved = true;
        //bool isWhiteMoved = true;
        public MainWindow()
        {
            InitializeComponent();
            piecesForPromotion.Visibility = Visibility.Hidden;
            pieces = new Pieces(MyGrid);

            whiteTurn = true;
            if (user_mode == "white")
            {

                ai_mode = "black";
            }
            else
            {
                changeBoardDirection();
                ai_mode = "white";
                computer_turn();
            }

        }

        private void changeBoardDirection()
        {
            foreach (StackPanel item in MyGrid.Children)
            {
                char[] name = item.Name.ToCharArray();
                char n1 = name[0];
                char n2 = name[1];

                switch (n1)
                {
                    case 'a':
                        n1 = 'h';
                        break;

                    case 'b':
                        n1 = 'g';
                        break;

                    case 'c':
                        n1 = 'f';
                        break;

                    case 'd':
                        n1 = 'e';
                        break;

                    case 'e':
                        n1 = 'd';
                        break;

                    case 'f':
                        n1 = 'c';
                        break;

                    case 'g':
                        n1 = 'b';
                        break;

                    case 'h':
                        n1 = 'a';
                        break;
                }

                switch (n2)
                {
                    case '8':
                        n2 = '1';
                        break;

                    case '7':
                        n2 = '2';
                        break;

                    case '6':
                        n2 = '3';
                        break;

                    case '5':
                        n2 = '4';
                        break;

                    case '4':
                        n2 = '5';
                        break;

                    case '3':
                        n2 = '6';
                        break;

                    case '2':
                        n2 = '7';
                        break;

                    case '1':
                        n2 = '8';
                        break;
                }


                item.Name = char.ToString(n1) + char.ToString(n2);

                if (item.Children.Count != 0)
                {
                    Image piece = ((Image)item.Children[0]);

                    string king = "king black.png";
                    string queen = "queen black.png";
                    string pawn = "pawn black.png";
                    string bishop = "bishop black.png";
                    string knight = "knight black.png";
                    string rook = "rook black.png";

                    if (piece.Name.Contains("white"))
                    {
                        piece.Name = piece.Name.Split('_')[0] + "_black";

                    }
                    else
                    {
                        piece.Name = piece.Name.Split('_')[0] + "_white";

                        king = "king white.png";
                        queen = "queen white.png";
                        pawn = "pawn white.png";
                        bishop = "bishop white.png";
                        knight = "knight white.png";
                        rook = "rook white.png";
                    }


                    if (piece.Name.Contains("king"))
                    {
                        piece.Source = new BitmapImage(new Uri(@"C:\\Users\\Haider Ali\\source\\repos\\Chess\\Chess\\chess pieces\\" + king));
                    }
                    else if (piece.Name.Contains("queen"))
                    {
                        piece.Source = new BitmapImage(new Uri(@"C:\\Users\\Haider Ali\\source\\repos\\Chess\\Chess\\chess pieces\\" + queen));
                    }
                    else if (piece.Name.Contains("pawn"))
                    {
                        piece.Source = new BitmapImage(new Uri(@"C:\\Users\\Haider Ali\\source\\repos\\Chess\\Chess\\chess pieces\\" + pawn));
                    }
                    else if (piece.Name.Contains("bishop"))
                    {
                        piece.Source = new BitmapImage(new Uri(@"C:\\Users\\Haider Ali\\source\\repos\\Chess\\Chess\\chess pieces\\" + bishop));
                    }
                    else if (piece.Name.Contains("knight"))
                    {
                        piece.Source = new BitmapImage(new Uri(@"C:\\Users\\Haider Ali\\source\\repos\\Chess\\Chess\\chess pieces\\" + knight));
                    }
                    else if (piece.Name.Contains("rook"))
                    {
                        //code to put rook1 & rook2 on appropriate box
                        n2 = piece.Name[4];
                        n1 = n2;
                        switch (n2)
                        {
                            case '1':
                                n2 = '2';
                                break;
                            case '2':
                                n2 = '1';
                                break;
                        }
                        piece.Name = piece.Name.Split(n1)[0] + n2 + piece.Name.Split(n1)[1];
                        piece.Source = new BitmapImage(new Uri(@"C:\\Users\\Haider Ali\\source\\repos\\Chess\\Chess\\chess pieces\\" + rook));
                    }
                }
            }

            aa.Content = "h";
            bb.Content = "g";
            cc.Content = "f";
            dd.Content = "e";
            ee.Content = "d";
            ff.Content = "c";
            gg.Content = "b";
            hh.Content = "a";

            _1.Content = "8";
            _2.Content = "7";
            _3.Content = "6";
            _4.Content = "5";
            _5.Content = "4";
            _6.Content = "3";
            _7.Content = "2";
            _8.Content = "1";

            swapPieces();
        }
        private void swapPieces()
        {
            Image tmp = king_white;
            king_white = king_black;
            king_black = tmp;

            tmp = queen_white;
            queen_white = queen_black;
            queen_black = tmp;

            tmp = knight1_black;
            knight1_black = knight1_white;
            knight1_white = tmp;

            tmp = knight2_black;
            knight2_black = knight2_white;
            knight2_white = tmp;

            tmp = bishop1_black;
            bishop1_black = bishop1_white;
            bishop1_white = tmp;

            tmp = bishop2_black;
            bishop2_black = bishop2_white;
            bishop2_white = tmp;


            tmp = rook1_black;
            rook1_black = rook1_white;
            rook1_white = tmp;

            tmp = rook2_black;
            rook2_black = rook2_white;
            rook2_white = tmp;

            tmp = pawn1_black;
            pawn1_black = pawn1_white;
            pawn1_white = tmp;

            tmp = pawn2_black;
            pawn2_black = pawn2_white;
            pawn2_white = tmp;

            tmp = pawn3_black;
            pawn3_black = pawn3_white;
            pawn3_white = tmp;

            tmp = pawn4_black;
            pawn4_black = pawn4_white;
            pawn4_white = tmp;

            tmp = pawn5_black;
            pawn5_black = pawn5_white;
            pawn5_white = tmp;

            tmp = pawn6_black;
            pawn6_black = pawn6_white;
            pawn6_white = tmp;

            tmp = pawn7_black;
            pawn7_black = pawn7_white;
            pawn7_white = tmp;

            tmp = pawn8_black;
            pawn8_black = pawn8_white;
            pawn8_white = tmp;


            //###########################

            tmp = rook2_black;
            rook2_black = rook1_black;
            rook1_black = tmp;

            tmp = rook1_white;
            rook1_white = rook2_white;
            rook2_white = tmp;

            getPanelByName("e8").Children.RemoveAt(0);
            getPanelByName("d8").Children.RemoveAt(0);
            getPanelByName("e8").Children.Add(king_black);
            getPanelByName("d8").Children.Add(queen_black);


            getPanelByName("e1").Children.RemoveAt(0);
            getPanelByName("d1").Children.RemoveAt(0);
            getPanelByName("e1").Children.Add(king_white);
            getPanelByName("d1").Children.Add(queen_white);


            /*tmp = rook2_black;
            rook2_black = rook1_black*/

        }
        private void prmotePieces_MouseEnter(object sender, MouseEventArgs e)
        {
            Image i = ((Image)sender);

            foreach (Image img in piecesForPromotion.Children)
            {
                if (img != i)
                {
                    img.Visibility = Visibility.Hidden;
                }
            }

        }
        private void prmotePieces_MouseLeave(object sender, MouseEventArgs e)
        {
            Image i = ((Image)sender);

            foreach (Image img in piecesForPromotion.Children)
            {
                img.Visibility = Visibility.Visible;

            }
        }
        private void promote_Click(Object sender, MouseButtonEventArgs e)
        {

            Image i = ((Image)sender);
            promotePiece = i.Name;
            bool isBlack = false;
            piecesForPromotion.Visibility = Visibility.Hidden;

            string rook = "rook white.png";
            string queen = "queen white.png";
            string bishop = "bishop white.png";
            string knight = "knight white.png";

            if (selectedPiece.Name.Contains("black"))
            {
                isBlack = true;
                rook = rook.Replace("white", "black");
                queen = queen.Replace("white", "black");
                bishop = bishop.Replace("white", "black");
                knight = knight.Replace("white", "black");
            }

            switch (promotePiece)
            {
                case "q":
                    selectedPiece.Source = new BitmapImage(new Uri(@"C:\\Users\\Haider Ali\\source\\repos\\Chess\\Chess\\chess pieces\\" + queen));
                    selectedPiece.Name = "queen";
                    break;

                case "r":
                    selectedPiece.Source = new BitmapImage(new Uri(@"C:\\Users\\Haider Ali\\source\\repos\\Chess\\Chess\\chess pieces\\" + rook));
                    selectedPiece.Name = "rook";
                    break;

                case "b":
                    selectedPiece.Source = new BitmapImage(new Uri(@"C:\\Users\\Haider Ali\\source\\repos\\Chess\\Chess\\chess pieces\\" + bishop));
                    selectedPiece.Name = "bishop";
                    break;

                case "k":
                    selectedPiece.Source = new BitmapImage(new Uri(@"C:\\Users\\Haider Ali\\source\\repos\\Chess\\Chess\\chess pieces\\" + knight));
                    selectedPiece.Name = "knight";
                    break;
            }

            if (isBlack)
            {
                selectedPiece.Name += user_promotion + "_black";
            }
            else
            {
                selectedPiece.Name += user_promotion + "_white";
            }



            normalColor(selectedPanel); // background back at normal
            selectedPanel.Children.RemoveAt(0); //remove piece
            p.Children.Add(selectedPiece);
            promotionDone = true;

            promotedPieces.Add(selectedPiece);

            //Illusion to Code
            //Prevent king from check by avoiding to move any piece that blocking check

            //For White King
            Image tem_piece = selectedPiece;
            selectedPiece = king_white;
            if (!tem_piece.Name.Contains("black") && isCheck(kingBox_white))
            {
                p.Children.RemoveAt(0);
                selectedPanel.Children.Add(tem_piece);
                selectedPiece = tem_piece;
                if (isPieceRemoved_to_use_in_promotion_section)
                {
                    p.Children.Add(piece_to_use_in_promotion_section);
                }
                return;
            }

            //For Black King
            selectedPiece = king_black;
            if (tem_piece.Name.Contains("black") && isCheck(kingBox_black))
            {
                p.Children.RemoveAt(0);
                selectedPanel.Children.Add(tem_piece);
                selectedPiece = tem_piece;
                if (isPieceRemoved_to_use_in_promotion_section)
                {
                    p.Children.Add(piece_to_use_in_promotion_section);
                }
                return;
            }



            // Switch Turns
            if (whiteTurn)
            {
                whiteTurn = false;
                selectedPiece = king_black;
                string[] local_check_road = new string[64];
                if (isCheck(kingBox_black))
                {
                    checkRoad.CopyTo(local_check_road);
                    moves_to_use_in_promotion_section = pieces.kingMoves(kingBox_black);
                    getPanelByName(kingBox_black).Children.RemoveAt(0); // remove king temporary 
                    foreach (string m in moves_to_use_in_promotion_section)
                    {

                        if (!isCheck(m))
                        {
                            getPanelByName(kingBox_black).Children.Add(king_black); // add again if king has escape


                            // AI Black Turn
                            if (user_mode == "white")
                            {
                                computer_turn();
                            }
                            return;
                        }
                    }
                    if (getPanelByName(kingBox_black).Children.Count == 0)
                        getPanelByName(kingBox_black).Children.Add(king_black); // add again if king dont has escape

                    List<String> black_all_moves = pieces.getAllMoves("black", "no");
                    foreach (var item in local_check_road)
                    {
                        if (black_all_moves.Contains(item))
                        {
                            //AI Black Turn
                            if (user_mode == "white")
                            {
                                computer_turn();
                            }
                            return;
                        }
                    }

                    MessageBox.Show("Checkmate! White Wins...");
                    MyGrid.IsEnabled = false;
                }
                else
                {
                    if (user_mode == "white")
                    {
                        computer_turn();
                    }
                }

            }
            else
            {
                whiteTurn = true;
                selectedPiece = king_white;
                List<string> local_check_road = null;
                if (isCheck(kingBox_white))
                {
                    local_check_road = checkRoad;
                    moves_to_use_in_promotion_section = pieces.kingMoves(kingBox_white);
                    getPanelByName(kingBox_white).Children.RemoveAt(0); // remove king temporary 
                    foreach (string m in moves_to_use_in_promotion_section)
                    {
                        if (!isCheck(m))
                        {
                            getPanelByName(kingBox_white).Children.Add(king_white); // add again if king has escape

                            // AI White Turn
                            if (user_mode == "black")
                            {
                                computer_turn();
                            }
                            return;
                        }
                    }

                    if (getPanelByName(kingBox_white).Children.Count == 0)
                        getPanelByName(kingBox_white).Children.Add(king_white); // add again if king dont has escape

                    List<String> white_all_moves = pieces.getAllMoves("white", "no");
                    foreach (var item in local_check_road)
                    {
                        if (white_all_moves.Contains(item))
                        {
                            // AI White Turn
                            if (user_mode == "black")
                            {
                                computer_turn();
                            }
                            return;
                        }
                    }

                    MessageBox.Show("Checkmate! Black Wins...");
                    MyGrid.IsEnabled = false;
                }
                else
                {
                    // AI White Turn
                    if (user_mode == "black")
                    {
                        computer_turn();
                    }
                }
            }

            selectedPiece = null;
        }
        private void piece_click_by_human(Object sender, MouseButtonEventArgs e)
        {
            p = ((StackPanel)sender);

            if (!promotionDone)
            {
                return;
            }

            if (p.Children.Count != 0 && !(whiteTurn == true ^ !((Image)p.Children[0]).Name.Contains("black")))
            {

                if (pieceSelected == true)
                {
                    normalColor(selectedPanel);
                }
                selectedPanel = p;
                selectedBox = p.Name;

                if (p.Background.ToString() != "#FF808080")
                {
                    selectedPanelColor = p.Background.ToString(); // Avoide Gray Color if in case double clicked
                }
                selectedPiece = (Image)p.Children[0];

                p.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);
                pieceSelected = true;
            }
            else
            {

                if (selectedPiece == null)
                {
                    return;
                }

                List<String> moves = null;

                if (selectedPiece.Name.Contains("pawn"))
                {
                    moves = pieces.pawnMoves(selectedBox);
                }
                else if (selectedPiece.Name.Contains("rook"))
                {
                    moves = pieces.rookMoves(selectedBox);
                }
                else if (selectedPiece.Name.Contains("knight"))
                {
                    moves = pieces.knightMoves(selectedBox);
                }
                else if (selectedPiece.Name.Contains("bishop"))
                {
                    moves = pieces.bishopMoves(selectedBox);
                }
                else if (selectedPiece.Name.Contains("king"))
                {
                    moves = pieces.kingMoves(selectedBox);
                }
                else if (selectedPiece.Name.Contains("queen"))
                {
                    moves = pieces.queenMoves(selectedBox);
                }



                if (moves.Contains(p.Name))
                {
                    bool isPieceRemoved = false;
                    Image piece = null;

                    // There is check in destination box
                    if (selectedPiece.Name.Contains("king") && isCheck(p.Name))
                    {
                        MessageBox.Show("There is Check");
                        return;
                    }


                    //cature pieces code
                    if ((p.Children.Count != 0) && whiteTurn == true ^ !((Image)p.Children[0]).Name.Contains("black"))
                    {

                        piece = ((Image)p.Children[0]);
                        isPieceRemoved = true;
                        p.Children.RemoveAt(0);
                    }



                    // promotion pieces code
                    if (selectedPiece.Name.Contains("pawn"))
                    {
                        Box b = new Box(p.Name);
                        if (b.getRow() == 7 || b.getRow() == 0)
                        {
                            user_promotion++;
                            moves_to_use_in_promotion_section = moves;
                            piece_to_use_in_promotion_section = piece;
                            isPieceRemoved_to_use_in_promotion_section = isPieceRemoved;
                            piecesForPromotion.Visibility = Visibility.Visible;
                            promotionDone = false;
                            return;

                        }
                    }


                    // castle code for white
                    white_king_castle();


                    // castle code for black
                    black_king_castle();

                    // Make Sure KingMoved
                    if (selectedPiece.Name.Equals("king_white"))
                    {
                        kingMoved_white = true;
                    }
                    else if (selectedPiece.Name.Equals("king_black"))
                    {
                        kingMoved_black = true;
                    }

                    //remove piece
                    selectedPanel.Children.RemoveAt(0);
                    p.Children.Add(selectedPiece);


                    //Trace King Movement
                    trace_kings_movements();


                    //Illusion to Code
                    //Prevent king from check by avoiding to move any piece that blocking check

                    //For White King
                    Image tem_piece = selectedPiece;
                    selectedPiece = king_white;
                    if (!tem_piece.Name.Contains("black") && isCheck(kingBox_white))
                    {
                        p.Children.RemoveAt(0);
                        selectedPanel.Children.Add(tem_piece);
                        selectedPiece = tem_piece;
                        if (isPieceRemoved)
                        {
                            p.Children.Add(piece);
                        }
                        return;
                    }

                    //For Black King
                    selectedPiece = king_black;
                    if (tem_piece.Name.Contains("black") && isCheck(kingBox_black))
                    {
                        p.Children.RemoveAt(0);
                        selectedPanel.Children.Add(tem_piece);
                        selectedPiece = tem_piece;
                        if (isPieceRemoved)
                        {
                            p.Children.Add(piece);
                        }
                        return;
                    }

                    normalColor(selectedPanel);  // background back at normal
                    selectedPiece = null;

                    // Switch Turns 
                    // Is Checkmate
                    // Is Stalemate
                    if (whiteTurn)
                    {
                        whiteTurn = false;

                        selectedPiece = king_black;
                        string[] local_check_road = new string[64];
                        if (isCheck(kingBox_black))
                        {
                            checkRoad.CopyTo(local_check_road);
                            moves = pieces.kingMoves(kingBox_black);
                            getPanelByName(kingBox_black).Children.RemoveAt(0); // remove king temporary 
                            foreach (string m in moves)
                            {

                                if (!isCheck(m))
                                {
                                    getPanelByName(kingBox_black).Children.Add(king_black); // add again if king has escape


                                    // AI Black Turn
                                    if (user_mode == "white")
                                    {
                                        computer_turn();
                                    }
                                    return;
                                }
                            }
                            if (getPanelByName(kingBox_black).Children.Count == 0)
                                getPanelByName(kingBox_black).Children.Add(king_black); // add again if king dont has escape

                            List<String> black_all_moves = pieces.getAllMoves("black", "no");
                            foreach (var item in local_check_road)
                            {
                                if (black_all_moves.Contains(item))
                                {
                                    //AI Black Turn
                                    if (user_mode == "white")
                                    {
                                        computer_turn();
                                    }
                                    return;
                                }
                            }

                            MessageBox.Show("Checkmate! White Wins...");
                            MyGrid.IsEnabled = false;
                        }
                        else
                        {

                            //Stalemate code goes here ...

                            List<string> all_moves = new List<string>();
                            all_moves = pieces.getAllMoves("black", "no"); // Get all black moves except king

                            if (all_moves.Count == 0)
                            {
                                selectedPiece = king_black;
                                moves = pieces.kingMoves(kingBox_black);
                                getPanelByName(kingBox_black).Children.RemoveAt(0); // remove king temporary 

                                foreach (string m in moves)
                                {

                                    if (!isCheck(m))
                                    {
                                        //Its not valid for Stalemate
                                        getPanelByName(kingBox_black).Children.Add(king_black); // add again if king has escape


                                        // AI Black Turn
                                        if (user_mode == "white")
                                        {
                                            computer_turn();
                                        }
                                        return;
                                    }

                                }

                                if (getPanelByName(kingBox_black).Children.Count == 0)
                                    getPanelByName(kingBox_black).Children.Add(king_black); // add again if king dont has escape


                                MessageBox.Show("Stalemate! Draw...");
                                MyGrid.IsEnabled = false;
                            }

                            //Its not valid for Stalemate




                            if (user_mode == "white")
                            {
                                computer_turn();
                            }
                        }

                    }
                    else
                    {
                        whiteTurn = true;
                        selectedPiece = king_white;
                        List<string> local_check_road = null;
                        if (isCheck(kingBox_white))
                        {
                            local_check_road = checkRoad;
                            moves = pieces.kingMoves(kingBox_white);
                            getPanelByName(kingBox_white).Children.RemoveAt(0); // remove king temporary 
                            foreach (string m in moves)
                            {
                                if (!isCheck(m))
                                {
                                    getPanelByName(kingBox_white).Children.Add(king_white); // add again if king has escape

                                    // AI White Turn
                                    if (user_mode == "black")
                                    {
                                        computer_turn();
                                    }
                                    return;
                                }
                            }

                            if (getPanelByName(kingBox_white).Children.Count == 0)
                                getPanelByName(kingBox_white).Children.Add(king_white); // add again if king dont has escape

                            List<String> white_all_moves = pieces.getAllMoves("white", "no");
                            foreach (var item in local_check_road)
                            {
                                if (white_all_moves.Contains(item))
                                {
                                    // AI White Turn
                                    if (user_mode == "black")
                                    {
                                        computer_turn();
                                    }
                                    return;
                                }
                            }

                            MessageBox.Show("Checkmate! Black Wins...");
                            MyGrid.IsEnabled = false;
                        }
                        else
                        {



                            //Stalemate code goes here ...

                            List<string> all_moves = new List<string>();
                            all_moves = pieces.getAllMoves("white", "no"); // Get all black moves except king

                            if (all_moves.Count == 0)
                            {
                                selectedPiece = king_white;
                                moves = pieces.kingMoves(kingBox_white);
                                getPanelByName(kingBox_white).Children.RemoveAt(0); // remove king temporary 

                                foreach (string m in moves)
                                {

                                    if (!isCheck(m))
                                    {
                                        //Its not valid for Stalemate
                                        getPanelByName(kingBox_white).Children.Add(king_white); // add again if king has escape


                                        // AI Black Turn
                                        if (user_mode == "black")
                                        {
                                            computer_turn();
                                        }
                                        return;
                                    }

                                }

                                if (getPanelByName(kingBox_white).Children.Count == 0)
                                    getPanelByName(kingBox_white).Children.Add(king_white); // add again if king dont has escape



                                MessageBox.Show("Stalemate! Draw...");
                                MyGrid.IsEnabled = false;
                            }

                            //Its not valid for Stalemate




                            // AI White Turn
                            if (user_mode == "black")
                            {
                                computer_turn();
                            }
                        }
                    }

                    selectedPiece = null;
                }



            }

        }
        private void piece_Clcik_by_computer(StackPanel stackPanel)
        {
            p = stackPanel;

            if (!promotionDone)
            {
                return;
            }

            if (p.Children.Count != 0 && !(whiteTurn == true ^ !((Image)p.Children[0]).Name.Contains("black")))
            {

                if (pieceSelected == true)
                {
                    normalColor(selectedPanel);
                }
                selectedPanel = p;
                selectedBox = p.Name;

                if (p.Background.ToString() != "#FF808080")
                {
                    selectedPanelColor = p.Background.ToString(); // Avoide Gray Color if in case double clicked
                }
                selectedPiece = (Image)p.Children[0];

                p.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);
                pieceSelected = true;
            }
            else
            {
                if (selectedPiece == null)
                {
                    return;
                }

                List<String> moves = null;

                if (selectedPiece.Name.Contains("pawn"))
                {
                    moves = pieces.pawnMoves(selectedBox);
                }
                else if (selectedPiece.Name.Contains("rook"))
                {
                    moves = pieces.rookMoves(selectedBox);
                }
                else if (selectedPiece.Name.Contains("knight"))
                {
                    moves = pieces.knightMoves(selectedBox);
                }
                else if (selectedPiece.Name.Contains("bishop"))
                {
                    moves = pieces.bishopMoves(selectedBox);
                }
                else if (selectedPiece.Name.Contains("king"))
                {
                    moves = pieces.kingMoves(selectedBox);
                }
                else if (selectedPiece.Name.Contains("queen"))
                {
                    moves = pieces.queenMoves(selectedBox);
                }


                if (moves.Contains(p.Name))
                {
                    bool isPieceRemoved = false;
                    Image piece = null;


                    // There is check in destination box
                    if (selectedPiece.Name.Contains("king") && isCheck(p.Name))
                    {
                        MessageBox.Show("There is Check");
                        return;
                    }


                    //cature pieces code
                    if ((p.Children.Count != 0) && whiteTurn == true ^ !((Image)p.Children[0]).Name.Contains("black"))
                    {

                        piece = ((Image)p.Children[0]);
                        isPieceRemoved = true;
                        p.Children.RemoveAt(0);
                    }

                    // promotion pieces code
                    if (selectedPiece.Name.Contains("pawn"))
                    {
                        Box b = new Box(p.Name);
                        if (b.getRow() == 7 || b.getRow() == 0)
                        {
                            ai_promotion++;
                            bool isBlack = false;

                            string queen = "queen white.png";

                            if (selectedPiece.Name.Contains("black"))
                            {
                                isBlack = true;

                                queen = queen.Replace("white", "black");
                            }


                            selectedPiece.Source = new BitmapImage(new Uri(@"C:\\Users\\Haider Ali\\source\\repos\\Chess\\Chess\\chess pieces\\" + queen));
                            selectedPiece.Name = "queen";


                            if (isBlack)
                            {
                                selectedPiece.Name += ai_promotion + "_black";
                            }
                            else
                            {
                                selectedPiece.Name += ai_promotion + "_white";
                            }

                            promotedPieces.Add(selectedPiece);

                        }
                    }

                    // castle code for white
                    white_king_castle();

                    // castle code for black
                    black_king_castle();

                    // Make Sure KingMoved
                    if (selectedPiece.Name.Equals("king_white"))
                    {
                        kingMoved_white = true;
                    }
                    else if (selectedPiece.Name.Equals("king_black"))
                    {
                        kingMoved_black = true;
                    }

                    selectedPanel.Children.RemoveAt(0); //remove piece
                    p.Children.Add(selectedPiece);


                    //Trace King Movement
                    trace_kings_movements();

                    //Illusion to Code
                    //Prevent king from check by avoiding to move any piece that blocking check

                    Image tem_piece = selectedPiece;
                    selectedPiece = king_white;
                    if (!tem_piece.Name.Contains("black") && isCheck(kingBox_white))
                    {
                        p.Children.RemoveAt(0);
                        selectedPanel.Children.Add(tem_piece);
                        selectedPiece = tem_piece;
                        if (isPieceRemoved)
                        {
                            p.Children.Add(piece);
                        }
                        return;
                    }

                    //For Black King
                    selectedPiece = king_black;
                    if (tem_piece.Name.Contains("black") && isCheck(kingBox_black))
                    {
                        p.Children.RemoveAt(0);
                        selectedPanel.Children.Add(tem_piece);
                        selectedPiece = tem_piece;
                        if (isPieceRemoved)
                        {
                            p.Children.Add(piece);
                        }
                        return;
                    }

                    normalColor(selectedPanel);  // background back at normal
                    selectedPiece = null;

                    // Switch Turns
                    // Is Checkmate ...
                    // Is Stalelmate ...
                    if (whiteTurn)
                    {
                        whiteTurn = false;
                        selectedPiece = king_black;
                        string[] local_check_road = new string[64];
                        if (isCheck(kingBox_black))
                        {
                            checkRoad.CopyTo(local_check_road);
                            moves = pieces.kingMoves(kingBox_black);
                            getPanelByName(kingBox_black).Children.RemoveAt(0); // remove king temporary 
                            foreach (string m in moves)
                            {

                                if (!isCheck(m))
                                {
                                    getPanelByName(kingBox_black).Children.Add(king_black); // add again if king has escape


                                    // AI Black Turn
                                    if (user_mode == "white")
                                    {
                                        computer_turn();
                                    }
                                    return;
                                }
                            }
                            if (getPanelByName(kingBox_black).Children.Count == 0)
                                getPanelByName(kingBox_black).Children.Add(king_black); // add again if king dont has escape

                            List<String> black_all_moves = pieces.getAllMoves("black", "no");
                            foreach (var item in local_check_road)
                            {
                                if (black_all_moves.Contains(item))
                                {
                                    //AI Black Turn
                                    if (user_mode == "white")
                                    {
                                        computer_turn();
                                    }
                                    return;
                                }
                            }

                            MessageBox.Show("Checkmate! White Wins...");
                            MyGrid.IsEnabled = false;
                        }
                        else
                        {
                            //Stalemate code goes here ...

                            List<string> all_moves = new List<string>();
                            all_moves = pieces.getAllMoves("black", "no"); // Get all black moves except king

                            if (all_moves.Count == 0)
                            {
                                selectedPiece = king_black;
                                moves = pieces.kingMoves(kingBox_black);
                                getPanelByName(kingBox_black).Children.RemoveAt(0); // remove king temporary 

                                foreach (string m in moves)
                                {

                                    if (!isCheck(m))
                                    {
                                        //Its not valid for Stalemate
                                        getPanelByName(kingBox_black).Children.Add(king_black); // add again if king has escape


                                        // AI Black Turn
                                        if (user_mode == "white")
                                        {
                                            computer_turn();
                                        }
                                        return;
                                    }

                                }

                                if (getPanelByName(kingBox_black).Children.Count == 0)
                                    getPanelByName(kingBox_black).Children.Add(king_black); // add again if king dont has escape


                                MessageBox.Show("Stalemate! Draw...");
                                MyGrid.IsEnabled = false;
                            }

                            //Its not valid for Stalemate



                            if (user_mode == "white")
                            {
                                computer_turn();
                            }
                        }

                    }
                    else
                    {
                        whiteTurn = true;
                        selectedPiece = king_white;
                        List<string> local_check_road = null;
                        if (isCheck(kingBox_white))
                        {
                            local_check_road = checkRoad;
                            moves = pieces.kingMoves(kingBox_white);
                            getPanelByName(kingBox_white).Children.RemoveAt(0); // remove king temporary 
                            foreach (string m in moves)
                            {
                                if (!isCheck(m))
                                {
                                    getPanelByName(kingBox_white).Children.Add(king_white); // add again if king has escape

                                    // AI White Turn
                                    if (user_mode == "black")
                                    {
                                        computer_turn();
                                    }
                                    return;
                                }
                            }

                            if (getPanelByName(kingBox_white).Children.Count == 0)
                                getPanelByName(kingBox_white).Children.Add(king_white); // add again if king dont has escape

                            List<String> white_all_moves = pieces.getAllMoves("white", "no");
                            foreach (var item in local_check_road)
                            {
                                if (white_all_moves.Contains(item))
                                {
                                    // AI White Turn
                                    if (user_mode == "black")
                                    {
                                        computer_turn();
                                    }
                                    return;
                                }
                            }

                            MessageBox.Show("Checkmate! Black Wins...");
                            MyGrid.IsEnabled = false;
                        }
                        else
                        {



                            //Stalemate code goes here ...

                            List<string> all_moves = new List<string>();
                            all_moves = pieces.getAllMoves("white", "no"); // Get all black moves except king

                            if (all_moves.Count == 0)
                            {
                                selectedPiece = king_white;
                                moves = pieces.kingMoves(kingBox_white);
                                getPanelByName(kingBox_white).Children.RemoveAt(0); // remove king temporary 

                                foreach (string m in moves)
                                {

                                    if (!isCheck(m))
                                    {
                                        //Its not valid for Stalemate
                                        getPanelByName(kingBox_white).Children.Add(king_white); // add again if king has escape


                                        // AI Black Turn
                                        if (user_mode == "black")
                                        {
                                            computer_turn();
                                        }
                                        return;
                                    }

                                }

                                if (getPanelByName(kingBox_white).Children.Count == 0)
                                    getPanelByName(kingBox_white).Children.Add(king_white); // add again if king dont has escape



                                MessageBox.Show("Stalemate! Draw...");
                                MyGrid.IsEnabled = false;
                            }

                            //Its not valid for Stalemate




                            // AI White Turn
                            if (user_mode == "black")
                            {
                                computer_turn();
                            }
                        }
                    }
                    selectedPiece = null;
                }



            }


        }
        private void white_king_castle()
        {
            if (rook1Moved == false && selectedPiece.Name == "rook1")
            {
                rook1Moved = true;
            }

            if (rook2Moved == false && selectedPiece.Name == "rook2")
            {
                rook2Moved = true;
            }

            if (kingMoved_white == false && selectedPiece.Name == "king_white")
            {

                if (p.Name == "c1" && !rook1Moved) // castle with rook1 (left)
                {
                    if (!isCheck("e1") && !isCheck("d1") && !isCheck("c1"))
                    {
                        //rook1 to d1
                        getPanelByName("a1").Children.RemoveAt(0);
                        getPanelByName("d1").Children.Add(rook1_white);
                        kingMoved_white = true;
                    }
                    else
                    {
                        return;
                    }


                }
                else if (p.Name == "g1" && !rook2Moved) // castle with rook2 (right)
                {
                    if (!isCheck("e1") && !isCheck("f1") && !isCheck("g1"))
                    {
                        //rook2 to f1
                        getPanelByName("h1").Children.RemoveAt(0);
                        getPanelByName("f1").Children.Add(rook2_white);
                        kingMoved_white = true;
                    }
                    else
                    {
                        return;
                    }

                }
            }
        }
        private void black_king_castle()
        {
            if (rook1Moved_black == false && selectedPiece.Name == "rook1_black")
            {
                rook1Moved_black = true;
            }

            if (rook2Moved_black == false && selectedPiece.Name == "rook2_black")
            {
                rook2Moved_black = true;
            }

            if (kingMoved_black == false && selectedPiece.Name == "king_black")
            {

                if (p.Name == "c8" && !rook1Moved_black) // castle with rook1_black (left)
                {


                    if (!isCheck("e8") && !isCheck("d8") && !isCheck("c8"))
                    {
                        //rook1_black to d8
                        getPanelByName("a8").Children.RemoveAt(0);
                        getPanelByName("d8").Children.Add(rook1_black);
                        kingMoved_black = true;
                    }
                    else
                    {
                        return;
                    }
                }
                else if (p.Name == "g8" && !rook2Moved_black) // castle with rook2_black (right)
                {
                    if (!isCheck("e8") && !isCheck("f8") && !isCheck("g8"))
                    {
                        //rook2_black to f8
                        getPanelByName("h8").Children.RemoveAt(0);
                        getPanelByName("f8").Children.Add(rook2_black);
                        kingMoved_black = true;
                    }
                    else
                    {
                        return;
                    }

                }
            }
        }
        private void trace_kings_movements()
        {
            if (selectedPiece.Name.Equals("king_white"))
            {
                kingBox_white = p.Name;
            }

            if (selectedPiece.Name.Equals("king_black"))
            {
                kingBox_black = p.Name;

            }
        }
        private bool isCheck(string box)
        {
            Box b = new Box(box);
            StackPanel panel = null;



            string curr_box1 = b.topLeft();
            b.reset();
            for (int i = 0; i < 2; i++)
            {

                panel = getPanelByName(curr_box1);

                if (panel != null && panel.Children.Count == 1 && !selectedPiece.Name.Contains("black") && ((Image)panel.Children[0]).Name.Contains("black")) // panel can't be null
                {
                    if (((Image)panel.Children[0]).Name.Contains("pawn"))
                    {
                        checkRoad.Add(curr_box1);
                        return true;
                    }
                }
                b.reset();
                curr_box1 = b.topRight();
            }

            curr_box1 = b.bottomLeft();
            b.reset();
            for (int i = 0; i < 2; i++)
            {
                panel = getPanelByName(curr_box1);

                if (panel != null && panel.Children.Count == 1 && selectedPiece.Name.Contains("black") && !((Image)panel.Children[0]).Name.Contains("black")) // panel can't be null
                {
                    if (((Image)panel.Children[0]).Name.Contains("pawn"))
                    {
                        checkRoad.Add(curr_box1);
                        return true;
                    }
                }
                b.reset();
                curr_box1 = b.bottomRight();
            }



            for (int i = 1; i <= 7; i++)
            {

                panel = getPanelByName(b.top(i));
                checkRoad.Add(b.top(i));
                if (panel != null && panel.Children.Count == 0)
                {

                    continue;
                }

                else if (panel != null && panel.Children.Count != 0 && !selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("rook") || name.Contains("queen"))
                    {
                        return true;
                    }
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && selectedPiece.Name.Contains("black") &&
                    !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("rook") || name.Contains("queen"))
                    {
                        return true;
                    }
                    break;
                }
                else
                {
                    break;
                }
            }
            checkRoad.Clear();

            for (int i = 1; i <= 7; i++)
            {
                checkRoad.Add(b.bottom(i));
                panel = getPanelByName(b.bottom(i));

                if (panel != null && panel.Children.Count == 0)
                {
                    continue;
                }
                else if (panel != null && panel.Children.Count != 0 && !selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("rook") || name.Contains("queen"))
                    {
                        return true;
                    }
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("rook") || name.Contains("queen"))
                    {
                        return true;
                    }
                    break;
                }
                else
                {
                    break;
                }
            }
            checkRoad.Clear();

            for (int i = 1; i <= 7; i++)
            {
                checkRoad.Add(b.left(i));
                panel = getPanelByName(b.left(i));

                if (panel != null && panel.Children.Count == 0)
                {
                    continue;
                }
                else if (panel != null && panel.Children.Count != 0 && !selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("rook") || name.Contains("queen"))
                    {
                        return true;
                    }
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("rook") || name.Contains("queen"))
                    {
                        return true;
                    }
                    break;
                }
                else
                {
                    break;
                }
            }

            checkRoad.Clear();

            for (int i = 1; i <= 7; i++)
            {
                checkRoad.Add(b.right(i));
                panel = getPanelByName(b.right(i));

                if (panel != null && panel.Children.Count == 0)
                {
                    continue;
                }
                else if (panel != null && panel.Children.Count != 0 && !selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("rook") || name.Contains("queen"))
                    {
                        return true;
                    }
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("rook") || name.Contains("queen"))
                    {
                        return true;
                    }
                    break;
                }
                else
                {
                    break;
                }

            }

            checkRoad.Clear();


            for (int i = 1; i <= 7; i++)
            {
                string curr_box = b.topLeft();
                checkRoad.Add(curr_box);
                panel = getPanelByName(curr_box);

                if (panel != null && panel.Children.Count == 0)
                {
                    b.reset(panel.Name);
                    continue;
                }
                else if (panel != null && panel.Children.Count != 0 && !selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("bishop") || name.Contains("queen"))
                    {
                        return true;
                    }
                    b.reset(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("bishop") || name.Contains("queen"))
                    {
                        return true;
                    }
                    b.reset(panel.Name);
                    break;
                }
                else
                {

                    break;
                }


            }
            b.reset();
            checkRoad.Clear();

            for (int i = 1; i <= 7; i++)
            {
                string curr_box = b.topRight();
                checkRoad.Add(curr_box);
                panel = getPanelByName(curr_box);

                if (panel != null && panel.Children.Count == 0)
                {
                    b.reset(panel.Name);
                    continue;
                }
                else if (panel != null && panel.Children.Count != 0 && !selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("bishop") || name.Contains("queen"))
                    {
                        return true;
                    }
                    b.reset(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("bishop") || name.Contains("queen"))
                    {
                        return true;
                    }
                    b.reset(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }
            b.reset();
            checkRoad.Clear();

            for (int i = 1; i <= 7; i++)
            {
                string curr_box = b.bottomLeft();
                checkRoad.Add(curr_box);
                panel = getPanelByName(curr_box);

                if (panel != null && panel.Children.Count == 0)
                {

                    b.reset(panel.Name);
                    continue;
                }
                else if (panel != null && panel.Children.Count != 0 && !selectedPiece.Name.Contains("black") &&
                    ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("bishop") || name.Contains("queen"))
                    {
                        return true;
                    }
                    b.reset(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("bishop") || name.Contains("queen"))
                    {
                        return true;
                    }
                    b.reset(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }
            b.reset();
            checkRoad.Clear();

            for (int i = 1; i <= 7; i++)
            {
                string curr_box = b.bottomRight();
                checkRoad.Add(curr_box);
                panel = getPanelByName(curr_box);

                if (panel != null && panel.Children.Count == 0)
                {

                    b.reset(panel.Name);
                    continue;
                }
                else if (panel != null && panel.Children.Count != 0 && !selectedPiece.Name.Contains("black") &&
                   ((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("bishop") || name.Contains("queen"))
                    {
                        return true;
                    }
                    b.reset(panel.Name);
                    break;
                }
                else if (panel != null && panel.Children.Count != 0 && selectedPiece.Name.Contains("black") &&
                   !((Image)panel.Children[0]).Name.Contains("black"))
                {
                    string name = ((Image)panel.Children[0]).Name;
                    if (name.Contains("bishop") || name.Contains("queen"))
                    {
                        return true;
                    }
                    b.reset(panel.Name);
                    break;
                }
                else
                {
                    break;
                }
            }
            b.reset();
            checkRoad.Clear();

            panel = null; //reset


            string current_box = b.top(2);
            if (current_box != null)
            {
                b.reset(current_box);
                panel = getPanelByName(b.left());
                if (panel != null && panel.Children.Count != 0 && ((Image)panel.Children[0]).Name.Contains("knight"))
                {
                    if (!selectedPiece.Name.Contains("black") && ((Image)panel.Children[0]).Name.Contains("black")
                        || (selectedPiece.Name.Contains("black") && !((Image)panel.Children[0]).Name.Contains("black")))
                    {
                        checkRoad.Add(b.left());
                        return true;
                    }

                }

                panel = getPanelByName(b.right());
                if (panel != null && panel.Children.Count != 0 && ((Image)panel.Children[0]).Name.Contains("knight"))
                {
                    if (!selectedPiece.Name.Contains("black") && ((Image)panel.Children[0]).Name.Contains("black")
                        || (selectedPiece.Name.Contains("black") && !((Image)panel.Children[0]).Name.Contains("black")))
                    {
                        checkRoad.Add(b.right());
                        return true;
                    }

                }

            }
            b.reset();
            checkRoad.Clear(); // It can work without this.

            current_box = b.bottom(2);
            if (current_box != null)
            {
                b.reset(current_box);
                panel = getPanelByName(b.left());
                if (panel != null && panel.Children.Count != 0 && ((Image)panel.Children[0]).Name.Contains("knight"))
                {
                    if (!selectedPiece.Name.Contains("black") && ((Image)panel.Children[0]).Name.Contains("black")
                        || (selectedPiece.Name.Contains("black") && !((Image)panel.Children[0]).Name.Contains("black")))
                    {
                        checkRoad.Add(b.left());
                        return true;
                    }

                }

                panel = getPanelByName(b.right());
                if (panel != null && panel.Children.Count != 0 && ((Image)panel.Children[0]).Name.Contains("knight"))
                {
                    if (!selectedPiece.Name.Contains("black") && ((Image)panel.Children[0]).Name.Contains("black")
                        || (selectedPiece.Name.Contains("black") && !((Image)panel.Children[0]).Name.Contains("black")))
                    {
                        checkRoad.Add(b.right());
                        return true;
                    }

                }

            }
            b.reset();

            checkRoad.Clear();

            current_box = b.left(2);
            if (current_box != null)
            {
                b.reset(current_box);
                panel = getPanelByName(b.top());
                if (panel != null && panel.Children.Count != 0 && ((Image)panel.Children[0]).Name.Contains("knight"))
                {
                    if (!selectedPiece.Name.Contains("black") && ((Image)panel.Children[0]).Name.Contains("black")
                        || (selectedPiece.Name.Contains("black") && !((Image)panel.Children[0]).Name.Contains("black")))
                    {
                        checkRoad.Add(b.top());
                        return true;
                    }

                }

                panel = getPanelByName(b.bottom());
                if (panel != null && panel.Children.Count != 0 && ((Image)panel.Children[0]).Name.Contains("knight"))
                {
                    if (!selectedPiece.Name.Contains("black") && ((Image)panel.Children[0]).Name.Contains("black")
                        || (selectedPiece.Name.Contains("black") && !((Image)panel.Children[0]).Name.Contains("black")))
                    {
                        checkRoad.Add(b.bottom());
                        return true;
                    }

                }

            }
            b.reset();
            checkRoad.Clear();

            current_box = b.right(2);
            if (current_box != null)
            {
                b.reset(current_box);
                panel = getPanelByName(b.top());
                if (panel != null && panel.Children.Count != 0 && ((Image)panel.Children[0]).Name.Contains("knight"))
                {
                    if (!selectedPiece.Name.Contains("black") && ((Image)panel.Children[0]).Name.Contains("black")
                        || (selectedPiece.Name.Contains("black") && !((Image)panel.Children[0]).Name.Contains("black")))
                    {
                        checkRoad.Add(b.right());
                        return true;
                    }

                }

                panel = getPanelByName(b.bottom());
                if (panel != null && panel.Children.Count != 0 && ((Image)panel.Children[0]).Name.Contains("knight"))
                {
                    if (!selectedPiece.Name.Contains("black") && ((Image)panel.Children[0]).Name.Contains("black")
                        || (selectedPiece.Name.Contains("black") && !((Image)panel.Children[0]).Name.Contains("black")))
                    {
                        checkRoad.Add(b.right());
                        return true;
                    }

                }

            }
            b.reset();




            return false;
        }
        private void normalColor(StackPanel p)
        {
            if (selectedPanelColor == "#FFFFFFFF")
            {
                p.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
            }
            else
            {
                p.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Pink);
            }
        }
        private void computer_turn()
        {
            // If Human playing with Human then return
            if (mode == Mode.with_Human)
            {
                return;
            }

            /* Random Selection
             while (true)
            {
                StackPanel black_piece_panel = pieces.getRandomPiecePanel("black");
                piece_Clcik_manually(black_piece_panel);
                MainWindow.selectedPiece = ((Image)black_piece_panel.Children[0]);

                StackPanel black_piece_move_panel = pieces.getRandomMovePanel(black_piece_panel.Name, ((Image)black_piece_panel.Children[0]).Name);
                piece_Clcik_manually(black_piece_move_panel);

                if (isBlackMoved)
                {
                    break;
                }
            }*/

            // Selection using Min_Max Algorithm

            AI ai = new AI(this);
            Node move = ai.get_computer_turn_node();
            ai_moves_counter++;
            Console.WriteLine(" " + ai_moves_counter + " - " + move.piece.Name.Split('_')[0] + ": " + move.h_add.Name + " => " + move.d_add.Name);
            piece_Clcik_by_computer(move.h_add);
            piece_Clcik_by_computer(move.d_add);

        }
        private StackPanel getPanelByName(string name)
        {
            if (name == null)
            {
                return null;
            }

            StackPanel panel = null;
            foreach (StackPanel p in MyGrid.Children)
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
