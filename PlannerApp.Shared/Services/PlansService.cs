﻿using AKSoftware.WebApi.Client;
using PlannerApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace PlannerApp.Shared.Services
{
    public class PlansService
    {
        private readonly string _baseUrl;

        ServiceClient client = new ServiceClient();

        public PlansService(string url)
        {
            _baseUrl = url;
        }

        private string AccessToken
        {
            get => client.AccessToken;
            set
            {
                client.AccessToken = value;
            }
        }
        /// <summary>
        /// Retrieve all the plans from the API with pagination
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<PlansCollectionPagingResponse> GetAllPlansByPageAsync(int page)
        {
            var response = await client.GetProtectedAsync<PlansCollectionPagingResponse>($"{_baseUrl}/api/plans?page={page}");
            return response.Result;
        }

        /// <summary>
        /// Retrieve all the plans from the API with pagination
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<PlansCollectionPagingResponse> SearchPlansByPageAsync(string query, int page=1)
        {
            var response = await client.GetProtectedAsync<PlansCollectionPagingResponse>($"{_baseUrl}/api/plans?query={query}&query={page}");
            return response.Result;
        }
    }
}
