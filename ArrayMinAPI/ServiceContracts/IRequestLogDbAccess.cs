using ArrayMinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArrayMinAPI.ServiceContracts
{
    public interface IRequestLogDbAccess
    {
        void Add(decimal ouput, decimal[] input);
        List<RequestLogDto> GetRequestLog();
    }
}