using Newtonsoft.Json;
using System.Text;

namespace Tests
{
    public class ApiCalls
    {
        static string baseAddress = "https://restful-booker.herokuapp.com/";

        public static HttpResponseMessage CreateTokenCall()
        {
            HttpResponseMessage response;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                string content = """{ "username" : "admin", "password" : "password123"} """;

                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                response = client.PostAsync("auth", bodyContent).Result;
            }

            return response;
        }

        public static HttpResponseMessage GetBookingIdsCall()
        {
            HttpResponseMessage response;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                response = client.GetAsync("booking").Result;
            }

            return response;
        }

        public static HttpResponseMessage GetBookingCall(int bookingId)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                client.DefaultRequestHeaders.Add("Accept", "application/json");

                response = client.GetAsync("booking/" + bookingId.ToString()).Result;
            }

            return response;
        }

        public static HttpResponseMessage CreateBookingCall()
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                client.DefaultRequestHeaders.Add("Accept", "application/json");

                string content = """
                    { 
                        "firstname" : "Jim",
                        "lastname" : "Brown",
                        "totalprice" : 111,
                        "depositpaid" : false,
                        "bookingdates" : {
                            "checkin": "2018-09-07",
                            "checkout": "2018-09-08"
                        },
                        "additionalneeds" : "Breakfast"
                    }
                    """;

                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                response = client.PostAsync("booking", bodyContent).Result;
            }

            return response;
        }

        public static HttpResponseMessage UpdateBookingCall(int bookingId, string token)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Cookie", "token=" + token);

                string content = """
                    { 
                        "firstname" : "Jim",
                        "lastname" : "Brown",
                        "totalprice" : 111,
                        "depositpaid" : false,
                        "bookingdates" : {
                            "checkin": "2018-09-07",
                            "checkout": "2018-09-08"
                        },
                        "additionalneeds" : "Breakfast"
                    }
                    """;

                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                response = client.PutAsync("booking/" + bookingId, bodyContent).Result;
            }

            return response;
        }

        public static HttpResponseMessage PartialUpdateBookingCall(int bookingId, string token)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Cookie", "token=" + token);

                string content = """
                    { 
                        "firstname" : "Jim",
                        "lastname" : "Brown"
                    }
                    """;

                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                response = client.PatchAsync("booking/" + bookingId, bodyContent).Result;
            }

            return response;
        }

        public static HttpResponseMessage DeleteBookingCall(int bookingId, string token)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Cookie", "token=" + token);

                response = client.DeleteAsync("booking/" + bookingId).Result;
            }

            return response;
        }

        public static int GetBookingId()
        {
            HttpResponseMessage response = GetBookingIdsCall();
            string mycontent = response.Content.ReadAsStringAsync().Result;
            BookingIds[] getBookingIdsResponse = (BookingIds[])JsonConvert.DeserializeObject(mycontent, typeof(BookingIds[]));
            return getBookingIdsResponse.First().bookingid;
        }

        public static string GetToken()
        {
            HttpResponseMessage response = CreateTokenCall();
            string mycontent = response.Content.ReadAsStringAsync().Result;
            TokenResponse tokenResponse = (TokenResponse)JsonConvert.DeserializeObject(mycontent, typeof(TokenResponse));
            return tokenResponse.token;
        }

    }
}