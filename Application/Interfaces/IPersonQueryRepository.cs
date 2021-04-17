using Application.Dtos;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IPersonQueryRepository
    {
        public List<PersonDto> GetList();
    }
}
