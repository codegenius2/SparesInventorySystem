﻿using Microsoft.AspNetCore.Components.WebView.Maui;
using BikeSparesInventorySystem.Data;
using BikeSparesInventorySystem.Data.Providers;
using BikeSparesInventorySystem.Data.Models;
using BikeSparesInventorySystem.Data.Repositories;
using BikeSparesInventorySystem.Data.Services;

namespace BikeSparesInventorySystem;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		
		builder.Services.AddCsvFileProvider();
/*		builder.Services.AddExcelFileProvider();
		builder.Services.AddJsonFileProvider();*/

		builder.Services.AddRepository();

		builder.Services.AddAuth();

		return builder.Build();
	}
}
