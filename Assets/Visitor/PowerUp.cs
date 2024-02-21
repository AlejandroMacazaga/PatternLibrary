using UnityEngine;

namespace Visitor
{
    [CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
    public class PowerUp : ScriptableObject, IVisitor
    {
        public int HealthBonus = 10;
        
        public void Visit(HealthComponent healthComponent)
        {
            healthComponent.AddHealth(HealthBonus);
            Debug.Log("PowerUp.Visit");
        }
    }
}