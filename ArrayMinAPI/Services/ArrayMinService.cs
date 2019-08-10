using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArrayMinAPI.Models;
using ArrayMinAPI.ServiceContracts;
using Castle.Core.Internal;

namespace ArrayMinAPI.Services
{
    public class ArrayMinService : IArrayMinService
    {
        public IRequestLogDbAccess _requestLogDbAccess;
        public ArrayMinService(IRequestLogDbAccess requestLogDbAccess)
        {
            _requestLogDbAccess = requestLogDbAccess;

        }

        public decimal FindSecondMin(decimal[] arrayInput)
        {
            Validate(arrayInput);
            decimal min = decimal.MaxValue, secondMin = decimal.MaxValue;
            foreach(var item in arrayInput)
            {
                if(item <= min)
                {
                    secondMin = min;
                    min = item;
                }
                else if (item <= secondMin)
                {
                    secondMin = item;
                }
            }
            _requestLogDbAccess.Add(secondMin, arrayInput);
            return secondMin;
        
        }
        public List<RequestLogDto> GetRequestLog() =>
            _requestLogDbAccess.GetRequestLog();

        public void Validate(decimal[] arrayInput)
        {
            if (arrayInput == null || arrayInput.IsNullOrEmpty())
            {
                ThrowException("Input is invalid");
            }
            else if (arrayInput.Count() == 1)
            {
                ThrowException("Input only contains one element");
            }
        }
        private void ThrowException(string message)
        {
            var exception = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(string.Format(message)),
            };
            throw new HttpResponseException(exception);
        }
    }
}