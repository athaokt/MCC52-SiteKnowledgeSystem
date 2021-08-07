//using MCC52_SKS_API.Models;
using Microsoft.AspNetCore.Http;
using MCC52_SKS_Client.Base;
using MCC52_SKS_Client.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MCC52_SiteKnowledgeSystem.Model;
using MCC52_SKS_Client.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MCC52_SKS_Client.Repository.Data
{
    public class RequestFormRepository : GeneralRepository<RequestFormRepository, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public RequestFormRepository(Address address, string request = "RequestForms/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public async Task<List<RequestForm>> ViewRequest()
        {
            List<RequestForm> entities = new List<RequestForm>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RequestForm>>(apiResponse);
            }
            return entities;
        }
        public string JwtEmployeeId(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken result = tokenHandler.ReadJwtToken(token);

            return result.Claims.FirstOrDefault(claim => claim.Type.Equals("employeeId")).Value;
        }

        public async Task<string> InsertRequest(RequestForm requestform)
        {
            var apiResponse = "";
            StringContent content = new StringContent(JsonConvert.SerializeObject(requestform), Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(request, content);
            if (result.IsSuccessStatusCode)
            {
                apiResponse = await result.Content.ReadAsStringAsync();
            }
            return apiResponse;
        }
    }
}