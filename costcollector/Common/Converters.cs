using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using costcollector.Infrastructure.Models;

namespace costcollector.Common;

public class AllegroTypeConverter : JsonConverter<AllegroType>
{
    public override AllegroType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var val = JsonDocument.ParseValue(ref reader).RootElement;
        var id = val.GetProperty("id").ToString();
        var name = val.GetProperty("name").ToString();
        return new AllegroType(id, name);
    }

    public override void Write(Utf8JsonWriter writer, AllegroType value, JsonSerializerOptions options) =>
        throw new NotImplementedException();
}

public class AllegroValueConverter : JsonConverter<AllegroValue>
{
    public override AllegroValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var val = JsonDocument.ParseValue(ref reader).RootElement;
        var amountAsString = val.GetProperty("amount").ToString();
        var currencyAsString = val.GetProperty("currency").ToString();

        return new AllegroValue(
            decimal.Parse(amountAsString, NumberStyles.Number, CultureInfo.InvariantCulture), 
            currencyAsString);
    }

    public override void Write(Utf8JsonWriter writer, AllegroValue allegroValue, JsonSerializerOptions options) =>
        throw new NotImplementedException();
} 

public class AllegroTaxConverter : JsonConverter<AllegroTax>
{
    public override AllegroTax Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var val = JsonDocument.ParseValue(ref reader).RootElement;
        var percentageAsString = val.GetProperty("percentage").ToString();
        return new AllegroTax(double.Parse(percentageAsString, NumberStyles.Number, CultureInfo.InvariantCulture));
    }

    public override void Write(Utf8JsonWriter writer, AllegroTax allegroValue, JsonSerializerOptions options) =>
        throw new NotImplementedException();
}

public class AllegroOfferConverter : JsonConverter<AllegroOffer>
{
    public override AllegroOffer Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var val = JsonDocument.ParseValue(ref reader).RootElement;
        var idAsString = val.GetProperty("id").ToString();
        var nameAsString = val.GetProperty("name").ToString();
        return new AllegroOffer(
            long.Parse(idAsString, NumberStyles.Number, CultureInfo.InvariantCulture),
            nameAsString);
    }

    public override void Write(Utf8JsonWriter writer, AllegroOffer allegroValue, JsonSerializerOptions options) =>
        throw new NotImplementedException();
}

public class AllegroOrderConverter : JsonConverter<AllegroOrder>
{
    public override AllegroOrder Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var val = JsonDocument.ParseValue(ref reader).RootElement;
        var idAsString = val.GetProperty("id").ToString();
        return new AllegroOrder(Guid.Parse(idAsString));
    }

    public override void Write(Utf8JsonWriter writer, AllegroOrder allegroValue, JsonSerializerOptions options) =>
        throw new NotImplementedException();
}