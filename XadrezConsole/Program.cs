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

                while (!partida.Finish)
                {
                    Console.Clear();
                    Screen.PrintBoard(partida.Board);

                    Console.Write("Digite a coordenada da peça que pretende mover ");
                    ChessPosition a = Screen.ReadPosition(); 
                    Console.Write("Digite a coordenada de destino da peça ");
                    ChessPosition b = Screen.ReadPosition();

                    partida.Moving(a.ToPosition(), b.ToPosition());
                }
            }
            catch (BoardException e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
 