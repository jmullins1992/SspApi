﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class Response<T>
  {
    public T Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }

    public Exception Exception { get; set; }

    public static implicit operator bool(Response<T> response)
    {
      return response.Success;
    }
  }
}
