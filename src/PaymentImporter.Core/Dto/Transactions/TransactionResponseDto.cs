using Newtonsoft.Json;

namespace PaymentImporter.Core.Dto.Transactions
{
    public class TransactionResponseDto
    {
        [JsonProperty("id")]
        public string TransactionId { get; set; }

        [JsonProperty("payment")]
        public string Payment { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
