using MyClinicApp.Domain.Classes;
using System.Text.Json.Serialization;

namespace MyClimicApp.API.Views
{
    public class UserView
    {

        //По логике данного класса, он не должен иметь пароль пользователя
        //Если я не прав, то поправьте меня.

        [JsonPropertyName("id")]
        public ulong ID { get; set; }

        [JsonPropertyName("phoneNumber")]
        public ulong PhoneNumber { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("role")]
        public Role Role { get; set; }
    }
}
