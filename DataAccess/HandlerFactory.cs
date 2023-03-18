using DataAccess.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

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
            var handler = Activator.CreateInstance(type, args);
            
            return handler as IHandler; 
        }
    }
}
