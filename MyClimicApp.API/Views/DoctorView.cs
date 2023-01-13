using MyClinicApp.Domain.Classes;
using System.Text.Json.Serialization;

namespace MyClimicApp.API.Views
{
    public class DoctorView
    {
        [JsonPropertyName("id")]
        public ulong ID { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("specialization")]
        public Specialization Specialization { get; set; }
    }
}
