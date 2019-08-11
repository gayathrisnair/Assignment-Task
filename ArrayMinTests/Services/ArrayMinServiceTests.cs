using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayMinAPI.DbAccess;
using ArrayMinAPI.Controllers;
using System.Web.Http;
using System.Net;

namespace ArrayMinAPI.Services.Tests
{
    [TestClass()]
    public class ArrayMinServiceTests
    {
        [TestMethod()]
        public void FindSecondMinTest_WithDuplicates()
        {
            var input = new decimal [] {4,2,2,4,5,5,1};
            double expectedOutput = 2;
            var requestLog = new RequestLogDbAccess();
            var arrayMinService = new ArrayMinService(requestLog);
            var result = arrayMinService.FindSecondMin(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod()]
        public void FindSecondMinTest()
        {
            var input = new decimal[] { 1,4,30,56 };
            double expectedOutput = 4;
            var requestLog = new RequestLogDbAccess();
            var arrayMinService = new ArrayMinService(requestLog);
            var result = arrayMinService.FindSecondMin(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod()]
        public void FindSecondMinTest_WithNegativeNumbers()
        {
            var input = new decimal[] { 1, -4, -30, 56 };
            double expectedOutput = -4;
            var requestLog = new RequestLogDbAccess();
            var arrayMinService = new ArrayMinService(requestLog);
            var result = arrayMinService.FindSecondMin(input);
            Assert.AreEqual(expectedOutput, result);
        }


        [TestMethod()]
        [ExpectedException(typeof(HttpResponseException))]
        public void FindSecondMinNumberAPITest_NullInput()
        {
            var requestLog = new RequestLogDbAccess();
            var arrayMinService = new ArrayMinService(requestLog);
            var controller = new ArrayMinController(arrayMinService);
            try
            {
                var result = controller.FindSecondMinNumber(null);

            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest);
                throw;
            }
        }
        [TestMethod()]
        [ExpectedException(typeof(HttpResponseException))]
        public void FindSecondMinNumberAPITest_InvalidInput()
        {
            var input = new int[] {1};
            var requestLog = new RequestLogDbAccess();
            var arrayMinService = new ArrayMinService(requestLog);
            var controller = new ArrayMinController(arrayMinService);
            try
            {
                var result = controller.FindSecondMinNumber(null);

            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest);
                throw;
            }
        }
    }
}