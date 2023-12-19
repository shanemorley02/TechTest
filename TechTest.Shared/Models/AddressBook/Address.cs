using Newtonsoft.Json;

namespace TechTest.Shared.Models.AddressBook
{
    public class Address
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "first_name")]
        public string? FirstName { get; set; }
        [JsonProperty(PropertyName = "last_name")]
        public string? LastName { get; set; }
        [JsonProperty(PropertyName = "phone")]
        public string? Phone { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string? Email { get; set; }
    }
}
