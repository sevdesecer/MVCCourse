namespace WebApp.Models
{
    public static class CategoriesRepository
    {
        // Static list to store categories
        private static List<Category> _categories = new List<Category>()
{
         new Category{CategoryId = 1, Name = "Beverage", Description = "Quench your thirst with our range of drinks."},
         new Category{CategoryId = 2, Name = "Bakery", Description = "Enjoy freshly baked goods for every occasion."},
         new Category{CategoryId = 3, Name = "Meat", Description = "Discover a selection of meats for hearty meals."},
         new Category{CategoryId = 4, Name = "Vegetables", Description = "Explore a variety of fresh vegetables for your cooking needs."}
};


        // Method to add a new category
        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        // Method to retrieve a category by its ID
        public static Category? GetCategoryById (int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId); // LINQ expressions
            if(category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                };
            }
            return null;
        }
        // Method to update an existing category
        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;
            
            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;    
            }
        }

        // Method to delete a category by its ID
        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if(category != null )
            {
                _categories.Remove(category);
            }
        }
    }
}
