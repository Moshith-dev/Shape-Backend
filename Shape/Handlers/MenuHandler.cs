using Shape.Models;
using Shape.Repositories;

namespace Shape.Handlers
{
    public class MenuHandler
    {
        private readonly IPageRepository _repository;

        public MenuHandler(IPageRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<MenuTable>> HandleAsync() => _repository.GetMenuAsync();
    }
}