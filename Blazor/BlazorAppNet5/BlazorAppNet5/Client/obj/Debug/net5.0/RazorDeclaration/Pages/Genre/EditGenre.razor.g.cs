// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorAppNet5.Client.Pages.Genre
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using BlazorAppNet5.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using BlazorAppNet5.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using BlazorAppNet5.Client.Services.Abstractions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using BlazorAppNet5.Shared.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using BlazorAppNet5.Client.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using BlazorAppNet5.Client.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\_Imports.razor"
using Blazored.FluentValidation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Pages\Genre\EditGenre.razor"
using Model.Entities;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Genre/Edit/{id:int}")]
    public partial class EditGenre : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 13 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Pages\Genre\EditGenre.razor"
       
    [Parameter]
    public int Id { get; set; }
    private GenreDTO model = new GenreDTO();
    private bool _loading = false;
    private bool _showError = false;

    protected override async Task OnInitializedAsync()
    {
        model = await genreAPI.GetById(Id);
    }

    private async Task Edit()
    {
        _loading = true;
        var result = await genreAPI.Update(model);

        if (result is null)
        {
            navigationManager.NavigateTo("genres");
        }
        else
        {
            _showError = true;
            Console.WriteLine(result);
        }
        _loading = false;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IGenreAPI genreAPI { get; set; }
    }
}
#pragma warning restore 1591
