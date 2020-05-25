using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RajProj.Data
{
    public class DbUpdatedEvent : PubSubEvent<string>
    {

    }
    public class MaxDailyAmountBreachedEvent : PubSubEvent<int>
    {

    }
}
