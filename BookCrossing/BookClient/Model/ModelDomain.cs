using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Reflection;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;

namespace BookClient.Model
{
    class ModelDomain
    {
        public class BaseModelEntity<T>  where T : Entity
        {
            public T Entity { get; set; }
            private string _path;

            public event EventHandler<CustomEventArgs<T>> Updated = delegate { };
            public event EventHandler<CustomEventArgs<T>> Created = delegate { };

            public BaseModelEntity()
            {
                _path = typeof(T).Name;

                Type entityType = typeof(T);
                ConstructorInfo ci = entityType.GetConstructor(new Type[] { });
                Entity = (T)ci.Invoke(new object[] { });

            }

            public BaseModelEntity(int id)
            {
                _path = typeof(T).Name;
                Entity = FindById(id);
            }

            public T FindById(int id)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["RestServiceURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("api/" + _path + "/" + Convert.ToString(id)).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsAsync<T>().Result;
                    }
                    else
                    {
                        return default(T);
                    }

                }
            }

            public void Post(T entity)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["RestServiceURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync("api/" + _path, entity).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Created(this,
                            new CustomEventArgs<T>(entity));
                    }
                }
            }

            public void Update(int id, T entity)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["RestServiceURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("api/" + _path + "/" + Convert.ToString(id)).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        response = client.PutAsJsonAs   ync("api/" + _path + "/" + Convert.ToString(id), entity).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Entity = FindById(id);
                            Updated(this,
                                new CustomEventArgs<T>(entity));
                        }
                    }
                }
            }

            public void Delete(int id)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["RestServiceURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("api/" + _path + "/" + Convert.ToString(id)).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Uri entityUrl = response.Headers.Location;
                        response = client.DeleteAsync("api/" + _path + "/" + Convert.ToString(id)).Result;
                    }
                }
            }
        }
    }
}
