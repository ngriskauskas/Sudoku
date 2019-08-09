using System.Collections.Generic;
using System;

namespace Algos.Suduko
{
  public class Section
  {
    public HashSet<int> Cur { get; }
    public Square[] Children { get; }
    public Section()
    {
      Cur = new HashSet<int>();
      Children = new Square[9];
    }

    public void UpdateCur()
    {
      foreach (Square s in Children)
        if (s.Val != 0)
          Cur.Add(s.Val);
    }

    public bool UpdateChildren()
    {
      foreach (Square s in Children)
      {
        if (s.UpdatePos())
          return true;
      }
      return false;
    }

    public void SinglePosValueSearch()
    {
      while (UpdateChildren()) { }

      var posInSquares = new Dictionary<int, Square>();
      foreach (Square s in Children)
        foreach (int num in s.Pos)
        {
          if (!posInSquares.ContainsKey(num))
            posInSquares.Add(num, s);
          else
            posInSquares[num] = null;
        }

      foreach (int num in posInSquares.Keys)
      {
        if (posInSquares[num] != null)
        {
          posInSquares[num].Val = num;
          posInSquares[num].UpdatePos();
        }
      }


    }
  }
}