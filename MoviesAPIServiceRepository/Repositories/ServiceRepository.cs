using Newtonsoft.Json;
using ServersideServices.DAL.Interfaces;
using ServersideServices.DAL.Models;
using System;
using System.IO;
using System.Net;

namespace ServersideRepository.DAL.Repositories
{
    public class ServiceRepository: IService
    {

            string key = "9a641d7ad668061cbadbd503b17ed7cf";
            public Result GetPopular()
            {

                string getResponse = "";

                HttpWebRequest webRequest = WebRequest.CreateHttp($"https://api.themoviedb.org/3/movie/popular?api_key={key}&page=20");

                using (HttpWebResponse webresponse = webRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(webresponse.GetResponseStream());
                    getResponse = reader.ReadToEnd();

                }


                Result movieProperties = JsonConvert.DeserializeObject<Result>(getResponse);

                return movieProperties;

            }

            public SearchSingle GetSingleMovie(int id)
            {
                string getResponse = "";

                try
                {
                    HttpWebRequest request = WebRequest.CreateHttp($"https://api.themoviedb.org/3/movie/{id}?api_key={key}&language=en-US");

                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        getResponse = reader.ReadToEnd();

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

               // MovieProperties movieProperties = JsonConvert.DeserializeObject<MovieProperties>(getResponse);
                SearchSingle single = JsonConvert.DeserializeObject<SearchSingle>(getResponse);
                return single;
            }

            public Result SearchForMovie(string movieName)
            {
                string getResponse = "";

                HttpWebRequest request = WebRequest.CreateHttp($"https://api.themoviedb.org/3/search/movie?api_key={key}&query={movieName}");

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    getResponse = reader.ReadToEnd();

                }

                Result movieProperties = JsonConvert.DeserializeObject<Result>(getResponse);

                return movieProperties;
            }

            public SearchSingle GetById(int id)
            {
                string getResponse = "";

                HttpWebRequest request = WebRequest.CreateHttp($"https://api.themoviedb.org/3/movie/{id}?api_key={key}&language=en-US");
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    getResponse = reader.ReadToEnd();

                }

                SearchSingle single = JsonConvert.DeserializeObject<SearchSingle>(getResponse);
                return single;
            }

        }
    }
