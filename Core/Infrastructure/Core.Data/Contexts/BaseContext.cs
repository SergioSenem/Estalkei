using Microsoft.EntityFrameworkCore;

namespace Core.Data.Contexts
{
    public abstract class BaseContext : DbContext, IContext
    {
        public abstract IContext Build();
    }
}
