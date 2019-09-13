using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class Payload
  {
    public string Description { get; set; }

    public List<Feature> FeatureData { get; set; }
  }
}
