using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using TPBlazorApp.Models;
using TPBlazorApp.Services;

namespace TPBlazorApp.Pages
{
    public partial class Inventory
    {

        private int nbSlots = 32;

        [Inject]
        public IDataService DataService { get; set; }

        private List<Item> items = new List<Item>();

        public Inventory()
        {
            for(int i = 0; i < nbSlots; i++)
            {
                items.Add(null);
            }
        }

    }
}
