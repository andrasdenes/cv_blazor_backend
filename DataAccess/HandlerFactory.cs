using DataAccess.HandlerInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public class HandlerFactory : IHandlerFactory
    {
        private readonly DbContext Context;
        private readonly DIProvider? DiProvider;

        public HandlerFactory(DbContext context)
        {
            Context = context;
        }

        public HandlerFactory(DIProvider diProvider)
        {
            DiProvider = diProvider;
            Context = DiProvider.ServiceProvider.GetRequiredService<NoteContext>();
        }

        public IHandler Create(Type type)
        {
            object[] args = new object[] { Context };
            var handler = Activator.CreateInstance(type, args) ?? throw new NullReferenceException(message:$"Could not create isntance of type: {nameof(type)}");
            
            return handler as IHandler; 
        }
    }
}
