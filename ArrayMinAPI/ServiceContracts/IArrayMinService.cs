using ArrayMinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArrayMinAPI.ServiceContracts
{
    public interface IArrayMinService
    {
        int FindSecondMin(int[] arrayInput);
        List<RequestLogDto> GetRequestLog();
    }
}