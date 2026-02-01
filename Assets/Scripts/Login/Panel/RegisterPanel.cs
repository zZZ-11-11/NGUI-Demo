using System;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    public Button btnSure;
    public Button btnCancel;
    public InputField inputUn;
    public InputField inputPw;

    protected override void Init()
    {
        btnSure.onClick.AddListener(() =>
        {
            if (inputUn.text.Length == 0 || inputPw.text.Length == 0)
            {
                UIManager.instance.ShowPanel<TipPanel>().ChangeInfo("用户名或密码不能为空");
                return;
            }
            if (LoginManager.instance.Register(inputUn.text, inputPw.text))
            {
                var loginPanel = UIManager.instance.ShowPanel<LoginPanel>();
                loginPanel.SetInfo(inputUn.text, inputPw.text);
                UIManager.instance.HidePanel<RegisterPanel>();
            }
            else
            {
                var tipPanel = UIManager.instance.ShowPanel<TipPanel>();
                tipPanel.ChangeInfo("用户名已存在");
                inputUn.text = "";
                inputPw.text = "";
            }
        });
        btnCancel.onClick.AddListener(() =>
        {
            UIManager.instance.HidePanel<RegisterPanel>();
            UIManager.instance.ShowPanel<LoginPanel>();
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
    }
}