using AbodeLunch.Domain.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AbodeLunch.Infrastructure.Persistence.Interceptors
{
    public class PublishDomainEventInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _mediator;

        public PublishDomainEventInterceptor(IPublisher mediator)
        {
            _mediator = mediator;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult interceptionResult)
        {
            PublishDomainEvents(eventData.Context).GetAwaiter.GetResult();
            return base.SavingChanges(eventData, result);
        }
        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult)
        {
            await PublishDomainEvents(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private async Task PublishDomainEvents(DbContext? dbContext)
        {
            if (dbContext is null)
            {
                return;
            }
            //Get hold of all the various entities
            var entitiesWithDomainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(entry => entry.Entity.DomainEvents.Any())
                .Select(entry => entry.Entity)
                .ToList();
            //Get hold of all the various domain events
            var domainEvents = entitiesWithDomainEvents.SelectMany(entry => entry.DomainEvents).ToList();
            //Clear the domain events
            entitiesWithDomainEvents.ForEach(entity => entity.ClearDomainEvents());
            //Publish domain events
            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }
}