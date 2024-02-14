using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.Home;
public partial class Home
{
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] ProductService_SQL categoryService_SQL { get; set; }

    private List<Category> Categories { get; set; } = new List<Category>();

    protected override async Task OnInitializedAsync()
    {
        var _category = await categoryService_SQL.GetCategoryList(applicationDbContext);
        if (_category != null && _category.Count > 0)
        {
            Categories = _category;
        }
        await InvokeAsync(StateHasChanged);
    }
}