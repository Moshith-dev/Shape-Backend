using Shape.Models;
using Shape.Repositories;

namespace Shape.Handlers
{
    public class ContactUsHandler
    {
        private readonly IRepository _repository;

        public ContactUsHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<ContactUs>> HandleAsync() => _repository.GetContactUsAsync();
    }
}