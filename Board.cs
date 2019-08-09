using System;
using System.Collections.Generic;

namespace Algos.Suduko
{

  public class Board
  {
    private Square[,] board;
    public Section[] Rows, Cols;
    public Section[,] Boxes;

    public Board(int[,] boardNums)
    {
      InitBoard();
      InitSections();
      InitSquares(boardNums);
      InitSectionsChildren();
      UpdateSections();
      UpdateSquares();
    }



    private void InitBoard()
    {
      board = new Square[9, 9];
      Boxes = new Section[3, 3];
      Rows = new Section[9];
      Cols = new Section[9];
    }

    private void InitSections()
    {
      for (int i = 0; i < board.GetLength(0); i++)
      {
        Rows[i] = new Section();
        Cols[i] = new Section();
      }
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          Boxes[i, j] = new Section();
    }

    private void InitSectionsChildren()
    {
      for (int i = 0; i < board.GetLength(0); i++)
        for (int j = 0; j < board.GetLength(1); j++)
        {
          Rows[i].Children[j] = board[i, j];
          Cols[j].Children[i] = board[i, j];
          int index = (3 * (i % 3)) + (j % 3);
          Boxes[i / 3, j / 3].Children[index] = board[i, j];
        }

    }

    private void UpdateSections()
    {
      foreach (Section s in Boxes)
        s.UpdateCur();

      foreach (Section s in Rows)
        s.UpdateCur();

      foreach (Section s in Cols)
        s.UpdateCur();

    }

    public void UpdateSquares()
    {
      foreach (Square s in board)
        s.UpdatePos();
    }

    public void SinglePosValSearch()
    {
      foreach (Section s in Boxes)
        s.SinglePosValueSearch();


      foreach (Section s in Rows)
        s.SinglePosValueSearch();


      foreach (Section s in Cols)
        s.SinglePosValueSearch();


    }

    private void InitSquares(int[,] boardNums)
    {
      for (int i = 0; i < board.GetLength(0); i++)
        for (int j = 0; j < board.GetLength(1); j++)
          board[i, j] =
          new Square(
            Rows[i],
            Cols[j],
            Boxes[i / 3, j / 3], boardNums[i, j],
            this);
    }

    public void WriteBoard(Square newVal)
    {
      for (int i = 0; i < 9; i++)
      {
        for (int j = 0; j < 9; j++)
        {
          if (board[i, j].Equals(newVal))
            Console.Write(board[i, j].Val + "*");
          else
            Console.Write(board[i, j].Val + " ");
        }
        Console.WriteLine();
      }
      Console.WriteLine();
      Console.WriteLine();
    }



  }


}