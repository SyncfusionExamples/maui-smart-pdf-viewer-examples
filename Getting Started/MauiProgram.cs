using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.SmartComponents.Hosting;

namespace GettingStarted
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // Configure Syncfusion core services.
            builder.ConfigureSyncfusionCore();

            // Define the Azure OpenAI API key, endpoint, and deployment name.
            string key = "your-api-key";
            Uri azureEndPoint = new Uri("https://your-resource-name.openai.azure.com/");
            string deploymentName = "your-deployment-name";

            // Create an Azure OpenAI client using the endpoint and API key.
            AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
                azureEndPoint,
                new AzureKeyCredential(key)
            );

            // Create a chat client from the specified Azure OpenAI deployment.
            IChatClient azureChatClient = azureOpenAIClient
                .GetChatClient(deploymentName)
                .AsIChatClient();

            // Register the chat client with the application services.
            builder.Services.AddChatClient(azureChatClient);

            // Configure Syncfusion AI services to enable AI-powered features.
            builder.ConfigureSyncfusionAIServices();

            return builder.Build();
        }
    }
}
