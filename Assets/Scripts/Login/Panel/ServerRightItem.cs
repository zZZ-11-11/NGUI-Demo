using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ServerRightItem : MonoBehaviour
{
    public Button btnSelf;
    public Image imgNew;
    public Image imgState;
    public Text txtName;

    public ServerData nowServerData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btnSelf.onClick.AddListener(() =>
        {
            LoginManager.instance.loginData.frontSeverID = nowServerData.id;
            LoginManager.instance.SaveLoginData();
            UIManager.instance.HidePanel<ChooseServerPanel>();
            UIManager.instance.ShowPanel<LoginPanel>();
        });
    }

    public void InitInfo(ServerData serverData)
    {
        nowServerData = serverData;
        txtName.text = serverData.id + "区  " + serverData.serverName;
        imgNew.gameObject.SetActive(serverData.isNew);
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

    // Update is called once per frame
    void Update()
    {
    }
}