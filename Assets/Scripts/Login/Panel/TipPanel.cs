using System;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel : BasePanel
{
    public Button btnSure;

    public Text txtInfo;

    protected override void Init()
    {
        btnSure.onClick.AddListener(static () => { UIManager.instance.HidePanel<TipPanel>(); });
    }

    public void ChangeInfo(string info)
    {
        txtInfo.text = info;
    }
}