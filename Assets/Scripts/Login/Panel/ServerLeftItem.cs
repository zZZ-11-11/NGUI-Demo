using UnityEngine;
using UnityEngine.UI;

public class ServerLeftItem : MonoBehaviour
{
    public Button btnSelf;
    public Text txtInfo;
    private int m_BeginIndex;
    private int m_EndIndex;

    void Start()
    {
        btnSelf.onClick.AddListener(() =>
        {
            ChooseServerPanel panel = UIManager.instance.GetPanel<ChooseServerPanel>();
            panel.UpdatePanel(m_BeginIndex, m_EndIndex);
        });
    }

    public void InitInfo(int beginIndex, int endIndex)
    {
        m_BeginIndex = beginIndex;
        m_EndIndex = endIndex;
        txtInfo.text = m_BeginIndex + "-" + m_EndIndex + "区";
    }
}