using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var tipPanel = UIManager.instance.ShowPanel<TipPanel>();
        tipPanel.ChangeInfo("This is a tip");
    }

    // Update is called once per frame
    void Update()
    {
    }
}