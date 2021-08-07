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
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace MCC52_SKS_Client.Repository.Data
{
    public class ContentRepository : GeneralRepository<Content, string>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public ContentRepository(Address address, string request = "Contents/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<GetContentVM>> ViewContent()
        {
            List<GetContentVM> entities = new List<GetContentVM>();

            using (var response = await httpClient.GetAsync(request + "GetAllData/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<GetContentVM>>(apiResponse);
            }
            return entities;
        }
        public async Task<List<GetContentVM>> ViewDetail(int contentId)
        {
            List<GetContentVM> entities = new List<GetContentVM>();

            using (var response = await httpClient.GetAsync(request + "GetAllData/" + contentId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<GetContentVM>>(apiResponse);
            }
            return entities;
        }
        public string JwtEmployeeId(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken result = tokenHandler.ReadJwtToken(token);

            return result.Claims.FirstOrDefault(claim => claim.Type.Equals("employeeId")).Value;
        }
        public async Task<string> InsertContent(Content content)
        {
            var apiResponse = "";
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(request, stringContent);
            if (result.IsSuccessStatusCode)
            {
                apiResponse = await result.Content.ReadAsStringAsync();
            }
            return apiResponse;
        }
    }
}
