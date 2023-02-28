using Microsoft.AspNetCore.Components;

namespace TPBlazorApp.Components
{
    public partial class ItemTrash
    {

        [CascadingParameter]
        public InventoryManager Parent { get; set; }

        internal void OnDrop()
        {
            Parent.CurrentDragSlot.reset();
        }
    }
}
