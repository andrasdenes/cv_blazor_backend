using DataAccess.Handlers;

namespace DataAccess
{
    public interface IHandlerFactory
    {
        IHandler Create(Type type);
    }
}