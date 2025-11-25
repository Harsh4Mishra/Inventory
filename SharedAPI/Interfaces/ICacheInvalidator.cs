using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Interfaces
{
    public interface ICacheInvalidator
    {
        Task InvalidateAsync();
    }
}
