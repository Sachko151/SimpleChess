using Chess.classes;
using System;

namespace Chess.logic
{
    static class Mate
    {
        public static bool checkIfTheGameIsOver(Grid[,] board, int kingX, int kingY)
        {
            
            Figure enemyFigure = null;
            King king = (King)board[kingX, kingY].OccupyingFigure;
            for (int i = kingX - 1; i < kingX + 2; i++)
            {
                for (int j = kingY - 1; j < kingY + 2; j++)
                {
                    try
                    {
                        enemyFigure = board[i, j].OccupyingFigure;
                    }
                    catch (Exception)
                    { }

                    if (enemyFigure == null)
                    {
                        king.Move(board, kingX, kingY, i, j);
                        if (!CheckEverySingleGridIfItEndangersTheKingsCurrentPosition(king, board))
                        {
                            king.Move(board, i, j, kingX, kingY);
                            return false;
                        }
                        king.Move(board, i, j, kingX, kingY);
                    }
                }

            }
            return true;
        }


        private static bool CheckEverySingleGridIfItEndangersTheKingsCurrentPosition(King king, Grid[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].OccupyingFigure == null)
                    {
                        continue;
                    }
                    Figure fig = board[i, j].OccupyingFigure;
                    if (fig.IsWhite == true && king.IsWhite == true || fig.IsWhite == false && king.IsWhite == false)
                    {
                        continue;
                    }
                    int a = 0;
                    int b = 0;
                    if (Check.DetermineTheFigureAndCheckIfItEndangersTheEnemyKing(fig, board, i, j, out a, out b))
                    {
                        return true;
                    }
                }
            }
            return false;

        }
    }
}
