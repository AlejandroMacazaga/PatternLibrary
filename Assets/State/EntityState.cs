using Command;

namespace State
{
    public abstract class EntityState : IState
    {
        protected readonly IEntity Entity;
        
        protected EntityState(IEntity entity)
        {
            this.Entity = entity;
        }

        public virtual void OnEnter()
        {
            
        }

        public virtual void OnExit()
        {
            
        }

        public virtual void OnUpdate()
        {
            
        }

        public virtual void OnFixedUpdate()
        {
            
        }
        
        public static T Create<T>(IEntity entity) where T : EntityState
        {
            return (T)System.Activator.CreateInstance(typeof(T), entity);
        }
    }
}