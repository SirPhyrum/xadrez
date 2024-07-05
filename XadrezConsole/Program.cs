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
            ChessMatch partida = new ChessMatch();

            while (!partida.Finish && !partida.Draw)
            {
                try
                {
                    Screen.PrintMatch(partida);
                    Console.WriteLine();

                    Console.Write("Digite a coordenada da peça que pretende mover ");
                    Position origin = Screen.ReadPosition().ToPosition();
                    partida.ValidOrigin(origin);
                    bool[,] possiblepositions = partida.Board.Piece(origin).PossibleMoviments();

                    Console.Clear();
                    Screen.PrintBoard(partida, possiblepositions);
                    Console.WriteLine();

                    partida.MakePlay(possiblepositions, origin, partida);
                }
                catch (BoardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                catch (FormatException e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Digite uma coordenada válida!");
                    Console.ReadLine();
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Digite uma coordenada válida!");
                    Console.ReadLine();
                }
            }
            if (partida.Finish)
            {
                Screen.PrintMatch(partida);
                Console.WriteLine($"AS PEÇAS {partida.Player} VENCERAM!!!");
            }
            else
            {
                Screen.PrintMatch(partida);
                Console.WriteLine($"JOGO EMPATADO!!!");
            }
        }
    }
}


