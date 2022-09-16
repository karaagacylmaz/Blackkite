using BlackkiteCLI.Models.Environment;
using BlackkiteCLI.Models.RequestModel;
using BlackkiteCLI.Models.ResponseModel;
using BlackkiteCLI.Utils;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlackkiteCLI.Services
{
    public class HttpClientService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly Environments _environments;

        public HttpClientService()
        {
            _environments = EnvironmentVariables.Get();
            _httpClient.BaseAddress = new Uri(_environments.ApiBaseUrl);
            Log.Logger.Information("Requests Starting");
        }

        private async Task<string> GetToken()
        {
            var authToken = new Token()
            {
                client_id = _environments.ClientId,
                client_secret = _environments.ClientSecret,
                grant_type = _environments.GrantType
            };

            var authTokenData = JsonSerializer.Serialize(authToken);

            var requestContent = new StringContent(authTokenData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("oauth/token", requestContent);

            var content = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine(response.StatusCode);

            var createdToken = JsonSerializer.Deserialize<TokenResponse>(content);

            System.Console.WriteLine(createdToken.access_token + " - " + createdToken.token_type + " - " + createdToken.tenant_id);
            Log.Logger.Information(_httpClient.BaseAddress + "oauth/token");
            return createdToken.access_token;
        }

        public async Task<int> AddCompany()
        {
            string token = GetToken().GetAwaiter().GetResult().ToString();
            Company company = _environments.Company;
            var companyJson = JsonSerializer.Serialize(company);

            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var requestContent = new StringContent(companyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("companies", requestContent);

            var content = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine(response.StatusCode);
            Console.WriteLine(content);
            var createdCompany = JsonSerializer.Deserialize<Company>(content);
            Console.WriteLine(createdCompany.CompanyId + "-" + createdCompany.MainDomainValue);
            Log.Logger.Information(_httpClient.BaseAddress + "companies");
            Log.Logger.Information(companyJson);
            return createdCompany.CompanyId;
        }

        public async Task<CompanyDetail> GetScanStatus()
        {
            int companyId = AddCompany().GetAwaiter().GetResult();

            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await _httpClient.GetAsync($"companies/{companyId}");
            var content = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine(response.StatusCode);
            Console.WriteLine(content);

            var createdCompany = JsonSerializer.Deserialize<CompanyDetail>(content);

            Console.WriteLine(createdCompany.ScanStatus + "- " + createdCompany.CompanyId);
            await using FileStream createStream = File.Create(Directory.GetCurrentDirectory() + "\\company.json");
            await JsonSerializer.SerializeAsync(createStream, createdCompany, new JsonSerializerOptions { WriteIndented = true });
            Log.Logger.Information($"{_httpClient.BaseAddress}companies/{companyId}");
            return createdCompany;
        }

        public async void CreateSearchOperation()
        {
            var company = GetScanStatus().GetAwaiter().GetResult();
            var search = new Search()
            {
                GenericSearchText = "Health",
                EcosystemIds = company.Ecosystems != null ? company.Ecosystems.Select(x => x.EcosystemId).ToList() : new List<int?>(),
                IndustryIds = new List<int?> { company.Industry.IndustryId },
                CountryCodes = new List<string>(),
                TagIds = company.Tags != null ? company.Tags.Select(x => x.TagId).ToList() : new List<int?>(),
                ProductGroupIds = new List<int?>(),
                GradeLetters = new List<string> { company.CyberRating.GradeLetter },
                ControlCodes = new List<string>(),
                CveOrCweCodes = new List<string>(),
                CwssCvssBiggerThanValue = 1
            };

            var searchJson = JsonSerializer.Serialize(search);
            var requestContent = new StringContent(searchJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("companies/search", requestContent);

            var content = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine(response.StatusCode);

            Console.WriteLine(content);
            Log.Logger.Information(_httpClient.BaseAddress + "companies/search");
            Log.Logger.Information(searchJson);
        }
    }
}
