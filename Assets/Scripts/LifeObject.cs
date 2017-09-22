using UnityEngine;

namespace Assets.Scripts
{
    public class LifeObject : MonoBehaviour {

        [SerializeField]
        private int _live;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var unit = collider2D.GetComponent<Hero>();
            if (unit)
            {
                unit.AddLives(_live);
                Destroy(gameObject);
            }
        }
    }
}
