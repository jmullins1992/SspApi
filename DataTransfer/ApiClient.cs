using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
  public class ApiClient<T>
  {
    private string Endpoint { get; set; }
    private JsonSerializer Serializer { get; set; }

    public ApiClient(string endpoint)
    {
      Endpoint = endpoint;
      Serializer = new JsonSerializer();
    }

    public Response<T> Read()
    {
      Response<T> response = new Response<T>();

      try
      {
        WebRequest request = WebRequest.Create(Endpoint);

        WebResponse webResponse = request.GetResponse();

        Stream webResponseStream = webResponse.GetResponseStream();

        using (StreamReader sr = new StreamReader(webResponseStream))
        {
          response.Data = (T)Serializer.Deserialize(sr, typeof(T));
        }

        response.Success = true;
      }
      catch(Exception ex)
      {
        response.Exception = ex;
        response.Message = "An error has occurred. Please contact your system administrator.";
      }

      return response;
    }
  }
}
