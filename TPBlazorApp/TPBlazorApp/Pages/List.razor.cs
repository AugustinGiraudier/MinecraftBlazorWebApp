using Microsoft.AspNetCore.Components;
using TPBlazorApp.Models;

namespace TPBlazorApp.Pages
{
    public partial class List
    {
        private Item[] items;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            items = await Http.GetFromJsonAsync<Item[]>($"{NavigationManager.BaseUri}fake-data.json");
        }
    }
}
