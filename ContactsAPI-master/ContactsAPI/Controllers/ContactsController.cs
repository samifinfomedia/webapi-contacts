using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsAPI.Models;
using ContactsAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        public IContactsRepository ContactRepo { get; set; }
        public ContactsController(IContactsRepository _repo)
        {
            ContactRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<Contacts> GetAll()
        {
            return ContactRepo.GetAll();
        }

        [HttpGet("{id}", Name ="GetContacts")]
        public IActionResult GetById(string id)
        {
            var item = ContactRepo.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create(Contacts item)
        {
            if(item == null)
            {
                return BadRequest();
            }
            ContactRepo.Add(item);
            return CreatedAtRoute("GetContacts", new { Controller = "Contacts", id = item.MobilePhone }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = ContactRepo.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            ContactRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ContactRepo.Remove(id);
        }
    }
}