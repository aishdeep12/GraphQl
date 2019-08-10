using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using GraphQlApp;
using GraphQL.Client;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using GithubUserResponse;

namespace GraphQlApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //Responselabel.Text = "Fetching data ";
            var client = new GraphQLClient("https://swapi.apis.guru/graphiql");

         // var client = new GraphQLClient("https://api.github.com/graphql");
            //client.DefaultRequestHeaders.Add("Authorization", "bearer 04b7b664f0eb7ca3501fae74a9036f99e0215c28");
            //client.DefaultRequestHeaders.Add("User-Agent", "graphQl.App");

            GraphQLRequest graphQLRequest = new GraphQLRequest
            {

                Query = "query{allFilms {films {director title}}}"

                //Query = "query {user(login: aishdeep12){    id,  createdAt,   location,    name} }"
            };

            GraphQLResponse graphQLResponse = await client.PostAsync(graphQLRequest);

            //Responselabel.Text = graphQLResponse.Data.user.name;
            FilmData.ItemsSource = graphQLResponse.Data.allFilms.films.ToObject<List<Film>>();


        }

    }
}
