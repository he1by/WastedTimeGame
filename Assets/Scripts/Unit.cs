using UnityEngine;

namespace Assets.Scripts
{
    public class Unit : MonoBehaviour {

        public virtual void ReceiveDamage()
        {
            Die();
        }

        public virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}
