﻿using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebUI.Services.Contracts;

namespace WebUI.Services
{
    internal class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ProductDTO> GetItem(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProductDTO);
                    }

                    return await response.Content.ReadFromJsonAsync<ProductDTO>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetItems()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Product");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductDTO>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }

            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{categoryId}/GetItemsByCategory");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductDTO>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetProductCategories()
        {
            try
            {
                var response = await httpClient.GetAsync("api/Product/GetProductCategories");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductCategoryDTO>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProductCategoryDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }
    }
}
