This is a .NET test project to test the [Restful Booker Api](https://restful-booker.herokuapp.com/apidoc/index.html).

To run it, you will require Visual Studio 2022, or Visual Studio Code with the C# Developer kit. 

Tests can be run from the command line using dotnet test. 

Bugs found so far:

- Token call returns a 200 OK when successful, would expect this to be 201 Created as it is a POST call
- Delete Booking call returns a 201 Created, would expect to be 204 No Content as DELETE call
- Delete Booking call returns a string response of "Created", not needed 
- If the GetBooking call, Create Booking Call, Update Booking call, or PartialUpdateBooking calls do not have the "Accept" header, the API returns 418 Teapot code

