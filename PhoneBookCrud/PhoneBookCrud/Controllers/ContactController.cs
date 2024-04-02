using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBookCrud.Data;
using PhoneBookCrud.Models;

namespace PhoneBookCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactController (DataContext context)
        {
            _context = context;
        }

        // __________GET_______________
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetContact()
        {
            return Ok(await _context.Contacts.ToListAsync());
        }

        // __________POST_______________
        [HttpPost]
        public async Task<ActionResult<List<Contact>>> CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return Ok(await _context.Contacts.ToListAsync());
        }

        // __________PUT_______________
        [HttpPut]
        public async Task<ActionResult<List<Contact>>> UpdateContact(Contact contact)
        {
            var dbContact = await _context.Contacts.FindAsync(contact.ContactId);
            if (dbContact == null)
            {
                return BadRequest("Contact not found.");
            }

            dbContact.TypeContactId = contact.TypeContactId;
            dbContact.Name = contact.Name;
            dbContact.PhoneNumber = contact.PhoneNumber;
            dbContact.TextComments = contact.TextComments;
            dbContact.LicenseNumber = contact.LicenseNumber;
            dbContact.LicenseStatus = contact.LicenseStatus;
            dbContact.CoverageArea = contact.CoverageArea;
            dbContact.OpeningHours = contact.OpeningHours;
            dbContact.VehiclePolicy = contact.VehiclePolicy;

            await _context.SaveChangesAsync();
            return Ok(await _context.Contacts.ToListAsync());
        }

        // __________DELETE_______________
        [HttpDelete("{ContactId}")]
        public async Task<ActionResult<List<Contact>>> DeleteUser(int ContactId)
        {
            var dbContact = await _context.Contacts.FindAsync(ContactId);
            if (dbContact == null)
            {
                return NotFound("Contact not found.");
            }

            _context.Contacts.Remove(dbContact);
            await _context.SaveChangesAsync();
            return Ok(await _context.Contacts.ToListAsync());
        }
    }
}
 