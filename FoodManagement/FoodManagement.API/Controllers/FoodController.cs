using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodManagement.Models;
using FoodManagement.Services;

namespace FoodManagement.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly FoodService _foodService;

        public FoodController(FoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetFoodsCount()
        {
            try
            {
                var count = await _foodService.GetFoodsCount();
                return Ok(count);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoods()
        {
            try
            {
                var foods = await _foodService.GetAllFoods();
                return Ok(foods);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<IActionResult> SearchFoods(string searchTerm)
        {
            try
            {
                var foods = await _foodService.SearchFoods(searchTerm);
                return Ok(foods);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("tags")]
        public async Task<IActionResult> GetAllTags()
        {
            try
            {
                var tags = await _foodService.GetAllTags();
                return Ok(tags);
            }
            catch (Exception ex)
            {

                // Log the exception
                return StatusCode(500, "Internal Server Error 1 "+ex.Message);
            }
        }

        [HttpGet("tag/{tagName}")]
        public async Task<IActionResult> GetFoodsByTag(string tagName)
        {
            try
            {
                var foods = await _foodService.GetFoodsByTag(tagName);
                return Ok(foods);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{foodId}")]
        public async Task<IActionResult> GetFoodById(string foodId)
        {
            try
            {
                var food = await _foodService.GetFoodById(foodId);
                if (food == null)
                    return NotFound();

                return Ok(food);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
