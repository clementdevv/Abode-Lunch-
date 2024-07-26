using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AbodeLunch.Domain.Menu;

namespace AbodeLunch.Application.Common.Interfaces.Persistence;

    public interface IMenuRepository
    {
        void Add(Menu menu);
    }
