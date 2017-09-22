using UnityEngine;

namespace Assets.Scripts
{
    public class Monster : Unit {
        [SerializeField]
        protected int Lives = 3;

        protected virtual void Awake() { }
        protected virtual void Start() { }
        protected virtual void Update() { }


        public void OnTriggerEnter2D(Collider2D collider2D)
        {
            var unit = collider2D.GetComponent<Unit>();
            if (unit && unit is Hero)
            {
                if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.5f)
                    ReceiveDamage();
                else unit.ReceiveDamage();
            }
            var bullet = collider2D.GetComponent<Bullet>();
            if (bullet && bullet.Parent != gameObject)
            {
                ReceiveDamage();
            }
        }

        public override void ReceiveDamage()
        {
            Lives--;
            if (Lives == 0)
            {
                Die();
            }
        }
    }
}
