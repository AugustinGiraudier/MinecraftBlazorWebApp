using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using TPBlazorApp.Models;
using TPBlazorApp.Services;

namespace TPBlazorApp.Pages
{
    public partial class Inventory
    {

        [Inject]
        public IDataService DataService { get; set; }

    }
}
