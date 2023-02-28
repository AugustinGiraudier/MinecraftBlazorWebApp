using Blazored.LocalStorage;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TPBlazorApp.Models;
using TPBlazorApp.Pages;
using TPBlazorApp.Services;

namespace TPBlazorApp.Components
{

    public partial class InventoryManager
    {

        [Inject]
        public ILogger<InventoryManager> _logger { get; set; }

        [Parameter]
        public ILocalStorageService _localStorage { get; set; }

        [Parameter]
        public IStringLocalizer<Inventory> Localizer { get; set; }

        [Parameter]
        public IDataService DataService { get; set; }


        public ObservableCollection<InventoryAction> Actions { get; set; }

        [Parameter]
        public List<Slot?> Slots { get; set; }
        public Item CurrentDragItem { get; set; }
        public InventoryItem CurrentDragSlot { get; set; }
        private List<Item> allItems { get; set; }
        private int totalItem { get; set; }


        public InventoryManager()
        {
            Actions = new ObservableCollection<InventoryAction>();
            Actions.CollectionChanged += OnActionsCollectionChanged;
        }

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
                var strItem = action.Item == null ? "Empty" : action.Item.DisplayName;
                _logger.LogInformation($"action: {action.Action}, index:{action.Index}, item:{strItem}");
            }
        }

        public void changeSlot(int index, int newCount, Item? newItem)
        {
            Slots[index].count = newCount;
            Slots[index].item = newItem;

            _localStorage.SetItemAsync("inventory", Slots);
        }
    }
}