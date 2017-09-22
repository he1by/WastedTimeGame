using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour {

        private GameObject _parent;
        public GameObject Parent { set { _parent = value; }get { return _parent; } }
        private float _speed = 10.0f;
        private SpriteRenderer _sprite;
        private Vector3 _direction;
        public Vector3 Direction { set { _direction = value; } }
    
        private void Start()
        {
            Destroy(gameObject, 2F);
        }
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            Unit unit = collider2D.GetComponent<Unit>();
            if(unit && unit.gameObject != _parent)
            {
                Destroy(gameObject);
            }
        }
        private void Update() 
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
            transform.Rotate(new Vector3(0.0f, 0.0f, -2.0f));
        }
    }
}
