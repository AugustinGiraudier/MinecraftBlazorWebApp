using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TPBlazorApp.Models;
using TPBlazorApp.Services;

namespace TPBlazorApp.Components
{

    public partial class InventoryManager
    {
        //public Item CurrentDragItem { get; set; }

        public InventoryManager()
        {
            Actions = new ObservableCollection<InventoryAction>();
            Actions.CollectionChanged += OnActionsCollectionChanged;
        }

        public ObservableCollection<InventoryAction> Actions { get; set; }

        [Parameter]
        public List<Item?> Items { get; set; }

        public Item CurrentDragItem { get; set; }
        private List<Item> allItems { get; set; }

        private int totalItem { get; set; }

        [Parameter]
        public IDataService DataService { get; set; }

        private async Task OnReadData(DataGridReadDataEventArgs<Item> e)
        {
            if (e.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            if (!e.CancellationToken.IsCancellationRequested)
            {
                allItems = await DataService.List(e.Page, e.PageSize);
                totalItem = await DataService.Count();
            }
        }

        private void OnActionsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            // log it
            foreach(var item in e.NewItems)
            {
                var action = (InventoryAction)item;
                if(action.Action == "Drop")
                    Console.WriteLine($"index:{action.Index}, item:{action.Item}");
            }
        }
    }
}