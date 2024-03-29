using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public interface IViaCEPService
{
    Task<string> GetAddressAsync(string cep);
}

public class ViaCEPService : IViaCEPService
{
    private readonly HttpClient _httpClient;

    public ViaCEPService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<string> GetAddressAsync(string cep)
    {
        try
        {
            // Constrói a URL de consulta com base no CEP fornecido
            var url = $"http://viacep.com.br/ws/{cep}/json/";

            // Realiza a requisição HTTP GET para o serviço ViaCEP
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // Lê o conteúdo da resposta como uma string
            var content = await response.Content.ReadAsStringAsync();

            // Deserializa a string JSON para um objeto dinâmico
            var addressData = JsonSerializer.Deserialize<ViaCEPAddress>(content);

            // Obtém os detalhes do endereço do objeto desserializado
            string address = addressData.logradouro + ", " +
                             addressData.localidade + " - " +
                             addressData.uf + ", " +
                             addressData.cep;

            return address;
        }
        catch (HttpRequestException ex)
        {
            // Trata exceções de requisição HTTP (por exemplo, falha na conexão)
            // Aqui você pode lidar com a exceção de acordo com a necessidade do seu aplicativo
            throw new Exception("Error occurred while retrieving address information.", ex);
        }
        catch (JsonException ex)
        {
            // Trata exceções de desserialização JSON (por exemplo, formato JSON inválido)
            // Aqui você pode lidar com a exceção de acordo com a necessidade do seu aplicativo
            throw new Exception("Error occurred while parsing address information.", ex);
        }
    }

    internal class ViaCEPAddress
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
    }

}
