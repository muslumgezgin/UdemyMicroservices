﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Services.Catalog.Services
{
	public interface ICategoryService
	{
		Task<Response<List<CategoryDto>>> GetAllAsync();

		Task<Response<CategoryDto>> GetByIdAsync(string id);

		Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);

	}
}

