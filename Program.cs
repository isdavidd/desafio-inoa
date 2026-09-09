using Desafio_Inoa.Configs;
using Desafio_Inoa.DTO;
using Desafio_Inoa.Services;


EmailService emailService = new EmailService();

AssetService assetService = new AssetService(new HttpClient());

List<AssetDto> assetPrice = await assetService.GetAssetPrice("ITUB4");

foreach (AssetDto asset in assetPrice)
{
    Console.WriteLine(asset.Symbol);
    Console.WriteLine(asset.Data.LongName);
    Console.WriteLine(asset.Data.RegularMarketPrice);
}

//await emailService.SendEmails("Teste", "Teste");
    