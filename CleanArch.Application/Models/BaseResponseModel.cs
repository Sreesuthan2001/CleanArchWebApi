using System.Text.Json.Serialization;

namespace CleanArch.Application.Models
{
    [Serializable]
    public class BaseResponseModel
    {
        public BaseResponseModel()
        {
            Status = 0;
        }

        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}
