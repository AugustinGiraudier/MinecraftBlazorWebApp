using TPBlazorApp.Models;

namespace TPBlazorApp.Pages
{
    public partial class Index
    {
        public List<Cake> Cakes { get; set; }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            LoadCakes();
            StateHasChanged();
            return base.OnAfterRenderAsync(firstRender);
        }

        public void LoadCakes()
        {
            Cakes = new List<Cake>
            {
                // items hidden for display purpose
                new Cake
                {
                    Id = 1,
                    Name = "Red Velvet",
                    Cost = 60
                },
            };
        }

        private Cake CakeItem = new Cake
        {
            Id = 1,
            Name = "Black Forest",
            Cost = 50
        };
    }
}
