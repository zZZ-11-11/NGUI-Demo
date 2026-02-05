using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServerPanel : BasePanel
{
    public Button btnStart;
    public Button btnChange;
    public Button btnBack;
    public Text txtServerName;

    // Update is called once per frame
    protected override void Init()
    {
        btnBack.onClick.AddListener(() =>
        {
            UIManager.instance.ShowPanel<LoginPanel>();
            UIManager.instance.HidePanel<ServerPanel>();
        });
        btnStart.onClick.AddListener(() =>
        {
            UIManager.instance.HidePanel<ServerPanel>();
            SceneManager.LoadScene("GameScene");
        });
        btnChange.onClick.AddListener(() =>
            {
                UIManager.instance.ShowPanel<ChooseServerPanel>();
                UIManager.instance.HidePanel<ServerPanel>();
            }
        );
    }

    public override void ShowMe()
    {
        base.ShowMe();
        LoginData loginData = LoginManager.instance.loginData;
        txtServerName.text = loginData.frontSeverID + "区 " + LoginManager.instance.serverDatas[loginData.frontSeverID - 1].serverName;
    }
}