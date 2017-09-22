using UnityEngine;

namespace Assets.Scripts
{
    public class Saw : MonoBehaviour {

        private SpriteRenderer _sprite;
        private void OnTriggerEnter2D(Collider2D collider)
        {
            Unit unit = collider.GetComponent<Unit>();
            if (unit && unit is Hero)
            {
                unit.ReceiveDamage();
            }
        }
        private void Awake()
        {
            _sprite = GetComponentInChildren<SpriteRenderer>();
        }
        private void Update()
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, -4.0f));
        }
    }
}
