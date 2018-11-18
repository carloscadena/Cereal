using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cereal.Models.Handlers
{
    public class EmployeeEmailRequirement : AuthorizationHandler<EmployeeEmailRequirement>, IAuthorizationRequirement
    {   
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmployeeEmailRequirement requirement)
        {
            if (!context.User.HasClaim(email => email.Type == ClaimTypes.Email))
            {
                return Task.CompletedTask;
            }

            var employeeEmail = context.User.FindFirst(email => email.Type == ClaimTypes.Email).Value;

            if (employeeEmail.Contains("@live.com"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
