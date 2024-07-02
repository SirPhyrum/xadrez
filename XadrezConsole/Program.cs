using System;
using Tabuleiro;
using Xadrez;
using XadrezConsole.Xadrez;


namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch partida = new ChessMatch();

                Screen.PrintBoard(partida.Board);
            }
            catch (BoardException e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
 