using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserOperationClaim : Core.Entities.UserOperationClaim
    {
        public virtual OperationClaim OperationClaim { get; set; }
        public virtual User User { get; set; }

    }
}
