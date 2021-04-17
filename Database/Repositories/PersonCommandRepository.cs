using Application.Dtos;
using Application.Interfaces;
using Database.Services;
using System;

namespace Database.Repositories
{
    public class PersonCommandRepository : IPersonCommandRepository
    {
        private readonly DatabaseService _database;
        public PersonCommandRepository(DatabaseService database)
        {
            _database = database;
        }

        public void Add(PersonDto person)
        {
            _database.Add(person);
        }

        public void Delete(Guid id)
        {
            _database.Delete(id);
        }
    }
}
