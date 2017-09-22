using UnityEngine;

namespace Assets.Scripts
{
    public class Teleport : MonoBehaviour {

        [SerializeField]
        public string LevelName;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var unit = collider2D.GetComponent<Unit>();
            if (unit)
            {
                LoadPrefs.Save();
                Application.LoadLevel(LevelName);
            }
        }
    }
}
