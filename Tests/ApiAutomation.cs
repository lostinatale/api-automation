
using Newtonsoft.Json;
using System.Net;

namespace Tests
{
    [TestClass]
    public class SmokeTests
    {
        [TestMethod]
        public void TokenTest()
        {
            HttpResponseMessage response = ApiCalls.CreateTokenCall();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string myContent = response.Content.ReadAsStringAsync().Result;
            TokenResponse tokenResponse = (TokenResponse)JsonConvert.DeserializeObject(myContent, typeof(TokenResponse));
            Assert.IsNotNull(tokenResponse);
        }

        [TestMethod]
        public void GetBookingIdsTest()
        {
            HttpResponseMessage response = ApiCalls.GetBookingIdsCall();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string myContent = response.Content.ReadAsStringAsync().Result;
            BookingIds[] bookingIds = (BookingIds[])JsonConvert.DeserializeObject(myContent, typeof(BookingIds[]));
            Assert.IsNotNull(bookingIds);
        }

        [TestMethod]
        public void CreateBookingTest()
        {
            HttpResponseMessage response = ApiCalls.CreateBookingCall();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
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
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
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
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string myContent = response.Content.ReadAsStringAsync().Result;
            CreateBookingResponse bookingResponse = (CreateBookingResponse)JsonConvert.DeserializeObject(myContent, typeof(CreateBookingResponse));
            Assert.IsNotNull(bookingResponse);
        }

        [TestMethod]
        public void DeleteBookingTest()
        {
            string token = ApiCalls.GetToken();
            int bookingId = ApiCalls.GetBookingId();
            HttpResponseMessage response = ApiCalls.DeleteBookingCall(bookingId, token);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            string myContent = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(myContent);
        }
    }
}
