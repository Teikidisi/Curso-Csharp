#pragma checksum "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\MovieListComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7539985ca75f28d724b8428629801ed9e9ba2c10"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorAppNet5.Client.Components
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
#line 2 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\MovieListComponent.razor"
using Model.Entities;

#line default
#line hidden
#nullable disable
    public partial class MovieListComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<p>Nothing</p>\r\n\r\n");
            __builder.OpenElement(1, "input");
            __builder.AddAttribute(2, "type", "checkbox");
            __builder.AddAttribute(3, "checked", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 6 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\MovieListComponent.razor"
                              _show

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _show = __value, _show));
            __builder.SetUpdatesAttributeName("checked");
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "style", "display: flex; flex-wrap: wrap; align-items: center;");
            __Blazor.BlazorAppNet5.Client.Components.MovieListComponent.TypeInference.CreateGenericListComponent_0(__builder, 8, 9, 
#nullable restore
#line 8 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\MovieListComponent.razor"
                                       Movies

#line default
#line hidden
#nullable disable
            , 10, (movie) => (__builder2) => {
                __builder2.OpenComponent<BlazorAppNet5.Client.Components.MovieSingleComponent>(11);
                __builder2.AddAttribute(12, "Movie", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Model.Entities.Movie>(
#nullable restore
#line 11 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\MovieListComponent.razor"
                                         movie

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(13, "ShowButton", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 11 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\MovieListComponent.razor"
                                                            _show

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(14, "DeleteMovie", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Model.Entities.Movie>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Model.Entities.Movie>(this, 
#nullable restore
#line 11 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\MovieListComponent.razor"
                                                                                DeleteMovie

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
            }
            );
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 25 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\MovieListComponent.razor"
      
    [Parameter]
    public List<Movie> Movies { get; set; }

    private bool _show = false;

    private async Task DeleteMovie(Movie movie)
    {
        bool confirm = await js.InvokeAsync<bool>("confirm",$"Do you want to remove the movie {movie.Title}");
        if (confirm)
        {
            Movies.Remove(movie);
            //Console.WriteLine($"Deleting Movie... {movie.Title}");s
            await js.InvokeVoidAsync("console.log", $"Deleting movie {movie.Title}");
        }
    }

    //protected override void OnInitialized() //Cuando se inicializa la pagina 
    //{
    //    Console.WriteLine($"OnInitialized - Movies count = {Movies.Count}");
    //}

    //protected override void OnParametersSet() //Cuando se setean parametros en la pagina
    //{
    //    Console.WriteLine($"OnParametersSet - Movies count = {Movies.Count}");
    //}

    //protected override void OnAfterRender(bool firstRender) //el bool marca si se renderizó por primera vez para ya no ejecutarse
    //{
    //    Console.WriteLine($"OnAfterRender - FirstRender = {firstRender}"); //cuando clicas el checkbox empieza a dar false porque vuelve a renderizar lo mismo
    //}

    //protected override bool ShouldRender() //muestra si se debe renderizar la pagina, si es  false nunca se va a renderizar
    //                                       //no importa los cambios que se hagan
    //{
    //    Console.WriteLine("Should Render");
    //    return base.ShouldRender();
    //}

    //puedes crear funciones custom para ejecutar cuando ocurran cosas en el render html

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
    }
}
namespace __Blazor.BlazorAppNet5.Client.Components.MovieListComponent
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateGenericListComponent_0<Titem>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.Generic.List<Titem> __arg0, int __seq1, global::Microsoft.AspNetCore.Components.RenderFragment<Titem> __arg1)
        {
        __builder.OpenComponent<global::BlazorAppNet5.Client.Components.GenericListComponent<Titem>>(seq);
        __builder.AddAttribute(__seq0, "GenericList", __arg0);
        __builder.AddAttribute(__seq1, "ListAny", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
