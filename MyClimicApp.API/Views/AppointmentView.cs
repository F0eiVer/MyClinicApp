using System;
using System.Text.Json.Serialization;

namespace MyClimicApp.API.Views
{
    public class AppointmentView
    {

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
