using Microsoft.AspNetCore.Components;
using TPBlazorApp.Models;

namespace TPBlazorApp.Components
{
    public partial class ItemWithImg
    {
        //[Parameter]
        //public int Index { get; set; }

        [Parameter]
        public Item Item { get; set; }

        [Parameter]
        public bool NoDrop { get; set; }


        internal void OnDragEnter()
        {
            if (NoDrop)
            {
                return;
            }
        }

        internal void OnDragLeave()
        {
            if (NoDrop)
            {
                return;
            }
        }

        internal void OnDrop()
        {
            if (NoDrop)
            {
                return;
            }

        }

        private void OnDragStart()
        {

        }
    }
}
