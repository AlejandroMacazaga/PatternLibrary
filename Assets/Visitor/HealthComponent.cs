using UnityEngine;

namespace Visitor
{
    public class HealthComponent : MonoBehaviour, IVisitable
    {
        public int Health = 100;
        
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            Debug.Log("HealthComponent.Accept");
        }
        
        public void AddHealth(int healthBonus)
        {
            Health += healthBonus;
            Debug.Log("HealthComponent.AddHealth");
        }
        
        
    }
}