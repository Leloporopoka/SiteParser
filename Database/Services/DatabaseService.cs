using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.Services
{
    public class DatabaseService
    {
        private List<PersonDto> _personList { get; set; } = new List<PersonDto>();

        public DatabaseService()
        {
            _personList.Add(new PersonDto { Id = Guid.NewGuid(), Name = "Ilgam", Surname = "Abkhazov", Age = 23 });
        }

        public void Add(PersonDto person)
        {
            _personList.Add(person);
        }
        public List<PersonDto> GetList()
        {
            return _personList.ToList();
        }

        public void Delete(Guid id)
        {
            _personList.RemoveAll(p => p.Id == id);
        }
    }
}
