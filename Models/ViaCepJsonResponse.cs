using System.Text.Json.Serialization;

namespace Models;

public class ViaCepJsonResponse
{
    /*
 *
{
 "cep": "14805-424",
 "logradouro": "Avenida Engenheiro Guilherme Bannitz",
 "complemento": "",
 "bairro": "Residencial Cambuy",
 "localidade": "Araraquara",
 "uf": "SP",
 "ibge": "3503208",
 "gia": "1818",
 "ddd": "16",
 "siafi": "6163"
}
 */
    [JsonPropertyName("cep")] public string Cep { get; set; }
    [JsonPropertyName("logradouro")] public string Logradouro { get; set; }
    [JsonPropertyName("complemento")] public string Complemento { get; set; }
    [JsonPropertyName("bairro")] public string Bairro { get; set; }
    [JsonPropertyName("localidade")] public string Localidade { get; set; }
    [JsonPropertyName("uf")] public string Uf { get; set; }
    [JsonPropertyName("ibge")] public string Ibge { get; set; }
    [JsonPropertyName("gia")] public string Gia { get; set; }
    [JsonPropertyName("ddd")] public string Ddd { get; set; }
    [JsonPropertyName("siafi")] public string Siafi { get; set; }
}