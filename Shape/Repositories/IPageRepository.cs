using Shape.Models;

namespace Shape.Repositories
{
    public interface IPageRepository
    {
        Task<IEnumerable<PageContent>> GetPageContentAsync();
        Task<IEnumerable<MenuTable>> GetMenuAsync();
        Task<IEnumerable<Icons>> GetIconsAsync();
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<IEnumerable<ContactUs>> GetContactUsAsync();
    }
}