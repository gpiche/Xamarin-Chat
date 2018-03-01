using Chat.Services;
using Prism;
using Prism.Ioc;
using Chat.ViewModels;
using Chat.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Chat
{
    public partial class App : PrismApplication
    {

        public static string AppNAme { get; internal set; } = "OnionChat";

        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) {  }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<RegisterPage>();

            containerRegistry.RegisterSingleton<IAuthorizationService,AuthorizationService>();
            containerRegistry.Register<IRessourceService, RessourceService>();
            containerRegistry.RegisterSingleton<IAccountStoreService, AccoutStoreService>();



        }
    }
}
