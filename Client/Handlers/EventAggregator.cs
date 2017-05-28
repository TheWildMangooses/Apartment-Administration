using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;

namespace Client.Handlers
{
    public class EventAggregator
    {
        public static void SetUser(UserModel User)
        {
            if (OnUserTransmitted != null)
                OnUserTransmitted(User);
        }
        public static Action<UserModel> OnUserTransmitted;
    }
}
