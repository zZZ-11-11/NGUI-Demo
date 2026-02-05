using System;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    public Button btnRegister;

    public Button btnSure;

    public InputField inputName;

    public InputField inputPw;

    public Toggle togglePw;

    public Toggle toggleAuto;

    // Update is called once per frame
    protected override void Init()
    {
        btnRegister.onClick.AddListener(() =>
        {
            UIManager.instance.ShowPanel<RegisterPanel>();
            UIManager.instance.HidePanel<LoginPanel>();
        });
        btnSure.onClick.AddListener(() =>
        {
            if (LoginManager.instance.CheckInfo(inputName.text, inputPw.text))
            {
                LoginManager.instance.loginData.userName = inputName.text;
                LoginManager.instance.loginData.password = inputPw.text;
                LoginManager.instance.SaveLoginData();
                UIManager.instance.HidePanel<LoginPanel>();
                if (LoginManager.instance.loginData.frontSeverID == 0)
                {
                    UIManager.instance.ShowPanel<ChooseServerPanel>();
                }
                else
                {
                    UIManager.instance.ShowPanel<ServerPanel>();
                }
                UIManager.instance.ShowPanel<TipPanel>().ChangeInfo("登录成功");
            }
            else
            {
                UIManager.instance.ShowPanel<TipPanel>().ChangeInfo("用户名或密码错误");
            }
        });
        togglePw.onValueChanged.AddListener((isOn) =>
        {
            if (!isOn)
            {
                toggleAuto.isOn = false;
            }
            LoginManager.instance.loginData.rememberPw = isOn;
        });
        toggleAuto.onValueChanged.AddListener((isOn) =>
        {
            togglePw.isOn = isOn;
            LoginManager.instance.loginData.autoLogin = isOn;
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        LoginData loginData = LoginManager.instance.loginData;
        togglePw.isOn = loginData.rememberPw;
        toggleAuto.isOn = loginData.autoLogin;
        inputName.text = loginData.userName;
        if (loginData.rememberPw)
        {
            inputPw.text = loginData.password;
        }
        if (loginData.autoLogin)
        {
        }
    }

    public void SetInfo(string userName, string password)
    {
        inputName.text = userName;
        inputPw.text = password;
    }
}