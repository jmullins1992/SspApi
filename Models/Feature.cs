using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class Feature
  {
    public string id { get; set; }
    public Point geometry { get; set; }

    public Dictionary<string,string> properties { get; set; }
  }
}
