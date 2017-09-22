using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour {
        [SerializeField]
        private readonly float _speed = 2.0F;
        [SerializeField]
        private Transform _target;

        private void Awake()
        {

            if (!_target) _target = FindObjectOfType<Hero>().transform;
        }
        private void Update()
        {
            Vector3 position = _target.position;
            position.z = -10;
            transform.position = Vector3.Lerp(transform.position,position,_speed * Time.deltaTime);
        }
    }
}
