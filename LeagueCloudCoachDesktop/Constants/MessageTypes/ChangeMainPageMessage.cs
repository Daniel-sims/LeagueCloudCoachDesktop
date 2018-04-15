using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace LeagueCloudCoachDesktop.Constants.MessageTypes
{
    public class ChangeMainPageMessage
    {
        public ChangeMainPageMessage(ViewModelBase newPage)
        {
            NewPage = newPage;
        }

        public ViewModelBase NewPage { get; }
    }
}
