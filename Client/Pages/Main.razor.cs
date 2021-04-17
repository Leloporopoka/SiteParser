using Application.Dtos;
using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Pages
{
    public class MainBase : ComponentBase
    {
        [Inject]
        public HttpService HttpService { get; set; }
        public List<PersonDto> Persons { get; set; } = new List<PersonDto>();
        public PersonModel Model { get; set; } = new PersonModel();
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            GetPersons();
        }
        protected async void GetPersons()
        {
            Persons = await HttpService.Take();
            StateHasChanged();
        }
        protected async void Submit()
        {
            await HttpService.Add(Model);
            GetPersons();
        }

        protected async void Delete(Guid id)
        {
            await HttpService.Delete(id);
            GetPersons();
        }

    }
}
