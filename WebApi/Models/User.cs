using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public string Type { get; set; }
        public List<string> Roles { get; set; }
    }
}
