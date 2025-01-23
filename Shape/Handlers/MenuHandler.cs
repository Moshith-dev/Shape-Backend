using Shape.Models;
using Shape.Repositories;

namespace Shape.Handlers
{
    public class MenuHandler
    {
        private readonly IRepository _repository;

        public MenuHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<MenuTable>> HandleAsync() => _repository.GetMenuAsync();
    }
}