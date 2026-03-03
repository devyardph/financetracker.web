using Blazored.LocalStorage;
using DYS.FinanceTracker;
using DYS.FinanceTracker.Features.Accounts.Services;
using DYS.FinanceTracker.Features.Accounts.ViewModels;
using DYS.FinanceTracker.Features.Finance.ViewModels;
using DYS.FinanceTracker.Features.Test.ViewModels;
using DYS.FinanceTracker.Shared.Data;
using DYS.FinanceTracker.Shared.Extensions;
using DYS.FinanceTracker.Shared.Models;
using DYS.FinanceTracker.Shared.Services;
using DYS.FinanceTracker.Shared.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Supabase;
using Supabase.Gotrue;
using Supabase.Postgrest.Models;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMvvm();
//builder.Services.AddScopedForBaseClass<BaseService, IBaseService>(Assembly.GetExecutingAssembly());
//builder.Services.AddScopedForBaseClass<BaseViewModel>(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IBaseService, BaseService>();
builder.Services.AddTransient<BaseViewModel>();
builder.Services.AddTransient<AccountViewModel>();
builder.Services.AddTransient<TrackerViewModel>();
builder.Services.AddTransient<MenuViewModel>();

builder.Services.AddOtherServices();
builder.Services.AddBlazoredLocalStorage();

// Access IConfiguration
var config = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(config);
builder.Services.AddSingleton(provider =>
{
    var url = config["Supabase:Project"] ?? string.Empty;
    var key = config["Supabase:Key"] ?? string.Empty;
    var options = new SupabaseOptions { AutoRefreshToken = true, AutoConnectRealtime = true };
    return new Supabase.Client(url, key, options);
});
Console.WriteLine(config["Supabase:Project"]);
Console.WriteLine(config["Supabase:Key"]);
builder.Services.AddScoped<ISupabaseService<Transaction>, SupabaseService<Transaction>>();
//HZOsia6NAHOmeGqv db


builder.Services.AddScoped<ISupabaseAuthProvider,SupabaseAuthProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, SupabaseAuthProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();


await builder.Build().RunAsync();

