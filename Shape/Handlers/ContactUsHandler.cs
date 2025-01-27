using Shape.Models;
using Shape.Repositories;

namespace Shape.Handlers
{
    public class ContactUsHandler
    {
        private readonly IPageRepository _repository;

        public ContactUsHandler(IPageRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<ContactUs>> HandleAsync() => _repository.GetContactUsAsync();
    }
}