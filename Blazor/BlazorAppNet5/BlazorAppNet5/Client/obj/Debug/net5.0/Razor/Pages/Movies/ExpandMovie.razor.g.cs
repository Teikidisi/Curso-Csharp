#pragma checksum "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Pages\Movies\ExpandMovie.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d3229396ad80d6ce2ea1aabc9f74af6e5cbdb04"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorAppNet5.Client.Pages.Movies
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/Movie")]
    public partial class ExpandMovie : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>ExpandMovie</h3>\r\n\r\n");
            __builder.AddMarkupContent(1, "<div class=\"form-group\"><a href=\"Movie/Add\" class=\"btn btn-info\">Add Movie</a></div>\r\n");
            __builder.AddMarkupContent(2, "<div class=\"form-group\"><a href=\"Movie/Edit\" class=\"btn btn-info\">Edit Movie</a></div>");
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Pages\Movies\ExpandMovie.razor"
       
    [Parameter]
    public int Id { get; set; }
    [Parameter]
    public string Name { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
