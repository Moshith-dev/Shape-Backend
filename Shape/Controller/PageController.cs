using Microsoft.AspNetCore.Mvc;
using Shape.Handlers;
using Shape.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shape.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly PageContentHandler _pageContentHandler;
        private readonly MenuHandler _menuHandler;
        private readonly IconsHandler _iconsHandler;
        private readonly EmployeeHandler _employeeHandler;
        private readonly ContactUsHandler _contactUsHandler;

        public PageController(
            PageContentHandler pageContentHandler,
            MenuHandler menuHandler,
            IconsHandler iconsHandler,
            EmployeeHandler employeeHandler,
            ContactUsHandler contactUsHandler)
        {
            _pageContentHandler = pageContentHandler;
            _menuHandler = menuHandler;
            _iconsHandler = iconsHandler;
            _employeeHandler = employeeHandler;
            _contactUsHandler = contactUsHandler;
        }

        [HttpGet("pagecontent")]
        [ProducesResponseType(typeof(IEnumerable<PageContent>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<IEnumerable<PageContent>>> GetPageContent()
        {
            var result = await _pageContentHandler.HandleAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No page content found.");
            }
            return Ok(result);
        }

        [HttpGet("menu")]
        [ProducesResponseType(typeof(IEnumerable<MenuTable>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<IEnumerable<MenuTable>>> GetMenu()
        {
            var result = await _menuHandler.HandleAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No menu items found.");
            }
            return Ok(result);
        }

        [HttpGet("icons")]
        [ProducesResponseType(typeof(IEnumerable<Icons>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<IEnumerable<Icons>>> GetIcons()
        {
            var result = await _iconsHandler.HandleAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No icons found.");
            }
            return Ok(result);
        }

        [HttpGet("employees")]
        [ProducesResponseType(typeof(IEnumerable<Employee>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var result = await _employeeHandler.HandleAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No employees found.");
            }
            return Ok(result);
        }

        [HttpGet("contactus")]
        [ProducesResponseType(typeof(IEnumerable<ContactUs>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<IEnumerable<ContactUs>>> GetContactUs()
        {
            var result = await _contactUsHandler.HandleAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No contact information found.");
            }
            return Ok(result);
        }
    }
}