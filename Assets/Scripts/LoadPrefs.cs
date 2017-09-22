using UnityEngine;

namespace Assets.Scripts
{
    public class LoadPrefs : MonoBehaviour {

        public static string Score;
        public static string Lifes;
        public static string Login;
        public static string Email;
        public static string Name;
        public static string Age;
        public static string Password;

        void Start () {
            if (PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("Lifes") && PlayerPrefs.HasKey("Login") 
                && PlayerPrefs.HasKey("Email") && PlayerPrefs.HasKey("Name") && PlayerPrefs.HasKey("Age") && PlayerPrefs.HasKey("Password"))
            {
                Score = PlayerPrefs.GetString("Score");
                Lifes = PlayerPrefs.GetString("Lifes");
                Login = PlayerPrefs.GetString("Login");
                Email = PlayerPrefs.GetString("Email");
                Name = PlayerPrefs.GetString("Name");
                Age = PlayerPrefs.GetString("Age");
                Password = PlayerPrefs.GetString("Password");
            }
        }

	    public static void Save()
        {
            PlayerPrefs.SetString("Score",Score);
            PlayerPrefs.SetString("Lifes",Lifes);
            PlayerPrefs.SetString("Login",Login);
            PlayerPrefs.SetString("Email",Email);
            PlayerPrefs.SetString("Name",Name);
            PlayerPrefs.SetString("Age",Age);
            PlayerPrefs.SetString("Password",Password);
            PlayerPrefs.Save();
           
        }
    }
}
