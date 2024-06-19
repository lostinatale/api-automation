
using Newtonsoft.Json;

namespace Tests
{
    [TestClass]
    public class ApiAutomation
    {
        [TestMethod]
        public void TokenTest()
        {
            HttpResponseMessage response = ApiCalls.CreateTokenCall();
            Assert.IsTrue(response.IsSuccessStatusCode);
            string myContent = response.Content.ReadAsStringAsync().Result;
            TokenResponse tokenResponse = (TokenResponse)JsonConvert.DeserializeObject(myContent, typeof(TokenResponse));
            Assert.IsNotNull(tokenResponse);
        }

        [TestMethod]
        public void GetBookingIdsTest()
        {
            HttpResponseMessage response = ApiCalls.CreateTokenCall();
            Assert.IsTrue(response.IsSuccessStatusCode);
            string myContent = response.Content.ReadAsStringAsync().Result;
            TokenResponse tokenResponse = (TokenResponse)JsonConvert.DeserializeObject(myContent, typeof(TokenResponse));
            Assert.IsNotNull(tokenResponse);
        }

        [TestMethod]
        public void CreateBookingTest()
        {
            HttpResponseMessage response = ApiCalls.CreateBookingCall();
            Assert.IsTrue(response.IsSuccessStatusCode);
            string myContent = response.Content.ReadAsStringAsync().Result;
            CreateBookingResponse bookingResponse = (CreateBookingResponse)JsonConvert.DeserializeObject(myContent, typeof(CreateBookingResponse));
            Assert.IsNotNull(bookingResponse);
        }

        [TestMethod]
        public void UpdateBookingTest()
        {
            string token = ApiCalls.GetToken();
            int bookingId = ApiCalls.GetBookingId();
            HttpResponseMessage response = ApiCalls.UpdateBookingCall(bookingId, token);
            Assert.IsTrue(response.IsSuccessStatusCode);
            string myContent = response.Content.ReadAsStringAsync().Result;
            CreateBookingResponse bookingResponse = (CreateBookingResponse)JsonConvert.DeserializeObject(myContent, typeof(CreateBookingResponse));
            Assert.IsNotNull(bookingResponse);
        }

        [TestMethod]
        public void PartialUpdateBookingTest()
        {
            string token = ApiCalls.GetToken();
            int bookingId = ApiCalls.GetBookingId();
            HttpResponseMessage response = ApiCalls.PartialUpdateBookingCall(bookingId, token);
            Assert.IsTrue(response.IsSuccessStatusCode);
            string myContent = response.Content.ReadAsStringAsync().Result;
            CreateBookingResponse bookingResponse = (CreateBookingResponse)JsonConvert.DeserializeObject(myContent, typeof(CreateBookingResponse));
            Assert.IsNotNull(bookingResponse);
        }

        [TestMethod]
        public void DeleteBookingTest()
        {
            string token = ApiCalls.GetToken();
            int bookingId = ApiCalls.GetBookingId();
            HttpResponseMessage response = ApiCalls.PartialUpdateBookingCall(bookingId, token);
            Assert.IsTrue(response.IsSuccessStatusCode);
            string myContent = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(myContent);
        }
    }
}