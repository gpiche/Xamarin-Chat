
using System;
using System.Threading.Tasks;
using Prism.Navigation;

namespace TP2.UnitTests.Mock
{
    class NavigationMock : INavigationService
    {
        public string Name {get; private set; }
        public bool IsCalled { get; private set; } 
       

        public Task NavigateAsync(Uri uri, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true)
        {
            throw new NotImplementedException();
        }

        public Task NavigateAsync(string name, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true)
        {
            IsCalled = true;
            Name = name;

            return null;
        }

        public Task<bool> GoBackAsync(NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true)
        {
            throw new NotImplementedException();
        }
    }
}
