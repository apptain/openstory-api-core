using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStory.Api.Sagas
{
    public interface ISaga
    {
        ISaga Instance { get; }
        MessagingFactory WorkersMessagingFactory { get; set; }
        IEnumerable<QueueDescription> Queues { get; set; }
        MessagingFactory ReceiverMessagingFactory { get; }
    }
}
