using System.Threading.Tasks;

namespace Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public abstract class EntityCommand : ICommand
    {
        protected readonly IEntity entity;
        
        protected EntityCommand(IEntity entity)
        {
            this.entity = entity;
        }
        
        public abstract void Execute();
        
        public abstract void Undo();
        
        public static T Create<T>(IEntity entity) where T : EntityCommand
        {
            return (T)System.Activator.CreateInstance(typeof(T), entity);
        }

    }
    
    public class EntityAttackCommand : EntityCommand
    {
        // We add here all the parameters that the command needs to execute
        // For example, the target of the attack
        
        public EntityAttackCommand(IEntity entity) : base(entity)
        {
        }
        
        public override async void Execute()
        {
            // make the entity do the task
        }
        
        public override void Undo()
        {
            // make the entity undo the task
        }

    }
}