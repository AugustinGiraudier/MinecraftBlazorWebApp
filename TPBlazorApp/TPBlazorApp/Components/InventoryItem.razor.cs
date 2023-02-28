using Microsoft.AspNetCore.Components;
using TPBlazorApp.Models;

namespace TPBlazorApp.Components
{

    public enum InventoryItemType
    {
        SIMPLE,
        WITH_IMAGE
    }

    public partial class InventoryItem
    {
        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public Item Item { get; set; }

        [Parameter]
        public bool NoDrop { get; set; }

        [Parameter]
        public int Count { get; set; } = 1;
        
        [Parameter]
        public InventoryItemType type { get; set; } = InventoryItemType.SIMPLE;

        [CascadingParameter]
        public InventoryManager Parent { get; set; }

        public void reset()
        {
            if (!NoDrop)
            {
                Item = null;
                Count = 1;
                StateHasChanged();
                Parent.changeSlot(Index, Count, Item);
            }
        }

        internal void OnDragEnter()
        {
            if (NoDrop)
            {
                return;
            }

            Parent.Actions.Add(new InventoryAction { Action = "Drag Enter", Item = this.Item, Index = this.Index });
        }

        internal void OnDragLeave()
        {
            if (NoDrop)
            {
                return;
            }

            Parent.Actions.Add(new InventoryAction { Action = "Drag Leave", Item = this.Item, Index = this.Index });
        }

        internal void OnDrop()
        {
            if (NoDrop)
            {
                return;
            }

            if(this.Item == null || this.Item.Equals(Parent.CurrentDragItem))
            {
                // set new values
                if(Item == null)
                    this.Count = Parent.CurrentDragSlot.Count;
                else 
                    this.Count += Parent.CurrentDragSlot.Count;
                this.Item = Parent.CurrentDragItem;
                StateHasChanged();  // notify view
                Parent.CurrentDragSlot.reset(); // reset last area
                Parent.changeSlot(Index, Count, Item); // notify and save change
            }

            // notify action to be logged
            Parent.Actions.Add(new InventoryAction { Action = "Drop", Item = this.Item, Index = this.Index });

        }

        private void OnDragStart()
        {
            // keep current moving item
            Parent.CurrentDragItem = this.Item;
            Parent.CurrentDragSlot = this;

            // notify action to be logged
            Parent.Actions.Add(new InventoryAction { Action = "Drag Start", Item = this.Item, Index = this.Index });
        }
    }
}
