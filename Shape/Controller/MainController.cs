using Microsoft.AspNetCore.Mvc;
using Shape.Handlers;
using Shape.Models;

namespace Shape.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly PageContentHandler _pageContentHandler;
        private readonly MenuHandler _menuHandler;
        private readonly IconsHandler _iconsHandler;
        private readonly EmployeeHandler _employeeHandler;
        private readonly ContactUsHandler _contactUsHandler;
        public MainController(PageContentHandler pageContentHandler, MenuHandler menuHandler, IconsHandler iconsHandler, EmployeeHandler employeeHandler, ContactUsHandler contactUsHandler)
        {
            _pageContentHandler = pageContentHandler;
            _menuHandler = menuHandler;
            _iconsHandler = iconsHandler;
            _employeeHandler = employeeHandler;
            _contactUsHandler = contactUsHandler;
        }
        [HttpGet("pagecontent")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<PageContent>> GetPageContent() => await _pageContentHandler.HandleAsync();
        [HttpGet("menu")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<MenuTable>> GetMenu() => await _menuHandler.HandleAsync();
        [HttpGet("icons")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<Icons>> GetIcons() => await _iconsHandler.HandleAsync();
        [HttpGet("employees")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<Employee>> GetEmployees() => await _employeeHandler.HandleAsync();
        [HttpGet("contactus")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<ContactUs>> GetContactUs() => await _contactUsHandler.HandleAsync();
    }
}