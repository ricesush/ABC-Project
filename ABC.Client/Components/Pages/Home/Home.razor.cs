using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.Home;
public partial class Home
{
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    [Inject] CategoryService_SQL categoryService_SQL { get; set; }

    private List<Category> Categories { get; set; } = [];
    private Category SelectedCategory { get; set; }

	protected override async Task OnInitializedAsync()
    {
        var _category = await categoryService_SQL.GetCategoryList(applicationDbContext);
        if (_category != null && _category.Count > 0)
        {
            Categories = _category;
        }
        await InvokeAsync(StateHasChanged);
    }

    private void FilterProducts(Category category)
    {
        SelectedCategory = category;
        NavigationManager.NavigateTo($"/shop/{SelectedCategory.Id}");
    }
}