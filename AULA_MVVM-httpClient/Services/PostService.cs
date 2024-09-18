using AULA_MVVM_httpClient.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AULA_MVVM_httpClient.Services
{
    public class PostService
    {
        HttpClient client;
        JsonSerializerOptions options;
        public ObservableCollection<Post> posts;

        public PostService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }
        public async Task<ObservableCollection<Post>> GetPosts()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");
            try
            {
                HttpResponseMessage httpResponseMessage = client.GetAsync(uri).Result;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string content = await httpResponseMessage.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<ObservableCollection<Post>>(content, options);
                }
            }
            catch (Exception ex)
            {
            }
            return posts;
        }

        internal static async Task<List<Post>> getPosts()
        {
            throw new NotImplementedException();
        }
    }
}


                                                                                  