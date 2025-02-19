﻿using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreeCourse.Shared.Dtos;
using FreeCourse.Web.Models.Discount;
using FreeCourse.Web.Services.Interfaces;

namespace FreeCourse.Web.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DiscountViewModel> GetDiscount(string discountCode)
        {
            var response = await _httpClient.GetAsync($"discount/getbycode/{discountCode}");

            if(!response.IsSuccessStatusCode)
            {
                return null;
            }

            var discount = await response.Content.ReadFromJsonAsync<Response<DiscountViewModel>>();

            return discount.Data;
        }
    }
}

