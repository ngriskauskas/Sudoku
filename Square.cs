using System.Collections.Generic;
using System.Linq;

namespace Algos.Suduko
{
  public class Square
  {
    private Board board;
    private int val = 0;
    public int Val
    {
      get => val;

      set
      {
        val = value;
        PropigateUpdate();
        board.WriteBoard(this);
      }
    }
    private Section row, col, box;
    public HashSet<int> Pos = new HashSet<int>();
    public Square(
      Section row,
      Section col,
      Section box,
      int val,
      Board board)
    {
      this.row = row;
      this.col = col;
      this.box = box;
      this.val = val;
      this.board = board;
    }


    public bool UpdatePos()
    {

      Pos.Clear();

      if (Val != 0)
        return false;

      for (int i = 1; i <= 9; i++)
      {
        if (!row.Cur.Contains(i)
        && !col.Cur.Contains(i)
        && !box.Cur.Contains(i))
        {
          Pos.Add(i);
        }
      }

      if (Pos.Count == 1)
      {
        Val = Pos.Single();
        Pos.Clear();
        return true;
      }

      return false;

    }

    private void PropigateUpdate()
    {
      row.UpdateCur();
      col.UpdateCur();
      box.UpdateCur();
    }
  }
}