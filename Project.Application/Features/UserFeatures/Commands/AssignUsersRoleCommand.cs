using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.UserFeatures.Commands
{
    public class AssignUsersRoleCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
    public class AssignUsersRoleCommandHandler : IRequestHandler<AssignUsersRoleCommand, string>
    {
        public Task<string> Handle(AssignUsersRoleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
