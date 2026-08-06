using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Order.Application.Features.Orders.Commands.CheckoutOrder;

namespace Order.Api.EventBusConsumer
{
    public class BasketOrderingConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<BasketOrderingConsumer> _logger;

        public BasketOrderingConsumer(
            IMediator mediator,
            IMapper mapper,
            ILogger<BasketOrderingConsumer> logger
            )
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
              _logger.BeginScope("consuming basket checkout event for {correlationid}", context.Message.CorrelationId);
            var cmd = _mapper.Map<CheckoutOrderCommand>(context.Message);
            var result = await _mediator.Send(cmd);
            _logger.LogInformation("Basket checkout event completed !!");
        }
    }
}
