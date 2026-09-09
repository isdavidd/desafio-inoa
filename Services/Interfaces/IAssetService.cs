using Desafio_Inoa.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_Inoa.Services.Interfaces
{
    public interface IAssetService
    {
        Task<List<AssetDto>> GetAssetPrice(string assetSymbol);
    }
}
