#pragma checksum "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\Forms\MovieAddEditForm.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16233be324d301cc05e9ddb1b793cb434b11a39b"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorAppNet5.Client.Components.Forms
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
#line 1 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\Forms\MovieAddEditForm.razor"
using Model.Entities;

#line default
#line hidden
#nullable disable
    public partial class MovieAddEditForm : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(0);
            __builder.AddAttribute(1, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 3 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\Forms\MovieAddEditForm.razor"
                 Movie

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 3 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\Forms\MovieAddEditForm.razor"
                                       OnValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(4);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(5, "\r\n    ");
                __builder2.OpenElement(6, "div");
                __builder2.AddAttribute(7, "class", "form-group");
                __builder2.AddMarkupContent(8, "<label>Title:</label>\r\n        ");
                __builder2.OpenElement(9, "div");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(10);
                __builder2.AddAttribute(11, "class", "form-control");
                __builder2.AddAttribute(12, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 8 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\Forms\MovieAddEditForm.razor"
                                                          Movie.Title

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(13, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Movie.Title = __value, Movie.Title))));
                __builder2.AddAttribute(14, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Movie.Title));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(15, "\r\n            ");
                __Blazor.BlazorAppNet5.Client.Components.Forms.MovieAddEditForm.TypeInference.CreateValidationMessage_0(__builder2, 16, 17, 
#nullable restore
#line 9 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\Forms\MovieAddEditForm.razor"
                                      () => Movie.Title

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(18, "\r\n\r\n    ");
                __builder2.OpenElement(19, "div");
                __builder2.AddAttribute(20, "class", "form-group");
                __builder2.AddMarkupContent(21, "<label>Release Date:</label>\r\n        ");
                __builder2.OpenElement(22, "div");
                __Blazor.BlazorAppNet5.Client.Components.Forms.MovieAddEditForm.TypeInference.CreateInputDate_1(__builder2, 23, 24, "form-control", 25, 
#nullable restore
#line 16 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\Forms\MovieAddEditForm.razor"
                                                          Movie.ReleaseDate

#line default
#line hidden
#nullable disable
                , 26, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Movie.ReleaseDate = __value, Movie.ReleaseDate)), 27, () => Movie.ReleaseDate);
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(28, "\r\n\r\n    ");
                __builder2.AddMarkupContent(29, "<button type=\"submit\" class=\"btn btn-success\">Save Movie</button>");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 23 "C:\Users\Rodrigo\source\repos\Teikidisi\Curso-Csharp\Blazor\BlazorAppNet5\BlazorAppNet5\Client\Components\Forms\MovieAddEditForm.razor"
       
    [Parameter]
    public MovieDTO  Movie { get; set; }
    [Parameter]
    public EventCallback OnValidSubmit { get; set; }

#line default
#line hidden
#nullable disable
    }
}
namespace __Blazor.BlazorAppNet5.Client.Components.Forms.MovieAddEditForm
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateInputDate_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputDate<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
