using Infrastructure.Messaging.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Messaging.Contract
{
    public abstract class  EventBusHandler<TEvent> : IEventHandler
    where TEvent : Event
    {
        public Task Handle(object @event)
        {
            return this.Handle((TEvent)@event );
        }

        public abstract Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
        Task Handle(object @event);

    }


}
