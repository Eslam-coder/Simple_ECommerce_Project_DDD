using _0___SharedKernel.Domain.Events;
using _0___SharedKernel.Domain.UnitOfWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace _2___Infrastructure.SharedKernel.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;

        public UnitOfWork(
            ECommerceDbContext context,
            IServiceProvider serviceProvider,
            IMediator mediator) 
        {
            _context = context;
            _serviceProvider = serviceProvider;
            _mediator = mediator;
        }

        public async Task<int> CompleteAsync()
        {
            await DispatchDomainEvents();
            var result = await _context.SaveChangesAsync();
            return result;
        }

        private async Task DispatchDomainEvents()
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UnitOfWork>>();
            var domainEvents = _context.ChangeTracker.Entries<IHaveDomainEvents>()
                .SelectMany(entry =>
                {
                    var result = entry.Entity.DomainEvents.ToArray();
                    entry.Entity.ClearDomainEvents();
                    return result;
                }).ToArray();
            foreach (var domainEvent in domainEvents)
            {
                try
                {
                    await _mediator.Publish(domainEvent);
                }
                catch (Exception exception)
                {
                    logger.LogError(exception, "Failed to dispatch domain event.");
                }
            }
        }

        public bool HasChanges()
        {
            var result = _context.ChangeTracker.HasChanges();
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
