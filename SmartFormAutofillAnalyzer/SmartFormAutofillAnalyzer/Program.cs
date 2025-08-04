using SmartFormAutofillAnalyzer.Services;

var builder = WebApplication.CreateBuilder(args);

// Load appsettings.json (already done by default)
builder.Services.AddRazorPages();
builder.Services.AddSingleton<GeminiFormService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Enable wwwroot for CSS/JS if needed

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
