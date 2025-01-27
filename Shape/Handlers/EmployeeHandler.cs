using Shape.Models;
using Shape.Repositories;

namespace Shape.Handlers
{
    public class EmployeeHandler
    {
        private readonly IPageRepository _repository;

        public EmployeeHandler(IPageRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Employee>> HandleAsync() => _repository.GetEmployeesAsync();
    }
}