#pragma warning disable SKEXP0070

using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOllamaChatCompletion(
    modelId: "RakutenAI", 
    endpoint: new Uri("http://localhost:11434")
);
builder.Services.AddTransient((serviceProvider)=> {
    return new Kernel(serviceProvider);
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/chat", async () => {
    var kernel = app.Services.GetService<Kernel>();
    FunctionResult result = await kernel.InvokePromptAsync("test");
    return result.ToString();
});

app.Run();
