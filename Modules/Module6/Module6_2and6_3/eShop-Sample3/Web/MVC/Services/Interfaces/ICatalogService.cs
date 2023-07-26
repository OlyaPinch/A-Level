using MVC.ViewModels;


namespace MVC.Services.Interfaces;

public interface ICatalogService
{
    Task<ViewModels.Catalog> GetCatalogItems(int page, int take, int brand=0, int type=0);
    Task<IEnumerable<SelectListItem>> GetBrands(int page = 0, int take = int.MaxValue);
    Task<IEnumerable<SelectListItem>> GetTypes(int page = 0, int take = int.MaxValue);
    Task<CatalogItem> GetItemById(int id);
}