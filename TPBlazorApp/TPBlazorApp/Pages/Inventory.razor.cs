using Blazored.Modal;
using Blazored.Modal.Services;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using TPBlazorApp.Modals;
using TPBlazorApp.Models;
using TPBlazorApp.Services;

namespace TPBlazorApp.Pages
{
    public partial class Inventory
    {

        private List<Item> items;

        private int totalItem;

        [Inject]
        public IDataService DataService { get; set; }

        private async Task OnReadData(DataGridReadDataEventArgs<Item> e)
        {
            if (e.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            if (!e.CancellationToken.IsCancellationRequested)
            {
                items = await DataService.List(e.Page, e.PageSize);
                totalItem = await DataService.Count();
            }
        }
    }
}
