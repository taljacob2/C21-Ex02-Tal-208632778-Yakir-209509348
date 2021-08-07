#region

using System;
using C21_Ex02_01.Team.Engine.Database;
using C21_Ex02_01.Team.Engine.Database.Board;
using C21_Ex02_01.Team.Engine.Database.Player.Type;
using C21_Ex02_01.Team.Engine.Database.Player.Wrapper;
using C21_Ex02_01.Team.Engine.Database.Player.Wrapper.Settings;
using static C21_Ex02_01.Team.UI.InputUtil.InputUtil;

#endregion

namespace C21_Ex02_01.Team.UI
{
    public static class MenuUI
    {
        public static void RequestAndConstructDatabase()
        {
            MenuUIRequester.RequestDatabase(out byte rows, out byte cols,
                out ePlayerType opponent);
            MenuUIRequester.ConstructDatabase(rows, cols, opponent);
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

        private static void requestOpponentPlayer(out ePlayerType i_PlayerType)
        {
            const byte k_MinimumRange = 1;
            const byte k_MaximumRange = 2;
            string mainMessage =
                MenuUIRequester.RequestOpponentPlayerMainMessage(
                    k_MinimumRange,
                    k_MaximumRange);

            string stringOpponent =
                MenuUIRequester.RequestOpponentPlayerToString(
                    mainMessage,
                    k_MinimumRange, k_MaximumRange);
            Enum.TryParse(stringOpponent, out i_PlayerType);
        }

        private static class MenuUIRequester
        {
            internal static void RequestDatabase(out byte io_Rows,
                out byte io_Cols,
                out ePlayerType i_PlayerType)
            {
                requestBoard(out io_Rows, out io_Cols);
                requestOpponentPlayer(out i_PlayerType);
            }

            internal static void ConstructDatabase(byte i_Rows, byte i_Cols,
                ePlayerType i_PlayerType)
            {
                // Initialize Database: when its members are readonly:
                Board board = new Board(i_Rows, i_Cols);
                PlayersWrapper playersWrapper =
                    new PlayersWrapper(
                        new PlayersWrapperSettings(i_PlayerType));

                Engine.Engine.Database = new Database(board, playersWrapper);
            }

            internal static string RequestOpponentPlayerToString(
                string i_MainMessage,
                byte i_MinimumRange,
                byte i_MaximumRange)
            {
                byte byteOpponent =
                    Convert(i_MainMessage, i_MinimumRange, i_MaximumRange);
                byteOpponent -= i_MinimumRange;
                string stringOpponent = $"{(ePlayerType) byteOpponent:G}";
                return stringOpponent;
            }

            internal static string RequestOpponentPlayerMainMessage(
                byte i_MinimumRange, byte i_MaximumRange)
            {
                string titleMessage =
                    "Please choose an opponent." + Environment.NewLine;
                string humanMessage = $"{i_MinimumRange}. {ePlayerType.Human}" +
                                      Environment.NewLine;
                string computerMessage =
                    $"{i_MaximumRange}. {ePlayerType.Computer}";
                string mainMessage =
                    titleMessage + humanMessage + computerMessage;
                return mainMessage;
            }
        }
    }
}
