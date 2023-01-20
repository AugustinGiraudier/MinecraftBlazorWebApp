using TPBlazorApp.Models;

namespace TPBlazorApp.Services
{
    public interface IDataService
    {
        Task Add(ItemModel model);

        Task<int> Count();

        Task<List<Item>> List(int currentPage, int pageSize);

        Task<Item> GetById(int id);

        Task Update(int id, ItemModel model);
    }
}
