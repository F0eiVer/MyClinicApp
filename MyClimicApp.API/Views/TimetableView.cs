using System;
using System.Text.Json.Serialization;

namespace MyClimicApp.API.Views
{
    public class TimetableView
    {

        [JsonPropertyName("doctorID")]
        public uint DoctorID { get; set; }

        [JsonPropertyName("startTime")]
        public string StartTime { get; set; }

        [JsonPropertyName("finishTime")]
        public string FinishTime { get; set; }
    }
}
