using DataTransfer;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SspApiReader
{
  class Program
  {
    static ApiClient<Payload> Client { get; set; }
    static void Main(string[] args)
    {
      Init();

      DisplayData();

      Exit();
    }

    static void Init()
    {
      Console.WriteLine("Welcome to the SSP Api Reader!");

      string endpoint = ConfigurationManager.AppSettings["ENDPOINT_ADDRESS"];
      Client = new ApiClient<Payload>(endpoint);

      Console.Write("Press any key to continue...");
      Console.ReadKey();
    }

    static void DisplayData()
    {
      Response<Payload> response = Client.Read();

      if (response)
      {
        Console.WriteLine(PresentPayload(response.Data));
      }
      else
      {
        Console.WriteLine(response.Message);
      }
    }

    static void Exit()
    {
      Console.Write("Press any key to exit...");
      Console.ReadKey();
    }

    static string PresentPayload(Payload payload)
    {
      StringBuilder sb = new StringBuilder();

      sb.Append($"{payload.Description}\n");

      if (payload.FeatureData != null)
      {
        foreach (Feature feature in payload.FeatureData)
        {
          sb.Append($"{feature.id} - {feature.geometry}\n");

          if (feature.properties != null)
          {
            foreach(KeyValuePair<string,string> property in feature.properties)
            {
              sb.Append($"\t{property.Key} : {property.Value}\n");
            }
          }
        }
      }

      string response = sb.ToString();

      return response;
    }
  }
}
