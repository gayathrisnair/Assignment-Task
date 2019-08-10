using ArrayMinAPI.Context;
using ArrayMinAPI.Models;
using ArrayMinAPI.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArrayMinAPI.DbAccess
{
    public class RequestLogDbAccess : IRequestLogDbAccess
    {
        public DBContext _dbContext = new DBContext();
        public void Add(int ouput,int[] input)
        {
            var requestlLog = new RequestLog()
            {

                Input = string.Join(",", input),
                Output = ouput
            };
            _dbContext.RequestLogs.Add(requestlLog);
            _dbContext.SaveChanges();
        }
        public List<RequestLogDto> GetRequestLog() =>
            _dbContext.RequestLogs.Select(x => new RequestLogDto
            {
                Input = x.Input,
                Output = x.Output

            }).ToList();
    }
}