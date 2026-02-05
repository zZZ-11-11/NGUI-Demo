using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ChooseServerPanel : BasePanel
{
    public ScrollRect svLeft;
    public ScrollRect svRight;
    public Text txtName;
    public Image imgState;
    public Text txtRange;

    private List<GameObject> m_ItemList = new List<GameObject>();

    protected override void Init()
    {
        List<ServerData> serverList = LoginManager.instance.serverDatas;
        int num = serverList.Count / 5 + 1;
        for (int i = 0; i < num; i++)
        {
            GameObject item = Instantiate(Resources.Load<GameObject>("UI/ServerLeftItem"), svLeft.content, false);
            ServerLeftItem serverLeft = item.GetComponent<ServerLeftItem>();
            int beginIndex = i * 5 + 1;
            int endIndex = 5 * (i + 1);
            if (endIndex > serverList.Count)
            {
                endIndex = serverList.Count;
            }
            serverLeft.InitInfo(beginIndex, endIndex);
        }
    }

    public override void ShowMe()
    {
        base.ShowMe();
        int id = LoginManager.instance.loginData.frontSeverID;
        if (id <= 0)
        {
            txtName.text = "请选择服务器";
            imgState.gameObject.SetActive(false);
        }
        else
        {
            ServerData serverData = LoginManager.instance.serverDatas[id - 1];
            txtName.text = serverData.id + "区  " + serverData.serverName;
            imgState.gameObject.SetActive(true);
            SpriteAtlas atlas = Resources.Load<SpriteAtlas>("Login");
            switch (serverData.state)
            {
                case 0:
                    imgState.gameObject.SetActive(false);
                    break;
                case 1:
                    imgState.sprite = atlas.GetSprite("ui_DL_liuchang_01");
                    break;
                case 2:
                    imgState.sprite = atlas.GetSprite("ui_DL_fanhua_01");
                    break;
                case 3:
                    imgState.sprite = atlas.GetSprite("ui_DL_huobao_01");
                    break;
                case 4:
                    imgState.sprite = atlas.GetSprite("ui_DL_weihu_01");
                    break;
            }
        }
        UpdatePanel(1, 5 > LoginManager.instance.serverDatas.Count ? LoginManager.instance.serverDatas.Count : 5);
    }

    public void UpdatePanel(int beginIndex, int endIndex)
    {
        txtRange.text = "服务器" + beginIndex + "—" + endIndex;
        for (int i = 0; i < m_ItemList.Count; i++)
        {
            Destroy(m_ItemList[i]);
        }
        m_ItemList.Clear();
        for (int i = beginIndex - 1; i < endIndex; i++)
        {
            ServerData nowInfo = LoginManager.instance.serverDatas[i];
            GameObject item = Instantiate(Resources.Load<GameObject>("UI/ServerRightItem"), svRight.content, false);
            ServerRightItem serverRight = item.GetComponent<ServerRightItem>();
            serverRight.InitInfo(nowInfo);
            m_ItemList.Add(item);
        }
    }
}