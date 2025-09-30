using System;
using System.Collections.Generic;
using System.Text;

namespace AMOS.Models.TRANSFER_ORDER
{
    public class ITransferOrderOrderHeaderType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orderState
        {
            get
            {
                return this.orderStateField;
            }
            set
            {
                this.orderStateField = value;
            }
        }
    }
}
