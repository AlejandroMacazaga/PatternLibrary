namespace Predicate
{
    public class FuncPredicate : IPredicate
    {
        private readonly System.Func<bool> _func;
        
        public FuncPredicate(System.Func<bool> func)
        {
            _func = func;
        }
        
        public bool Evaluate() => _func.Invoke();
    }
}