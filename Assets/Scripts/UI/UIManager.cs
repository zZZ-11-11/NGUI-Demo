using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public static UIManager instance { get; } = new UIManager();

    private Dictionary<String, BasePanel> m_PanelDict = new Dictionary<string, BasePanel>();

    private Transform m_CanvasTransform;

    private UIManager()
    {
        m_CanvasTransform = GameObject.Find("Canvas").transform;
        GameObject.DontDestroyOnLoad(m_CanvasTransform.gameObject);
    }

    public T ShowPanel<T>() where T : BasePanel
    {
        String panelName = typeof(T).Name;
        if (m_PanelDict.TryGetValue(panelName, value: out var value))
        {
            value.ShowMe();
            return value as T;
        }
        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName), m_CanvasTransform, false);
        T panel = panelObj.GetComponent<T>();
        m_PanelDict.Add(panelName, panel);
        panel.ShowMe();
        return panel;
    }

    public void HidePanel<T>(bool isFade = true) where T : BasePanel
    {
        String panelName = typeof(T).Name;
        if (m_PanelDict.ContainsKey(panelName))
        {
            if (isFade)
            {
                m_PanelDict[panelName].HideMe(() =>
                {
                    GameObject.Destroy(m_PanelDict[panelName].gameObject);
                    m_PanelDict.Remove(panelName);
                });
            }
            else
            {
                GameObject.Destroy(m_PanelDict[panelName].gameObject);
                m_PanelDict.Remove(panelName);
            }
        }
    }

    public T GetPanel<T>() where T : BasePanel
    {
        String panelName = typeof(T).Name;
        if (m_PanelDict.TryGetValue(panelName, out var value))
        {
            return value as T;
        }
        return null;
    }
}