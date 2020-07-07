using EntityFrameworks.Model;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using Services;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace GETAPINEWS
{
    class Program
    {
        public static void Main(string[] args)
        {
            NewspaperService newsser = new NewspaperService();
               // init with your API key
               var newsApiClient = new NewsApiClient("914d8fef143942c39a32447f42eb7831");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "bitcoin",
                SortBy = SortBys.PublishedAt,
              
             

            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);
                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {
                    // title
                    Console.WriteLine(article.Title);
                    // author
                    Console.WriteLine(article.Author);
                    // description
                    Console.WriteLine(article.Description);
                    // url
                    Console.WriteLine(article.Url);
                    // published at
                    Console.WriteLine(article.PublishedAt);
                    newsser.AddNewspaper(new Newspaper() { Journalist="thuylinh",Active = 1, Description = article.Description, Image = article.UrlToImage, PublicationDate = DateTime.Now, Title = article.Title });

                }
            }
            Console.ReadLine();
            Console.ReadKey();
        }
    }
    }

