using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorAppNet5.Client.Pages
{
    public partial class Counter
    { //Se separa el c# y el html en dos archivos distintos para mas orden
        [Inject]
        ServicesSingleton singleton { get; set; }
        [Inject]
        ServicesTransient transient { get; set; }
        [Inject]
        IJSRuntime js { get; set; } //acceder a archivos JS

        IJSObjectReference module;

        private int currentCount = 0;
        private static int currentCountStatic = 0;

        [JSInvokable]
        public async Task IncrementCount()
        {
            module = await js.InvokeAsync<IJSObjectReference>("import", "../js/Counter.js");
            await module.InvokeVoidAsync("showAlert", "Hello World");

            currentCountStatic++;
            currentCount++;

            await js.InvokeVoidAsync("DotNetStaticMethodTest");
        }

        private async Task IncrementCountFromJavascript()
        {
            await js.InvokeVoidAsync("DotNetInstanceMethodTest", DotNetObjectReference.Create(this)); //this pasa la clase Counter
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        } 
    }
}
