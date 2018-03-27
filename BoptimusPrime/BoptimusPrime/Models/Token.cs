using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoptimusPrime.Models
{
    public class Token
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }
    }
}