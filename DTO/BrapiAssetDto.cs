using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Desafio_Inoa.DTO
{
    public class BrapiAssetDto
    {
        [JsonPropertyName("results")]
        public List<AssetDto> Results { get; set; }
    }

    public class AssetDto 
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }

    }

    public class Data 
    {
        [JsonPropertyName("longName")]
        public string LongName { get; set; }

        [JsonPropertyName("regularMarketPrice")]
        public decimal RegularMarketPrice { get; set; }
    }
}
