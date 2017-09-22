using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Hero : Unit {

        public new Rigidbody2D Rigibody;

        [SerializeField]
        private static int _lives = 5 ;

        [SerializeField]
        private float _speed = 3.0f;

        [SerializeField]
        private float _jumpForce = 5.0f;

        [SerializeField]
        private static int _points;
        private Animator _animator;
        private SpriteRenderer _sprite;
        private bool _isGrounded=false;
        private Bullet _bullet;
        private float _size = 4.0f;
        private float _side = 0;

        private void OnGUI()
        {
            GUI.Label(new Rect(0, 10*_size, 180*_size, 30*_size), "Points:"+_points);
            GUI.Label(new Rect(0, 40*_size, 180*_size, 30*_size), "Life:"+_lives);
            if (GUI.Button(new Rect(0, 200*_size, 60*_size, 60*_size), "Left"))
            {
                _side = -1;
            }
            if (GUI.Button(new Rect(160*_size, 200*_size, 60*_size, 60*_size), "Right"))
            {
                _side = 1;
            }
            if (GUI.Button(new Rect(80*_size, 200*_size, 60*_size, 60*_size), "Stop"))
            {
                _side = 0;
            }
            if (GUI.Button(new Rect(350*_size, 200*_size, 60*_size, 60*_size), "Jump"))
            {
                if (_isGrounded)
                {
                    Jump();
                }
            }

        }

        private void Awake()
        {   
            Rigibody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _sprite = GetComponentInChildren<SpriteRenderer>();
            _bullet = Resources.Load<Bullet>("Bullet");
            if (LoadPrefs.Lifes != null)
            {
                if (int.Parse(LoadPrefs.Lifes) != 0)
                {
                    _lives = int.Parse(LoadPrefs.Lifes);
                    _points = int.Parse(LoadPrefs.Score);
                }
            }
            else _lives = 5;
        }

        private void FixedUpdate()
        {
            CheckGround();
        }
        private void Update()
        {
            LoadPrefs.Score = _points.ToString();
            LoadPrefs.Lifes = _lives.ToString();
            Run();
            if (Input.GetButtonDown("Fire1"))
                Shoot();
        }

        private void Run()
        {
            Vector3 derection = transform.right * _side;
            transform.position = Vector3.MoveTowards(transform.position,
                transform.position + derection, _speed * Time.deltaTime);
            _sprite.flipX = derection.x > 0.0f;
        }

        private void Jump()
        {
            Rigibody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }

        private void Shoot()
        {
            Vector3 position = transform.position;
            position.y += 1.0f;
            Bullet newBullet = Instantiate(_bullet, position, _bullet.transform.rotation) as Bullet;
            newBullet.Parent = gameObject;
            newBullet.Direction = newBullet.transform.right * (_sprite.flipX ? 1.0F : -1.0F);
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,0.3F);
            _isGrounded = colliders.Length > 1;
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            Unit unit = collider2D.GetComponent<Unit>();
            if (unit)
            {
                ReceiveDamage();
            }
            Bullet bullet = collider2D.GetComponent<Bullet>();
            if (bullet && bullet.Parent != gameObject)
            {
                ReceiveDamage();
            }
        }
        public override void  ReceiveDamage()
        { 
            Rigibody.AddForce(Vector3.up *10F ,ForceMode2D.Impulse);
            _lives--;
            if (_lives == 0)
            {
                LoadPrefs.Save();
                WWWForm form = new WWWForm();
                form.AddField("username", LoadPrefs.Login);
                form.AddField("email", LoadPrefs.Email);
                form.AddField("fullname", LoadPrefs.Name);
                form.AddField("age", LoadPrefs.Age);
                form.AddField("score", LoadPrefs.Score);
                form.AddField("password", LoadPrefs.Password);
                WWW www = new WWW("http://servernew.mycloud.by/users/update", form);
                StartCoroutine(WaitForRequest(www));
                Die();
                Application.LoadLevel("menu 1");
            }
        }

        IEnumerator WaitForRequest(WWW wwwRequest)
        {
            yield return wwwRequest;
            if (wwwRequest.error == null)
            {
                Debug.Log("WWW Ok! - result: " + wwwRequest.data + "WWW text" + wwwRequest.text);
            }
            else
            {
                Debug.Log("WWW Error: " + wwwRequest.error);
            }
        }

        
        public static int GetLives()
        {
            return _lives;
        }
        public static void SetLives(int newLives)
        {
            _lives = newLives;
        }
        public static int GetPoints()
        {
            return _points;
        }
        public void AddLives(int lives)
        {
            _lives += lives;
        }
        public void AddPoints(int points)
        {
            _points += points;
        }
    }
}
