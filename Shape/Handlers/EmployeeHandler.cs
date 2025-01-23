using Shape.Models;
using Shape.Repositories;

namespace Shape.Handlers
{
    public class EmployeeHandler
    {
        private readonly IRepository _repository;

        public EmployeeHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Employee>> HandleAsync() => _repository.GetEmployeesAsync();
    }
}