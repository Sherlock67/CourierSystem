using Courier.ViewModel.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.ViewModel.ViewModels.Customers
{
    public class CustomerData : Paging
    {
        public string Search { get; set; } = "";
        public int roleId { get; set; } = 0;
    }
}
