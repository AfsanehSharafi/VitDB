using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.ActivateUser
{
    public class ActivateUserQuery : IRequest<bool>
    {
        public string Code { get; set; }
    }

}
