
using Client.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Client.Pages
{
    public class MainBase : ComponentBase
    {
        [Inject]
        public NewsService NewsService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        public void GetSiteInfoAndSave()
        {
            NewsService.GetNewsAndSave();
        }
    }
}
