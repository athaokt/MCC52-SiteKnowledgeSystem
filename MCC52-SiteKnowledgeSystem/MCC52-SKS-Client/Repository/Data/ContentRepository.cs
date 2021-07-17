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

        public async Task<List<GetContentVM>> ViewContent(int contentId)
        {
            List<GetContentVM> entities = new List<GetContentVM>();

            using (var response = await httpClient.GetAsync(request + "GetAllData/" + contentId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<GetContentVM>>(apiResponse);
            }
            return entities;
        }
        public async Task<List<Content>> ViewDetail(int contentId)
        {
            List<Content> entities = new List<Content>();

            using (var response = await httpClient.GetAsync(request + "GetAllData/" + contentId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<Content>>(apiResponse);
            }
            return entities;
        }

    }
}
