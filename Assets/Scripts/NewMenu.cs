using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.WSA;
using Application = UnityEngine.Application;

namespace Assets.Scripts
{
    public class NewMenu : MonoBehaviour
    {
        static string login = "Login";
        static string password = "Password";
        private string _labelText;
        private string _nameRegistration = "Name";
        private string _passwordRegistration = "Password";
        private string _loginRegistration = "Login";
        private string _ageRegistration = "age";
        private string _emailRegistration = "email";
        private float _size = 3.0f;
        private string Window;

        void Start()
        {
            Window = "login";
        }

        void OnGUI()
        {
            GUIStyle butStyle = GUI.skin.button;
            butStyle.fontSize = 20;

            GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 400, 200 * _size, 300 * _size));
            if (Window == "login")
            {
                GUI.Label(new Rect(50, 160 * _size, 180 * _size, 30 * _size), _labelText);

                if (GUI.Button(new Rect(10, 90 * _size, 180 * _size, 30 * _size), "Sign in", butStyle))
                {
                    GetUser(login, password);
                    if (LoadPrefs.Name != null)
                    {
                        Window = "main";
                    }
                }
                if (GUI.Button(new Rect(10, 130 * _size, 180 * _size, 30 * _size), "Registration", butStyle))
                {
                    Window = "registration";
                }
                login = GUI.TextField(new Rect(40, 10 * _size, 125 * _size, 20 * _size), login);
                password = GUI.PasswordField(new Rect(40, 50 * _size, 125 * _size, 20 * _size), password, '*');
            }
            if (Window == "registration")
            {
                _loginRegistration = GUI.TextField(new Rect(40, 10 * _size, 125 * _size, 20 * _size), _loginRegistration);
                _passwordRegistration = GUI.TextField(new Rect(40, 50 * _size, 125 * _size, 20 * _size), _passwordRegistration);
                _nameRegistration = GUI.TextField(new Rect(40, 90 * _size, 125 * _size, 20 * _size), _nameRegistration);
                _emailRegistration = GUI.TextField(new Rect(40, 130 * _size, 125 * _size, 20 * _size), _emailRegistration);
                _ageRegistration = GUI.TextField(new Rect(40, 170 * _size, 125 * _size, 20 * _size), _ageRegistration);
                if (GUI.Button(new Rect(0, 195 * _size, 90 * _size, 30 * _size), "Next", butStyle))
                {
                    if (!_loginRegistration.Equals(""))
                        PostUser(_loginRegistration, _emailRegistration, _nameRegistration, _ageRegistration, _passwordRegistration);
                    Window = "login";
                }
                if (GUI.Button(new Rect(100*_size, 195 * _size, 100 * _size, 30 * _size), "Previous", butStyle))
                {
                    Window = "login";
                }
            }
            if (Window == "main")
            {
                if (GUI.Button(new Rect(10, 30 * _size, 180 * _size, 30 * _size), "Play", butStyle))
                {
                    Window = "play";
                }
                if (GUI.Button(new Rect(10, 70 * _size, 180 * _size, 30 * _size), "Settings", butStyle))
                {
                    Window = "settings";
                }
                if (GUI.Button(new Rect(10, 110 * _size, 180 * _size, 30 * _size), "About", butStyle))
                {
                    Window = "about";
                }
                if (GUI.Button(new Rect(10, 150 * _size, 180 * _size, 30 * _size), "Exit", butStyle))
                {
                    Window = "exit";
                }
            }

            if (Window == "play")
            {
                GUI.Label(new Rect(50, 10 * _size, 180 * _size, 30 * _size), "Select save point:");
                if (GUI.Button(new Rect(10, 40 * _size, 180 * _size, 30 * _size), "Save1", butStyle))
                {
                    Application.LoadLevel("lvl0");
                }
                if (GUI.Button(new Rect(10, 80 * _size, 180 * _size, 30 * _size), "Save2", butStyle))
                {
                    Application.LoadLevel("lvl2");
                }
                if (GUI.Button(new Rect(10, 120 * _size, 180 * _size, 30 * _size), "Save3", butStyle))
                {
                    Application.LoadLevel("lvl3");
                }
                if (GUI.Button(new Rect(10, 160 * _size, 180 * _size, 30 * _size), "Back", butStyle))
                {
                    Window = "main";
                }
            }

            if (Window == "settings")
            {
                GUI.Label(new Rect(80, 10 * _size, 180 * _size, 30 * _size), "Settings");
                if (GUI.Button(new Rect(10, 40 * _size, 180 * _size, 30 * _size), "Game", butStyle))
                {
                    Window = "game";

                }
                if (GUI.Button(new Rect(10, 80 * _size, 180 * _size, 30 * _size), "Audio", butStyle))
                {
                    Window = "audio";
                }
                if (GUI.Button(new Rect(10, 120 * _size, 180 * _size, 30 * _size), "Video", butStyle))
                {
                }
                if (GUI.Button(new Rect(10, 160 * _size, 180 * _size, 30 * _size), "Back", butStyle))
                {
                    Window = "main";
                }
            }

