using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class MoveableMonster : Monster
    {
        [SerializeField]
        private float _speed = 2.2F;

        private Vector3 _direction;
        private SpriteRenderer _sprite;

        protected override void Awake()
        {
            _sprite = GetComponentInChildren<SpriteRenderer>();
        
        }

        protected override void Update()
        {
            Move();
        }

        protected override void Start()
        {
            _direction = -transform.right;
        }
  
        private void Move()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * _direction.x*0.7F , 0.1F);
            Collider2D[] collidersGround = Physics2D.OverlapCircleAll(transform.position - transform.up*0.5F + transform.right * _direction.x, 0.2F);
            if ((colliders.Length > 0 || collidersGround.Length == 0) 
                    && colliders.All(x => !x.GetComponent<Hero>() && !x.GetComponent<Bullet>()))
            _direction *= -1.0F;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
            _sprite.flipX = _direction.x < 0.0f;
        }
    }
}
