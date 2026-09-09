using Desafio_Inoa.Configs;
using Desafio_Inoa.Domain.DTO;
using Desafio_Inoa.Domain.Enums;
using Desafio_Inoa.Services;
using System.Globalization;
using System.Timers;


EmailService emailService = new EmailService();

AssetService assetService = new AssetService(new HttpClient());

Console.WriteLine("------------------------------- DESAFIO TÉCNICO INOA -------------------------------");


string assetTicker = args[0];

decimal sellPrice = decimal.Parse(args[1], CultureInfo.InvariantCulture);

decimal buyPrice = decimal.Parse(args[2], CultureInfo.InvariantCulture);


if (!Enum.GetNames<AssetTickers>().Any(ticker => string.Equals(ticker, assetTicker, StringComparison.OrdinalIgnoreCase)))
{
    Console.WriteLine("\nTicker inválido!. Os ativos válidos são: ITUB4, VALE3, MGLU3 ou PETR4.");
    return;
}

if ((sellPrice <= 0 || buyPrice <= 0) || (sellPrice <= buyPrice))
{
    Console.WriteLine("\nValores de preços inválidos de compra e/ou venda inválidos! Os valores precisam ser positivos e o preço de venda deve ser maior que o preço de compra!");
    return;
}

while (true)
{
    Console.WriteLine($"\nTicker escolhido: {assetTicker} | Preço de venda: {sellPrice} | Preço de compra: {buyPrice}");

    Console.WriteLine("\nMonitorando o preço do ativo a cada 2 minutos...");

    List<AssetDto> assetPrice = await assetService.GetAssetPrice(assetTicker.ToUpper());

    Console.WriteLine("\nPreço atual do ativo: " + assetPrice[0].Data.RegularMarketPrice);
    Console.WriteLine("\nAtivo: " + assetPrice[0].Data.LongName);
    
    if (assetPrice[0].Data.RegularMarketPrice >= sellPrice)
    {
        Console.WriteLine("\nO preço do ativo atingiu o preço teto!");

        await emailService.SendEmails($"VENDA DE {assetPrice[0].Symbol}", $"Olá! O ativo {assetPrice[0].Data.LongName} atingiu o preço teto de venda {sellPrice}!");
    }
    else if (assetPrice[0].Data.RegularMarketPrice <= buyPrice)
    {
        Console.WriteLine("\nO preço do ativo atingiu o valor de compra definido!");

        await emailService.SendEmails($"COMPRA DE {assetPrice[0].Symbol}", $"Olá! O ativo {assetPrice[0].Data.LongName} atingiu o preço piso de compra de {buyPrice}!");
    }

    Console.WriteLine("\n-------------------------------------------------------------------------------");

    await Task.Delay(TimeSpan.FromSeconds(30));

}
    