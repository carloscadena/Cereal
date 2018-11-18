using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Models.Handlers
{
    public class EmployeeNumRequirement : AuthorizationHandler<EmployeeNumRequirement>, IAuthorizationRequirement
    {
        int _employeeNum;

        public EmployeeNumRequirement(int employeeNum)
        {
            _employeeNum = employeeNum;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmployeeNumRequirement requirement)
        {
            
        }
    }
}
