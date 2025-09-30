using AMOS.Models.TRANSFER_ORDER.v2_1;
using AMOS.Models.TRANSFER_WORKORDER.v2_6;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMOS.Models.TRANSFER_ORDER
{
    public interface ITransferOrderOrderType
    {
        string orderNumber { get; set; }
    }
}
