#region

using System;
using C21_Ex02_01.Team.Engine.Database;
using C21_Ex02_01.Team.Engine.Database.Board;
using C21_Ex02_01.Team.Engine.Database.Players;
using C21_Ex02_01.Team.Engine.Database.Players.Player;
using C21_Ex02_01.Team.Engine.Database.Players.Player.Human;
using C21_Ex02_01.Team.Engine.Database.Players.Player.Type;
using C21_Ex02_01.Team.Engine.Database.Players.Settings;
using Ex02.ConsoleUtils;
using static C21_Ex02_01.Team.UI.InputUtil.InputUtil;

#endregion

namespace C21_Ex02_01.Team.UI
{
    public static class ConsoleUI
    {
        public class Requester
        {
            public void RequestAndConstructEngine()
            {
                requestAndConstructEngineDatabase();
            }

            private void requestAndConstructEngineDatabase()
            {
                requestDatabase(out byte rows, out byte cols,
                    out eType opponent);
                constructEngineDatabase(rows, cols, opponent);
            }

            private static void requestDatabase(out byte io_Rows,
                out byte io_Cols,
                out eType i_Type)
            {
                requestBoard(out io_Rows, out io_Cols);
                requestOpponentPlayer(out i_Type);
            }

            private void constructEngineDatabase(byte i_Rows,
                byte i_Cols, eType i_Type)
            {
                // Initialize Database: when its members are readonly:
                Board board = new Board(i_Rows, i_Cols);
                Players players =
                    new Players(
                        new Settings(i_Type));

                Engine.Engine.Database = new Database(board, players);
            }

            private static void requestBoard(out byte o_Rows, out byte o_Cols)
            {
                const byte k_MinimumRange = 4;
                const byte k_MaximumRange = 8;

                Console.Out.WriteLine("Please enter a matrix size.");

                string range = $"(range: {k_MinimumRange} to {k_MaximumRange})";
                o_Rows = Convert($"Number of Rows: {range}", k_MinimumRange,
                    k_MaximumRange);
                o_Cols = Convert(
                    $"Number of Columns: {range}", k_MinimumRange,
                    k_MaximumRange);
            }

            private static void requestOpponentPlayer(out eType
                i_Type)
            {
                const byte k_MinimumRange = (byte) eType.Human + 1;
                const byte k_MaximumRange = (byte) eType.Computer + 1;
                string mainMessage =
                    requestOpponentPlayerMainMessage(k_MinimumRange,
                        k_MaximumRange);

                string stringOpponent =
                    requestOpponentPlayerToString(
                        mainMessage,
                        k_MinimumRange, k_MaximumRange);
                Enum.TryParse(stringOpponent, out i_Type);
            }

            private static string requestOpponentPlayerMainMessage(
                byte i_MinimumRange, byte i_MaximumRange)
            {
                string titleMessage =
                    "Please choose an opponent." + Environment.NewLine;
                string humanMessage = $"{i_MinimumRange}. {eType.Human}" +
                                      Environment.NewLine;
                string computerMessage =
                    $"{i_MaximumRange}. {eType.Computer}";
                string mainMessage =
                    titleMessage + humanMessage + computerMessage;
                return mainMessage;
            }

            private static string requestOpponentPlayerToString(
                string i_MainMessage,
                byte i_MinimumRange,
                byte i_MaximumRange)
            {
                byte byteOpponent =
                    Convert(i_MainMessage, i_MinimumRange, i_MaximumRange);
                byteOpponent -= i_MinimumRange;
                string stringOpponent = $"{(eType) byteOpponent:G}";
                return stringOpponent;
            }

            public void RequestChosenColumnHumanPlayer(
                HumanPlayer io_HumanPlayer)
            {
                const byte k_MinimumRange = 1;
                Database database = Engine.Engine.Database;
                byte maxColumnsRange = database.Board.Cols;
                string message =
                    requestChosenColumnHumanPlayerMessage(io_HumanPlayer,
                        k_MinimumRange, database);

                byte chosenColumn =
                    Convert(message, k_MinimumRange, maxColumnsRange);
                chosenColumn -= k_MinimumRange;
                io_HumanPlayer.ChosenColumnIndex = chosenColumn;
            }

            private static string requestChosenColumnHumanPlayerMessage(
                HumanPlayer i_HumanPlayer, byte i_MinimumRange,
                Database i_Database)
            {
                if (i_HumanPlayer == null)
                {
                    throw new ArgumentNullException(nameof(i_HumanPlayer));
                }

                if (i_Database == null)
                {
                    throw new ArgumentNullException(nameof(i_Database));
                }

                string range =
                    $"a number between {i_MinimumRange} to {i_Database.Board.Cols},";
                string title =
                    $"Player {i_HumanPlayer.ID}, it's your turn.{Environment.NewLine}";
                string message = title +
                                 $"Press {range} to insert a coin to that column.";
                return message;
            }
        }

        public class Responder
        {
            private void printBoard()
            {
                Console.Out.WriteLine(Engine.Engine.Database.Board);
            }

            public void PrintBoardWithScreenClearBeforePrint()
            {
                Screen.Clear();
                printBoard();
            }

            public void PrintWinner(Player i_WinnerPlayer)
            {
                Console.Out.WriteLine(
                    $"Congrats, the winner is: Player {i_WinnerPlayer.ID}!");
                Console.Out.WriteLine("Good Game!");
            }

            public void PrintScores(Players i_Players)
            {
                Player playerOne = i_Players.GetPlayerOne();
                Player playerTwo = i_Players.GetPlayerTwo();
                string playerOneScoreString =
                    $"Player {playerOne.ID} : {playerOne.Score}";
                string playerTwoScoreString =
                    $"Player {playerTwo.ID} : {playerTwo.Score}";
                Console.Out.WriteLine(
                    $"Scores are: [{playerOneScoreString} - {playerTwoScoreString}]");
            }

            public void PrintMessage(string i_Message)
            {
                Console.Out.WriteLine(i_Message);
            }

            public void PrintTie()
            {
                Console.Out.WriteLine("It is a tie!");
                Console.Out.WriteLine("Good Game!");
            }
        }
    }
}
