using UnityEngine;

namespace Visitor
{
    public class Pickup : MonoBehaviour 
    {
        public PowerUp PowerUp;
        
        private void OnTriggerEnter(Collider other)
        {
            var visitable = other.GetComponent<IVisitable>();
            if (visitable != null)
            {
                visitable.Accept(PowerUp);
                Destroy(gameObject);
            }
        }
    }
}