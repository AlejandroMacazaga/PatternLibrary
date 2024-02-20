using Predicate;
using State;

namespace Transition
{
    public interface ITransition
    {
        IState To { get; }
        IPredicate Condition { get; }
    }
}
