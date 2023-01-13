using System;
using System.Text.Json.Serialization;

namespace MyClimicApp.API.Views
{
    public class AppointmentView
    {
        [JsonPropertyName("id")]
        public uint ID { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("startTime")]
        public string StartTime { get; set; }

        [JsonPropertyName("finishTime")]
        public string FinishTime { get; set; }

        [JsonPropertyName("patientID")]
        public ulong PatientID { get; set; }

        [JsonPropertyName("doctorID")]
        public ulong DoctorID { get; set; }
    }
}
