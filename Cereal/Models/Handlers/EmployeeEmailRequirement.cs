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
        /// <summary>
        ///handler to process email claim. Looks at email and if email contains @live.com, email requirement is successful
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns>task completed</returns>
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
