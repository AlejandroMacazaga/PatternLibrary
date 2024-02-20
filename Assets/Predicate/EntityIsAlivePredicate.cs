using Command;

namespace Predicate
{
    public class EntityIsAlivePredicate : IPredicate
    {
        private readonly IEntity _entity;
        
        public EntityIsAlivePredicate(IEntity entity)
        {
            this._entity = entity;
        }
        
        public bool Evaluate()
        {
            // Evaluate if the entity is alive
            return true;
        }
    }
}