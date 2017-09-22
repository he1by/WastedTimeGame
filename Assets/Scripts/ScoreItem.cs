using UnityEngine;

namespace Assets.Scripts
{
    public class ScoreItem : MonoBehaviour {

        [SerializeField]
        private int _point;
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            Hero unit = collider2D.GetComponent<Hero>();
            if (unit)
            {
                unit.AddPoints(_point);
                Destroy(gameObject);
            }
        }
    }
}
