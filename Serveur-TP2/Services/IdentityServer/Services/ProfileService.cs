﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace IdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IAuthRepository _repository;

        public ProfileService(IAuthRepository rep)
        {
            this._repository = rep;
        }


        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var subjectId = context.Subject.GetSubjectId();
                var user = _repository.GetUserById(subjectId);

                var claims = new List<Claim>()
                {
                    new Claim(JwtClaimTypes.Subject, user.Id.ToString())
                    //add as many claims as you want!new Claim(JwtClaimTypes.Email, user.Email),new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean)
                };

                context.IssuedClaims = claims;
                return Task.FromResult(0);
            }
            catch (Exception e)
            {
                return Task.FromResult(e);
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var user = _repository.GetUserById(context.Subject.GetSubjectId());
            context.IsActive = (user != null) && user.Active;
            return Task.FromResult(0);
        }
    }
}
