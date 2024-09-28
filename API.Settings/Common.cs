using Courier.ViewModel.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Settings
{
    public static class Common
    {
        public static int Skip(CommonData cmncls)
        {
            int skipnumber = 0;
            if (cmncls.PageNumber > 0)
            {
                skipnumber = (cmncls.PageNumber - 1) * cmncls.PageSize;
            }
            return skipnumber;
        }
    }
}
