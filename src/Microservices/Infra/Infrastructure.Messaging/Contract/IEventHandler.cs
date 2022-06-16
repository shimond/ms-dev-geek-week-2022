using Infrastructure.Messaging.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Messaging.Contract
{
    public interface IEventHandler<TEvent> : IEventHandler
    where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
        Task Handle(object @event);

    }


}
