using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodManagement.Models;
using FoodManagement.FoodDBContext;

namespace FoodManagement.Services
{
    public class FoodService 
    {
        private readonly DataDbConext _context;

        public FoodService(DataDbConext context)
        {
            _context = context;
        }

        public async Task<int> GetFoodsCount()
        {
            return await _context.Foods.CountAsync();
        }

        public async Task<List<Food>> GetAllFoods()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<List<Food>> SearchFoods(string searchTerm)
        {
            return await _context.Foods.Where(f => f.Name.ToLower().Contains(searchTerm.ToLower())).ToListAsync();
        }
        public async Task<List<string>> GetAllTags()
        {
            var foods = await _context.Foods.ToListAsync();
            return foods.SelectMany(f => f.Tags).Distinct().ToList();
        }


        public async Task<List<Food>> GetFoodsByTag(string tagName)
        {
            return await _context.Foods.Where(f => f.Tags.Contains(tagName)).ToListAsync();
        }

        public async Task<Food> GetFoodById(string foodId)
        {
            return await _context.Foods.FirstOrDefaultAsync(f => f.Id == foodId);
        }
    }
}
