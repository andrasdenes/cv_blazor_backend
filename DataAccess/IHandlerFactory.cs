using DataAccess.HandlerInterfaces;

namespace DataAccess
{
    public interface IHandlerFactory
    {
        IHandler Create(Type type);
    }
}