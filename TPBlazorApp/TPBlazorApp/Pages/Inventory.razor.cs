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

        private List<Slot> slots = new List<Slot>();

        public Inventory()
        {
            for(int i = 0; i < nbSlots; i++)
            {
                slots.Add(new Slot { item=null , count=1 });
            }
        }

    }
}
