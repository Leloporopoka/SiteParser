using Application.Dtos;
using Application.Interfaces;
using Database.Services;
using System.Collections.Generic;

namespace Database.Repositories
{
    public class PersonQueryRepository : IPersonQueryRepository
    {
        private readonly DatabaseService _database;
        public PersonQueryRepository(DatabaseService database)
        {
            _database = database;
        }
        public List<PersonDto> GetList()
        {
            return _database.GetList();
        }
    }
}
