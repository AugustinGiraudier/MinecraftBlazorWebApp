using Blazored.LocalStorage;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using TPBlazorApp.Components;
using TPBlazorApp.Models;
using TPBlazorApp.Services;

namespace TPBlazorApp.Pages
{
    public partial class Inventory
    {

        [Inject]
        public IDataService DataService { get; set; }
        [Inject]
        public IStringLocalizer<Inventory> Localizer { get; set; }
        [Inject]
        private ILocalStorageService _localStorage { get; set; }

        private List<Slot?> Slots = new List<Slot?>();

        public Inventory()
        {
            for (int i = 0; i < 32; i++)
            {
                Slots.Add(new Slot { item = null, count = 1 });
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var testSave = await _localStorage.GetItemAsync<List<Slot?>>("inventory");
            if (testSave != null)
                Slots = testSave;
            StateHasChanged();
        }

    }
}
