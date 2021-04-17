using Application.Dtos;
using System;

namespace Application.Interfaces
{
    public interface IPersonCommandRepository
    {
        public void Add(PersonDto person);
        public void Delete(Guid id);
    }
}
