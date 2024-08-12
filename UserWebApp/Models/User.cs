using System.Text.Json.Serialization;

namespace UserWebApp.Models
{
    public class User
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        
        [JsonPropertyName("name")] 
        public string Name { get; set; }
        
        [JsonPropertyName("phone")] 
        public string Phone { get; set; }
        
        [JsonPropertyName("street")] 
        public string Street { get; set; }
        
        [JsonPropertyName("city")] 
        public string City { get; set; }
        
        [JsonPropertyName("neighborhood")] 
        public string Neighborhood { get; set; }
        
        [JsonPropertyName("zipCode")] 
        public string ZipCode { get; set; }
        
        [JsonPropertyName("state")] 
        public string State { get; set; }
        
        [JsonPropertyName("email")] 
        public string Email { get; set; }
        
        [JsonPropertyName("password")] 
        public string Password { get; set; }




    }
}
