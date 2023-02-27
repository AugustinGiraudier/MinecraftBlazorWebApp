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
        public InventoryItemType type { get; set; } = InventoryItemType.SIMPLE;

        [CascadingParameter]
        public InventoryManager Parent { get; set; }

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

            //this.Item = Parent.CurrentDragItem;
            Parent.Items[this.Index] = this.Item;

            Parent.Actions.Add(new InventoryAction { Action = "Drop", Item = this.Item, Index = this.Index });

            // Check recipe
            //Parent.CheckRecipe();
        }

        private void OnDragStart()
        {
            //Parent.CurrentDragItem = this.Item;

            Parent.Actions.Add(new InventoryAction { Action = "Drag Start", Item = this.Item, Index = this.Index });
        }
    }
}
