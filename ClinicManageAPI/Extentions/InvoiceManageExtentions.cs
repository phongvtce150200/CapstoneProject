using BusinessObject.Entity;
using System;

namespace ClinicManageAPI.Extentions
{
    public static class InvoiceManageExtentions
    {
        public static Invoice PostInvoice(this Invoice invoice, string user)
        {
            invoice.CreatedDate = DateTime.UtcNow;
            invoice.IsDelete = false;
            invoice.CreatedBy = user;
            return invoice;
        }
    }
}
