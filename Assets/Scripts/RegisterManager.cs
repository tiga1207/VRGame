using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegisterManager : MonoBehaviour
{


    public TMP_InputField id;
    public TMP_InputField pw;
    public TMP_InputField userName;
    public Button gotoLoginBtn;
    public Button SignupBtn; // signup 페이지로 이동
    public GameObject LoginPanel;
    public GameObject signUpPanel;
    void Start()
    {
        if(gotoLoginBtn!=null)
        {
            gotoLoginBtn.onClick.AddListener(GoToLoginMenu);
        }
        if(SignupBtn!=null)
        {
            SignupBtn.onClick.AddListener(Signup);
        }
    }

    public void GoToLoginMenu()
    {
        signUpPanel.SetActive(false);
        LoginPanel.SetActive(true);
    }

    public void Signup()
    {
        if(id.text.Length > 0 && pw.text.Length > 0 && userName.text.Length > 0)
        {
            signUpPanel.SetActive(false);
            LoginPanel.SetActive(true);
        }
    }

   
}
