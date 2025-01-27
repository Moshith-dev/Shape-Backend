using Shape.Models;
using Shape.Repositories;

namespace Shape.Handlers
{
    public class PageContentHandler
    {
        private readonly IPageRepository _repository;

        public PageContentHandler(IPageRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<PageContent>> HandleAsync() => _repository.GetPageContentAsync();
    }
}