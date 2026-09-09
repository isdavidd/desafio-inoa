using Desafio_Inoa.Domain.DTO;
using Desafio_Inoa.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Timers;

namespace Desafio_Inoa.Services
{
    public class AssetService : IAssetService
    {
        private readonly HttpClient _httpClient;

        public AssetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<List<AssetDto>> GetAssetPrice(string assetSymbol)
        {
            var response = await _httpClient.GetFromJsonAsync<BrapiAssetDto>($"https://brapi.dev/api/v2/stocks/quote?symbols={assetSymbol}");

            return response.Results;
        }
    }
}
