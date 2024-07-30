using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbodeLunch.Domain.Models
{
    public abstract class AggregateRoot<TId> : Entity<TId>
        where TId : notnull
    {
        protected AggregateRoot(TId id) : base(id)
        {
            
        }
#pragma warning disable CS8618 
    // protected AggregateRoot()        
    // {

    // }
#pragma warning disable CS8618 

    }
}