using UnityEngine;

namespace Assets.Scripts
{
    public class DieCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            Unit unit = collider2D.GetComponent<Unit>();
            if (unit)
            {
                unit.Die();
            }
        }

    }
}

