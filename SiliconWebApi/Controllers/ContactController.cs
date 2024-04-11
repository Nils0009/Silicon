using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace SiliconWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(ContactService contactService) : ControllerBase
    {
        private readonly ContactService _contactService = contactService;

        #region HttpGet-GetOne
        [HttpGet("{email}")]
        public async Task<IActionResult> GetOne(string email)
        {
            try
            {
                var contact = await _contactService.GetOneContactAsync(email);
                if (contact != null) 
                {
                    return Ok(contact);
                }
                else 
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return BadRequest();
        }
        #endregion

        #region HttpGet-GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var contacts = await _contactService.GetAllContactAsync();
                if (contacts != null)
                {
                    return Ok(contacts);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return BadRequest();
        }
        #endregion

        #region HttpPost-Create
        [HttpPost]
        public async Task<IActionResult> Create(ContactReqistrationModel contactReqistrationModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var newContact = await _contactService.CreateContactServiceAsync(contactReqistrationModel);
                    if (newContact != null)
                    {
                        return Ok(newContact);
                    }
                    else 
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return BadRequest();    
        }
        #endregion
    }
}
