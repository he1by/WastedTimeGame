using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShootableMonster : Monster
    {

        [SerializeField]
        protected float Rate = 2.0F;
        [SerializeField]
        private readonly float _speed = 1.6F;

        private Vector3 _direction;
        private Bullet _bullet;
        private SpriteRenderer _sprite;

        protected override void Awake()
        {
            _sprite = GetComponentInChildren<SpriteRenderer>();
            _bullet = Resources.Load<Bullet>("BulletBone");
        }

        protected override void Update()
        {
            Move();
        }

        protected override void Start()
        {
            _direction = -transform.right;
            InvokeRepeating("Shoot", Rate, Rate);
        }

        private void Move()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * _direction.x * 0.7F, 0.1F);
            Collider2D[] collidersGround = Physics2D.OverlapCircleAll(transform.position - transform.up * 0.5F + transform.right * _direction.x, 0.2F);
            if ((colliders.Length > 0 || collidersGround.Length == 0) && colliders.All(x => !x.GetComponent<Hero>() && !x.GetComponent<Bullet>()))
                _direction *= -1.0F;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
            _sprite.flipX = _direction.x < 0.0f;

        }

        private void Shoot()
        {
            Vector3 position = transform.position;
            position.y += 0.8F;
            Bullet newBullet = Instantiate(_bullet, position, transform.rotation) as Bullet;
            newBullet.Parent = gameObject;
            newBullet.Direction = _direction;
        }
    }
}
