﻿using Microsoft.AspNetCore.Components;
using TPBlazorApp.Components;
using TPBlazorApp.Models;
using TPBlazorApp.Services;

namespace TPBlazorApp.Pages
{
    public partial class Index
    {
        [Inject]
        public IDataService DataService { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();

        private List<CraftingRecipe> Recipes { get; set; } = new List<CraftingRecipe>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRenderAsync(firstRender);

            if (!firstRender)
            {
                return;
            }

            Items = await DataService.List(0, await DataService.Count());
            Recipes = await DataService.GetRecipes();

            StateHasChanged();
        }
    }
}
