using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OperationClaim : Core.Entities.OperationClaim
    {
        public virtual List<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
