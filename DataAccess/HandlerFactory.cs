using DataAccess.Handlers;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace DataAccess
{
    public class HandlerFactory : IHandlerFactory
    {
        private readonly DbContext Context;

        public HandlerFactory(DbContext context)
        {
            this.Context = context;
        }

        public IHandler Create(Type type)
        {
            object[] args = new object[] { Context };
            var handler = Activator.CreateInstance(type, args);
            
            return handler as IHandler; 
        }
    }
}
