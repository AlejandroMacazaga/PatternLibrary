using Predicate;
using State;

namespace Transition
{
    public class Transition : ITransition
    {
        public IState To { get; }
        public IPredicate Condition { get; }
        
        public Transition(IState to, IPredicate condition)
        {
            this.To = to;
            this.Condition = condition;
        }
    }
}