using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    private CanvasGroup m_CanvasGroup;
    private float m_AlphaSpeed = 10;
    private bool m_IsShow;

    private UnityAction m_HideCallBack;

    protected virtual void Awake()
    {
        m_CanvasGroup = GetComponent<CanvasGroup>();
        if (m_CanvasGroup == null)
        {
            m_CanvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Init();
    }

    public virtual void ShowMe()
    {
        m_IsShow = true;
        m_CanvasGroup.alpha = 0;
    }

    public virtual void HideMe(UnityAction callBack)
    {
        m_IsShow = false;
        m_CanvasGroup.alpha = 1;
        m_HideCallBack = callBack;
    }

    protected abstract void Init();

    void Update()
    {
        if (m_IsShow && !Mathf.Approximately(m_CanvasGroup.alpha, 1))
        {
            m_CanvasGroup.alpha += Time.deltaTime * m_AlphaSpeed;
            if (m_CanvasGroup.alpha > 1)
                m_CanvasGroup.alpha = 1;
        }
        else if (!m_IsShow && m_CanvasGroup.alpha != 0)
        {
            m_CanvasGroup.alpha -= Time.deltaTime * m_AlphaSpeed;
            if (m_CanvasGroup.alpha <= 0)
            {
                m_CanvasGroup.alpha = 0;
                m_HideCallBack?.Invoke();
            }
        }
    }
}