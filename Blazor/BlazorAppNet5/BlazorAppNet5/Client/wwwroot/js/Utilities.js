function DotNetStaticMethodTest() {
    DotNet.invokeMethodAsync("BlazorAppNet5.Client", "GetCurrentCount")
        .then(result => {
            console.log("Current count from Javascript is " + result);
        });
}

function DotNetInstanceMethodTest(dotNetHelper) {
    dotNetHelper.invokeMethodAsync("IncrementCount");
}