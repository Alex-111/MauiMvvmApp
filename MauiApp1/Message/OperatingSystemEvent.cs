using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Message
{
    public class OperatingSystemEvent : ValueChangedMessage<OperatingSystemEventType>
    {
        public OperatingSystemEvent(OperatingSystemEventType value) : base(value)
        {
        }
        
        
    }
}
 