using DemoMVC.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Linq;

namespace DemoMVC.Repositories
{
    /// <summary>
    /// Imformation of CategoryRepository
    /// CreatedBy: ThiepTT(30/09/2022)
    /// </summary>
    public class CategoryRepository : IBaseRepository<Category>
    {
        #region Feild

        private readonly DBContext _context = null;

        #endregion Feild

        #region Contructor

        public CategoryRepository(IOptions<Settings> settings)
        {
            _context = new DBContext(settings);
        }

        #endregion Contructor

        #region Method

        public IEnumerable<Category> GetAll()
        {
            try
            {
                IEnumerable<Category> categories = _context.Categories.Find(_ => true).ToList();
                return categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Category> GetBySearchValue(string valueSearch)
        {
            try
            {
                List<Category> categories = _context.Categories.Find(_ => true).ToList();

                List<Category> categoriesByValueSearch = categories.Where(category => category.Name.ToString().ToLower().Trim().Contains(valueSearch.ToLower().Trim().ToString())
                             || category.DisplayOrder.ToString().ToLower().Trim().Contains(valueSearch.ToLower().Trim().ToString()))
                             .ToList();

                return categoriesByValueSearch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category GetById(Guid id)
        {
            try
            {
                Category category = _context.Categories.Find(doc => doc.Id == id).FirstOrDefault();
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(Category category)
        {
            try
            {
                _context.Categories.InsertOneAsync(category);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                DeleteResult actionResult = _context.Categories.DeleteMany(n => n.Id.Equals(id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Guid id, Category category)
        {
            try
            {
                IMongoCollection<Category> categories = _context.Categories;

                Expression<Func<Category, bool>> filter = x => x.Id.Equals(id);

                Category categoryUpdate = categories.Find(filter).FirstOrDefault();

                if (categoryUpdate != null)
                {
                    categoryUpdate.Name = category.Name;
                    categoryUpdate.DisplayOrder = category.DisplayOrder;
                    ReplaceOneResult result = categories.ReplaceOne(filter, categoryUpdate);

                    return result.IsAcknowledged && result.ModifiedCount > 0;
                }
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Method
    }
}