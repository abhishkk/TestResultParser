using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Agent.Plugins.TestResultParser.Bus;
using Agent.Plugins.TestResultParser.Parser;

namespace Agent.Plugins.TestResultParser.Gateway
{
    public class DataStreamGateway : IDataStreamGateway, IBus<string>
    {
        public void Initialize()
        {
            var t = new GenericTestResultParser();
            Subscribe(t.ParseData);
          
            throw new NotImplementedException();
        }

        public Task ProcessDataAsync(Stream stream)
        {
            //TODO string or stream?
            return _broadcast.SendAsync("");
        }


        //TODO evaluate ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 2 }
        public Guid Subscribe(Action<string> handlerAction)
        {
            var handler = new ActionBlock<string>(handlerAction);

            var subscription = _broadcast.LinkTo(handler, new DataflowLinkOptions { PropagateCompletion = true });

            return AddSubscription(subscription);
        }

        public void Unsubscribe(Guid subscriptionId)
        {
            if (_subscribers.TryRemove(subscriptionId, out var subscription))
            {
                subscription.Dispose();
            }
        }

        private Guid AddSubscription(IDisposable subscription)
        {
            var subscriptionId = Guid.NewGuid();
            _subscribers.TryAdd(subscriptionId, subscription);
            return subscriptionId;
        }

        private readonly BroadcastBlock<string> _broadcast = new BroadcastBlock<string>(message => message);
        private readonly ConcurrentDictionary<Guid, IDisposable> _subscribers = new ConcurrentDictionary<Guid, IDisposable>();
    }
}
