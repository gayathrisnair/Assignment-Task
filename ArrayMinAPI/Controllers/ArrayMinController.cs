using ArrayMinAPI.Filters;
using ArrayMinAPI.Models;
using ArrayMinAPI.ServiceContracts;
using ArrayMinAPI.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace ArrayMinAPI.Controllers
{
    [ValidateModel]
    public class ArrayMinController : ApiController
    {

        public IArrayMinService _arrayMinService;
        
        public ArrayMinController(IArrayMinService arrayMinService)
        {
            _arrayMinService = arrayMinService;

        }

        [Route("get-request-log")]
        [HttpGet]
        public List<RequestLogDto> GetRequestLog()
        {
            return _arrayMinService.GetRequestLog();
        }

        [Route("find-min-number")]
        [HttpPost]
        public int FindSecondMinNumber([FromBody]int[] input)
        {
            return _arrayMinService.FindSecondMin(input); 
        }
    }
}
