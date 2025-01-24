using Shape.Models;
using Shape.Repositories;

namespace Shape.Handlers
{
    public class IconsHandler
    {
        private readonly IPageRepository _repository;

        public IconsHandler(IPageRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Icons>> HandleAsync() => _repository.GetIconsAsync();
    }
}