﻿using System;
using System.Collections.Generic;
using System.Text;
using Algos.Suduko;

namespace Algos
{
  class Program
  {
    static void Main()
    {
      Board board = new Board(
        new[,] {
          { 7,0,0,0,9,0,0,0,0 },
          { 0,0,3,2,0,0,5,4,0 },
          { 0,8,0,0,0,0,0,0,0 },
          { 0,0,0,0,0,0,0,8,0 },
          { 0,3,0,0,0,9,0,0,2 },
          { 0,4,5,0,2,0,0,1,6 },
          { 0,0,0,0,0,0,0,0,3 },
          { 0,0,0,0,7,4,0,0,0 },
          { 0,6,0,0,8,5,9,0,0 } }
      );

      board.SinglePosValSearch();

    }
  }
}


