using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class Point
  {
    public double[] coordinates { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();

      sb.Append("[");

      if (coordinates != null)
      {
        for(int i = 0; i < coordinates.Length; i++)
        {
          if (i == coordinates.Length - 1)
          {
            sb.Append(coordinates[i]);
          }
          else
          {
            sb.Append($"{coordinates[i]}, ");
          }
        }
      }

      sb.Append("]");

      string response = sb.ToString();
      return response;
    }
  }
}
