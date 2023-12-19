using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TechTest.API
{
    public static class AddressBookApi
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/AddressBook", GetAllAddresses);
            app.MapPost("/AddressBook/GetAddress", GetAddress);
            app.MapPost("/AddressBook", AddAddress);
            app.MapPut("/AddressBook", UpdateAddress);
            app.MapDelete("/AddressBook", DeleteAddress);
        }

        private static async Task<IResult> GetAllAddresses()
        {
            return null;
        }

        private static async Task<IResult> GetAddress()
        {
            return null;
        }

        private static async Task<IResult> AddAddress()
        {
            return null;
        }

        private static async Task<IResult> UpdateAddress()
        {
            return null;
        }
        private static async Task<IResult> DeleteAddress()
        {
            return null;
        }
    }
}
