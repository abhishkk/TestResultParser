using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Agent.Plugins.TestResultParser.Bus;
using Agent.Plugins.TestResultParser.Parser.Models;

namespace Agent.Plugins.TestResultParser.Gateway
{
    public class DataStreamGateway : IDataStreamGateway, IBus<LogData>
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public async Task ProcessDataAsync(string data)
        {
            var logData = new LogData
            {
                Message = data,
                LineNumber = ++_counter
            };

            await _broadcast.SendAsync(logData);
        }

        public void Complete()
        {
            _broadcast.Complete();
            Task.WaitAll(_subscribers.Values.Select(x => x.Completion).ToArray());
        }

        //TODO evaluate ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 2 }
        public Guid Subscribe(Action<LogData> handlerAction)
        {
            var handler = new ActionBlock<LogData>(handlerAction);

            _broadcast.LinkTo(handler, new DataflowLinkOptions { PropagateCompletion = true });

            return AddSubscription(handler);
        }

        public void Unsubscribe(Guid subscriptionId)
        {
            if (_subscribers.TryRemove(subscriptionId, out var subscription))
            {
                subscription.Complete();
            }
        }

        private Guid AddSubscription(ITargetBlock<LogData> subscription)
        {
            var subscriptionId = Guid.NewGuid();
            _subscribers.TryAdd(subscriptionId, subscription);
            return subscriptionId;
        }

        private readonly BroadcastBlock<LogData> _broadcast = new BroadcastBlock<LogData>(message => message);
        private readonly ConcurrentDictionary<Guid, ITargetBlock<LogData>> _subscribers = new ConcurrentDictionary<Guid, ITargetBlock<LogData>>();
        private int _counter;
    }
}
