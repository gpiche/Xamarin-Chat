using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace IdentityServer.Services
{
    public class RessourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IAuthRepository _repository;

        public RessourceOwnerPasswordValidator(IAuthRepository repository)
        {
            _repository = repository;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if ( _repository.ValidatePassword(context.UserName, context.Password))
            {
                context.Result = new GrantValidationResult(_repository.GetUserByUsername(context.UserName).Id, "password", null, "local", null);
                return Task.FromResult(context.Result);
            }
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The username and password do not match", null);
            return Task.FromResult(context.Result);
        }
    }
}