            if (Window == "game")
            {
                if (GUI.Toggle(new Rect(10, 40 * _size, 180 * _size, 30 * _size), false, "Hardcore mode") == true)
                {
                    GUI.Label(new Rect(10, 120 * _size, 180 * _size, 30 * _size), "Hardcore mode activated");
                    LoadPrefs.Lifes = "1";
                    LoadPrefs.Save();
                }
                if (GUI.Button(new Rect(10, 80 * _size, 180 * _size, 30 * _size), "Back", butStyle))
                {
                    Window = "main";
                }
            }
            if (Window == "about")
            {
                GUI.Label(new Rect(50, 10 * _size, 180 * _size, 30 * _size), "Game version 0.1a");
                GUI.Label(new Rect(10, 40 * _size, 180 * _size, 40 * _size), "Developer Tarasenko Andrew");
                if (GUI.Button(new Rect(10, 90 * _size, 180 * _size, 30 * _size), "Back", butStyle))
                {
                    Window = "main";
                }
            }
            if (Window == "exit")
            {
                GUI.Label(new Rect(90, 10, 180 * _size, 30 * _size), "Exit?");
                if (GUI.Button(new Rect(10, 40 * _size, 180 * _size, 30 * _size), "Yes", butStyle))
                {
                    Destroy(this);
                }
                if (GUI.Button(new Rect(10, 80 * _size, 180 * _size, 30 * _size), "No", butStyle))
                {
                    Window = "main";
                }
            }
            if (Window == "audio")
            {
                if (GUI.Toggle(new Rect(10, 40 * _size, 180 * _size, 30 * _size), false, "Disable music") == true)
                {
                    AudioListener.volume = 0;
                }
                if (GUI.Toggle(new Rect(10, 60 * _size, 180 * _size, 30 * _size), false, "Enable music") == true)
                {
                    AudioListener.
                        volume = 1;
                }

                if (GUI.Button(new Rect(10, 90 * _size, 180 * _size, 30 * _size), "Back", butStyle))
                {
                    Window = "main";
                }
                GUI.EndGroup();
            }
        }
        public void PostUser(string _loginRegistration, string _emailRegistration, string _nameRegistration, string _ageRegistration, string _passwordRegistration)
        {
            WWWForm form = new WWWForm();
            form.AddField("username", _loginRegistration);
            form.AddField("email", _emailRegistration);
            form.AddField("fullname", _nameRegistration);
            form.AddField("age", _ageRegistration);
            form.AddField("score", 0);
            form.AddField("password", _passwordRegistration);
            WWW www = new WWW("http://servernew.mycloud.by/users/adduser", form);
            StartCoroutine(WaitForRequest(www));
        }
        public void GetUser(string Login, string Password)
        {
            Debug.Log(Login + Password);
            WWWForm form = new WWWForm();
            form.AddField("username", Login);
            form.AddField("password", Password);
            WWW www = new WWW("http://servernew.mycloud.by/users/getuser", form);
            StartCoroutine(WaitForRequest(www));
        }
        public void UpDateUser(string Login, string Email, string Name, string Age, string Password, string Score)
        {
            WWWForm form = new WWWForm();
            form.AddField("username", Login);
            form.AddField("email", Email);
            form.AddField("fullname", Name);
            form.AddField("age", Age);
            form.AddField("score", Score);
            form.AddField("password", Password);
            WWW www = new WWW("http://servernew.mycloud.by/users/update", form);
            StartCoroutine(WaitForRequest(www));
        }


        IEnumerator WaitForRequest(WWW www)
        {
            yield return www;
            // check for errors
            if (www.error == null)
            {
                string JSONstring = www.data.Remove(0, 1);
                string buffer = JSONstring.Remove(JSONstring.Length - 1, 1);
                Debug.Log(buffer);
                UserInfocs userinfo = new UserInfocs();
                userinfo = JsonUtility.FromJson<UserInfocs>(buffer);
                LoadPrefs.Age = userinfo.Age;
                LoadPrefs.Email = userinfo.Email;
                LoadPrefs.Lifes = "5";
                LoadPrefs.Login = userinfo.Username;
                LoadPrefs.Name = userinfo.FullName;
                LoadPrefs.Password = userinfo.Password;
                LoadPrefs.Score = userinfo.Score;
                LoadPrefs.Save();
                Debug.Log("WWW Ok! - result: " + www.data);
            }
            else
            {
                Debug.Log("WWW Error: " + www.error);
            }
        }

    }
}

