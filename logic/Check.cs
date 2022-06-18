using Chess.classes;
using System;

namespace Chess.logic
{
    static class Check
    {
        static public bool DetermineTheFigureAndCheckIfItEndangersTheEnemyKing(Figure figure, Grid[,] board, int startX, int startY, out int kingPosX, out int kingPosY)
        {
            kingPosX = -1;
            kingPosY = -1;
            if (figure is Pawn)
            {
                return PawnCheck((Pawn)figure, board, startX, startY, out kingPosX, out kingPosY);
            }
            else if (figure is Rook)
            {
                return RookCheck((Rook)figure, board, startX, startY, out kingPosX, out kingPosY);
            }
            else if (figure is Knight)
            {
                return KnightCheck((Knight)figure, board, startX, startY, out kingPosX, out kingPosY);
            }
            else if (figure is Bishop)
            {
                return BishopCheck((Bishop)figure, board, startX, startY, out kingPosX, out kingPosY);
            }
            else if (figure is Queen)
            {
                return QueenCheck((Queen)figure, board, startX, startY, out kingPosX, out kingPosY);
            }
            else
            {
                // return KingCheck((King)figure, board, startX, startY, out kingPosX, out kingPosY);
                return false;
            }

        }
        static public bool PawnCheck(Pawn pawn, Grid[,] board, int startX, int startY, out int kingPosX, out int kingPosY)
        {
            //x == i y == j

            kingPosX = -1;
            kingPosY = -1;

            if (pawn.IsWhite)
            {
                bool CheckBlackKingRight = false;
                try
                {
                    CheckBlackKingRight = (board[startX - 1, startY + 1].OccupyingFigure is King && board[startX - 1, startY + 1].OccupyingFigure.IsWhite == false);
                }
                catch (Exception)
                { }
                bool CheckBlackKingLeft = false;
                try
                {
                    CheckBlackKingLeft = (board[startX - 1, startY - 1].OccupyingFigure is King && board[startX - 1, startY - 1].OccupyingFigure.IsWhite == false);
                }
                catch (Exception) { }
                if (CheckBlackKingRight)
                {
                    kingPosX = startX - 1;
                    kingPosY = startY + 1;
                    // throw new Exception("Black King Checked");
                    return true;
                }
                else if (CheckBlackKingLeft)
                {
                    kingPosX = startX - 1;
                    kingPosY = startY - 1;
                    // throw new Exception("Black King Checked");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                bool CheckWhiteKingRight = false;
                try
                {
                    CheckWhiteKingRight = (board[startX + 1, startY + 1].OccupyingFigure is King && board[startX + 1, startY + 1].OccupyingFigure.IsWhite == true);
                }
                catch (Exception)
                { }
                bool CheckWhiteKingLeft = false;
                try
                {
                    CheckWhiteKingLeft = (board[startX + 1, startY - 1].OccupyingFigure is King && board[startX + 1, startY - 1].OccupyingFigure.IsWhite == true);

                }
                catch (Exception) { }
                if (CheckWhiteKingRight)
                {
                    kingPosX = startX + 1;
                    kingPosY = startX + 1;
                    // throw new Exception("White King Checked");
                    return true;
                }
                else if (CheckWhiteKingLeft)
                {
                    kingPosX = startX + 1;
                    kingPosY = startX - 1;
                    //throw new Exception("White King Checked");
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        static public bool RookCheck(Figure rook, Grid[,] board, int startX, int startY, out int kingPosX, out int kingPosY)
        {

            //CheckForward
            for (int i = startX; i > -1; i--)
            {
                if (board[i, startY].OccupyingFigure == null)
                {
                    continue;
                }
                else if(!(board[i, startY].OccupyingFigure is King) && board[i,startY].OccupyingFigure != rook)
                {
                    kingPosX = -1;
                    kingPosY = -1;
                    return false;
                }
                bool checkCondition = (board[i, startY].OccupyingFigure.IsWhite == true && board[i, startY].OccupyingFigure is King && rook.IsWhite == false) ||
                    (board[i, startY].OccupyingFigure.IsWhite == false && board[i, startY].OccupyingFigure is King && rook.IsWhite == true);
                if (checkCondition)
                {
                    kingPosX = i;
                    kingPosY = startY;                    
                    return true;
                }

            }
            //CheckBack
            for (int i = startX; i < 8; i++)
            {
                if (board[i, startY].OccupyingFigure == null)
                {
                    continue;
                }
                else if (!(board[i, startY].OccupyingFigure is King) && board[i, startY].OccupyingFigure != rook)
                {
                    kingPosX = -1;
                    kingPosY = -1;
                    return false;
                }
                bool checkCondition = (board[i, startY].OccupyingFigure.IsWhite == true && board[i, startY].OccupyingFigure is King && rook.IsWhite == false) ||
                    (board[i, startY].OccupyingFigure.IsWhite == false && board[i, startY].OccupyingFigure is King && rook.IsWhite == true);
                if (checkCondition)
                {
                    kingPosX = i;
                    kingPosY = startY;                  
                    return true;
                }

            }
            //CheckRight
            for (int i = startY; i > -1; i--)
            {
                if (board[startX, i].OccupyingFigure == null)
                {
                    continue;
                }
                else if (!(board[i, startY].OccupyingFigure is King) && board[i, startY].OccupyingFigure != rook)
                {
                    kingPosX = -1;
                    kingPosY = -1;
                    return false;
                }
                bool checkCondtiton = (board[startX, i].OccupyingFigure.IsWhite == true && board[startX, i].OccupyingFigure is King && rook.IsWhite == false) ||
                    (board[startX, i].OccupyingFigure.IsWhite == false && board[startX, i].OccupyingFigure is King && rook.IsWhite == true);
                if (checkCondtiton)
                {
                    kingPosX = startX;
                    kingPosY = i;                   
                    return true;
                }

            }
            //CheckLeft
            for (int i = startY; i < 8; i++)
            {
                if (board[startX, i].OccupyingFigure == null)
                {
                    continue;
                }
                else if (!(board[i, startY].OccupyingFigure is King) && board[i, startY].OccupyingFigure != rook)
                {
                    kingPosX = -1;
                    kingPosY = -1;
                    return false;
                }
                bool checkCondition = (board[startX, i].OccupyingFigure.IsWhite == true && board[startX, i].OccupyingFigure is King && rook.IsWhite == false) ||
                    (board[startX, i].OccupyingFigure.IsWhite == false && board[startX, i].OccupyingFigure is King && rook.IsWhite == true);
                if (checkCondition)
                {
                    kingPosX = startX;
                    kingPosY = i;                   
                    return true;
                }

            }
            kingPosX = -1;
            kingPosY = -1;
            return false;
        }
        static public bool KnightCheck(Knight knight, Grid[,] board, int startX, int startY, out int kingPosX, out int kingPosY)
        {
            //x==i y==j
            //UpAndLeft
            Figure enemyFigure;
            try
            {
                enemyFigure = board[startX + 2, startY - 1].OccupyingFigure;
            }
            catch (Exception e)
            {

                enemyFigure = null;
            }
            //Figure enemyFigure = board[startX + 2, startY - 1].OccupyingFigure;
            if (enemyFigure != null)
            {
                bool checkCondition = (enemyFigure.IsWhite == true && enemyFigure is King && knight.IsWhite == false) ||
                 (enemyFigure.IsWhite == false && enemyFigure is King && knight.IsWhite == true);
                if (checkCondition)
                {
                    kingPosX = startX + 2;
                    kingPosY = startY - 1;
                    return true;
                }

            }
            //UpAndRight
            try
            {
                enemyFigure = board[startX + 2, startY + 1].OccupyingFigure;
            }
            catch (Exception e)
            {

                enemyFigure = null;
            }
            if (enemyFigure != null)
            {
                bool checkCondition = (enemyFigure.IsWhite == true && enemyFigure is King && knight.IsWhite == false) ||
               (enemyFigure.IsWhite == false && enemyFigure is King && knight.IsWhite == true);
                if (checkCondition)
                {
                    kingPosX = startX + 2;
                    kingPosY = startY + 1;
                    return true;
                }

            }
            //LeftAndUp
            try
            {
                enemyFigure = board[startX - 1, startY - 2].OccupyingFigure;
            }
            catch (Exception e)
            {

                enemyFigure = null;
            }
            if (enemyFigure != null)
            {
                bool checkCondition = (enemyFigure.IsWhite == true && enemyFigure is King && knight.IsWhite == false) ||
                (enemyFigure.IsWhite == false && enemyFigure is King && knight.IsWhite == true);
                if (checkCondition)
                {
                    kingPosX = startX - 1;
                    kingPosY = startY - 2;
                    return true;
                }

            }
            //LeftAndDown
            try
            {
                enemyFigure = board[startX + 1, startY - 2].OccupyingFigure;
            }
            catch (Exception e)
            {

                enemyFigure = null;
            }
            if (enemyFigure != null)
            {
                bool checkCondition = (enemyFigure.IsWhite == true && enemyFigure is King && knight.IsWhite == false) ||
                (enemyFigure.IsWhite == false && enemyFigure is King && knight.IsWhite == true);
                if (checkCondition)
                {
                    kingPosX = startX + 1;
                    kingPosY = startY - 2;
                    return true;
                }

            }
            //RightAndUp
            try
            {
                enemyFigure = board[startX - 1, startY + 2].OccupyingFigure;
            }
            catch (Exception e)
            {

                enemyFigure = null;
            }
            if (enemyFigure != null)
            {
                bool checkCondition = (enemyFigure.IsWhite == true && enemyFigure is King && knight.IsWhite == false) ||
               (enemyFigure.IsWhite == false && enemyFigure is King && knight.IsWhite == true);
                if (checkCondition)
                {
                    kingPosX = startX - 1;
                    kingPosY = startY + 2;
                    return true;
                }

            }
            //RightAndDown
            try
            {
                enemyFigure = board[startX + 1, startY + 2].OccupyingFigure;
            }
            catch (Exception e)
            {

                enemyFigure = null;
            }
            if (enemyFigure != null)
            {
                bool checkCondition = (enemyFigure.IsWhite == true && enemyFigure is King && knight.IsWhite == false) ||
                (enemyFigure.IsWhite == false && enemyFigure is King && knight.IsWhite == true);
                if (checkCondition)
                {
                    kingPosX = startX + 1;
                    kingPosY = startY + 2;
                    return true;
                }

            }
            //UpAndLeft
            try
            {
                enemyFigure = board[startX - 2, startY - 1].OccupyingFigure;
            }
            catch (Exception e)
            {

                enemyFigure = null;
            }
            if (enemyFigure != null)
            {
                bool checkCondition = (enemyFigure.IsWhite == true && enemyFigure is King && knight.IsWhite == false) ||
               (enemyFigure.IsWhite == false && enemyFigure is King && knight.IsWhite == true);
                if (checkCondition)
                {
                    kingPosX = startX - 2;
                    kingPosY = startY - 1;
                    return true;
                }

            }
            //DownANdRight
            try
            {
                enemyFigure = board[startX - 2, startY + 1].OccupyingFigure;
            }
            catch (Exception e)
            {

                enemyFigure = null;
            }
            if (enemyFigure != null)
            {
                bool checkCondition = (enemyFigure.IsWhite == true && enemyFigure is King && knight.IsWhite == false) ||
               (enemyFigure.IsWhite == false && enemyFigure is King && knight.IsWhite == true);
                if (checkCondition)
                {
                    kingPosX = startX - 2;
                    kingPosY = startY + 1;
                    return true;
                }
            }
            kingPosX = -1;
            kingPosY = -1;
            return false;
        }
        static public bool BishopCheck(Figure bishop, Grid[,] board, int startX, int startY, out int kingPosX, out int kingPosY)
        {
            //ForwardLeft
            int i = startX;
            int j = startY;
            Figure enemyFigure = null;
            bool checkCondition = false;
            for (i = startX; i > -1; i--)
            {
                if (i == -1 || j == -1)
                {
                    break;
                }

                try
                {
                    enemyFigure = board[i, j].OccupyingFigure;
                }
                catch (Exception) { }
                if (enemyFigure != null)
                {
                    if (!(enemyFigure is King) && enemyFigure != bishop) break;
                    checkCondition = (enemyFigure.IsWhite == false && enemyFigure is King && bishop.IsWhite == true) ||
                        (enemyFigure.IsWhite == true && enemyFigure is King && bishop.IsWhite == false);
                    if (checkCondition)
                    {
                        kingPosX = i;
                        kingPosY = j;
                        return true;
                    }
                }
                j--;
            }
            //ForwardRight
            i = startX;
            j = startY;
            enemyFigure = null;
            checkCondition = false;
            for (i = startX; i > -1; i--)
            {
                if (i == -1 || j == 8)
                {
                    break;
                }

                try
                {
                    enemyFigure = board[i, j].OccupyingFigure;
                }
                catch (Exception) { }
                if (enemyFigure != null)
                {
                    if (!(enemyFigure is King) && enemyFigure != bishop) break;
                    checkCondition = (enemyFigure.IsWhite == false && enemyFigure is King && bishop.IsWhite == true) ||
                        (enemyFigure.IsWhite == true && enemyFigure is King && bishop.IsWhite == false);
                    if (checkCondition)
                    {
                        kingPosX = i;
                        kingPosY = j;
                        return true;
                    }
                }

                j++;
            }
            //DownwardLeft
            i = startX;
            j = startY;
            enemyFigure = null;
            checkCondition = false;
            for (i = startX; i < 8; i++)
            {
                if (i == 8 || j == -1)
                {
                    break;
                }

                try
                {
                    enemyFigure = board[i, j].OccupyingFigure;
                }
                catch (Exception) { }
                if (enemyFigure != null )
                {
                    if (!(enemyFigure is King) && enemyFigure != bishop) break;
                    checkCondition = (enemyFigure.IsWhite == false && enemyFigure is King && bishop.IsWhite == true) ||
                        (enemyFigure.IsWhite == true && enemyFigure is King && bishop.IsWhite == false);
                    if (checkCondition)
                    {
                        kingPosX = i;
                        kingPosY = j;
                        return true;
                    }
                }

                j--;
            }
            //DownwardRight
            i = startX;
            j = startY;
            enemyFigure = null;
            checkCondition = false;
            for (i = startX; i < 8; i++)
            {
                if (i == 8 || j == 8)
                {
                    break;
                }

                try
                {
                    enemyFigure = board[i, j].OccupyingFigure;
                }
                catch (Exception) { }
                if (enemyFigure != null )
                {
                    if (!(enemyFigure is King) && enemyFigure != bishop) break;
                    checkCondition = (enemyFigure.IsWhite == false && enemyFigure is King && bishop.IsWhite == true) ||
                        (enemyFigure.IsWhite == true && enemyFigure is King && bishop.IsWhite == false);
                    if (checkCondition)
                    {
                        kingPosX = i;
                        kingPosY = j;
                        return true;
                    }
                }


                j++;
            }



            kingPosX = -1;
            kingPosY = -1;
            return false;
        }
        static public bool QueenCheck(Figure queen, Grid[,] board, int startX, int startY, out int kingPosX, out int kingPosY)
        {
            return RookCheck(queen, board, startX, startY, out kingPosX, out kingPosY) || BishopCheck(queen, board, startX, startY, out kingPosX, out kingPosY);
        }
        static public bool KingCheck(King king, Grid[,] board, int startX, int startY, out int kingPosX, out int kingPosY)
        {
            bool checkCondition = false;
            Figure enemyFigure = null;
            for (int i = startX - 1; i < startX + 2; i++)
            {
                for (int j = startY - 1; j < startY + 2; j++)
                {
                    try
                    {
                        enemyFigure = board[i, j].OccupyingFigure;
                    }
                    catch (Exception)
                    { }

                    if (enemyFigure != null)
                    {
                        checkCondition = (king.IsWhite == true && enemyFigure is King && enemyFigure.IsWhite == false) ||
                        (king.IsWhite == false && enemyFigure is King && enemyFigure.IsWhite == true);
                        if (checkCondition)
                        {
                            kingPosX = i;
                            kingPosY = j;
                            return true;
                        }
                    }

                }
            }
            kingPosX = -1;
            kingPosY = -1;
            return false;
        }


    }

}
