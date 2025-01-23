using Shape.Models;
using Shape.Repositories;

namespace Shape.Handlers
{
    public class IconsHandler
    {
        private readonly IRepository _repository;

        public IconsHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Icons>> HandleAsync() => _repository.GetIconsAsync();
    }
}