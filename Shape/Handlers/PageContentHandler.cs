using Shape.Models;
using Shape.Repositories;

namespace Shape.Handlers
{
    public class PageContentHandler
    {
        private readonly IRepository _repository;

        public PageContentHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<PageContent>> HandleAsync() => _repository.GetPageContentAsync();
    }
}