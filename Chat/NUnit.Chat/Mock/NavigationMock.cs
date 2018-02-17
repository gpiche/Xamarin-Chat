using System;
using System.Threading.Tasks;
using Prism.Navigation;

namespace NUnit.Lab9.Test.Mock
{
    class NavigationMock : INavigationService
    {
        public string Name { get; private set; }
        public bool NavigateAsyncIsCalled { get; private set; }
        public bool GoBackAsyncIsCalled { get; private set; }

        public Task<bool> GoBackAsync()
        {
            GoBackAsyncIsCalled = true;
            return null;
        }

        public Task<bool> GoBackAsync(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task NavigateAsync(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task NavigateAsync(Uri uri, NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task NavigateAsync(string name)
        {
            Name = name;
            NavigateAsyncIsCalled = true;
            return null;
        }

        public Task NavigateAsync(string name, NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
