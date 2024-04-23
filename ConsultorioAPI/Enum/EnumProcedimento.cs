using System.Text.Json.Serialization;

namespace ConsultorioAPI.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumProcedimento
    {
        Retorno,
        Cirurgia,
        Consulta
    }
}
