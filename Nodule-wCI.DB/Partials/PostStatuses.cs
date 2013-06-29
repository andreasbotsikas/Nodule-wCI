using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodule_wCI.DB
{
    public partial class PostStatuses
    {

        public enum AvailableStatuses
        {
            JustRecieved = 1,
            Processing = 2,
            Success = 3,
            Failed = 4
        }

    }
}
