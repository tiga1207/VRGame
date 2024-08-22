using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoginManager : MonoBehaviour
{

    public TMP_InputField id;
    public TMP_InputField pw;
    public Button loginBtn;
    public Button SignupBtn; // signup 페이지로 이동
    public GameObject LoginPanel;
    public GameObject signUpPanel;
    public GameObject MainGamePanel;

    void Start()
    {
        if(SignupBtn!=null)
        {
            SignupBtn.onClick.AddListener(GotoSignupPanel);
        }
        if(LoginPanel!=null)
        {
            loginBtn.onClick.AddListener(Login);
        }
    }

    public void Login()
    {
        if(id.text!=null && id.text.Length>0 && pw.text!=null && pw.text.Length > 0) // id 및 pw 입력을 한다면
        {
            LoginPanel.SetActive(false);
            MainGamePanel.SetActive(true);
        }
    }
    public void GotoSignupPanel()
    {
        LoginPanel.SetActive(false);
        signUpPanel.SetActive(true);
    }
}
