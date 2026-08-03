using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//UI窗口基类
public class WindowRoot : MonoBehaviour
{
    protected Root root;
    protected UIService uiService;
    protected ResService resService;
    protected NetService netService;
    protected AudioService audioService;
    protected virtual void InitWindow()
    {
        root = Root.Instance;
        uiService = root.UIService;
        resService = root.ResService;
        netService = root.NetService;
        audioService = root.AudioService;
    }
    protected virtual void UnInitWindow()
    {
        root = null;
        uiService = null;
        resService = null;
        netService = null;
        audioService = null;
    }
    public void SetWindowState(bool isActive=true)
    {
        if(gameObject.activeSelf != isActive)
        {
            gameObject.SetActive(isActive);
        }
        if(isActive)
        {
            InitWindow();
        }
        else
        {
            UnInitWindow();
        }
    }

    #region UI工具方法
    protected void SetActive(GameObject go, bool state = true)
    {
        go.SetActive(state);
    }
    protected void SetActive(Transform trans, bool state = true)
    {
        trans.gameObject.SetActive(state);
    }
    protected void SetActive(RectTransform rectTrans, bool state = true)
    {
        rectTrans.gameObject.SetActive(state);
    }
    protected void SetActive(Image img, bool state = true)
    {
        img.gameObject.SetActive(state);
    }
    protected void SetActive(Text txt, bool state = true)
    {
        txt.gameObject.SetActive(state);
    }
    protected void SetActive(InputField ipt, bool state = true)
    {
        ipt.gameObject.SetActive(state);
    }
    protected void SetText(Transform trans, int num = 0)
    {
        SetText(trans.GetComponent<Text>(), num.ToString());
    }
    protected void SetText(Transform trans, string context = "")
    {
        SetText(trans.GetComponent<Text>(), context);
    }
    protected void SetText(Text txt, int num = 0)
    {
        SetText(txt, num.ToString());
    }
    protected void SetText(Text txt, string context = "")
    {
        txt.text = context;
    }

    protected Transform GetTrans(Transform trans, string name)
    {
        if (trans != null)
        {
            return trans.Find(name);
        }
        else
        {
            return transform.Find(name);
        }
    }
    protected Image GetImage(Transform trans, string path)
    {
        if (trans != null)
        {
            return trans.Find(path).GetComponent<Image>();
        }
        else
        {
            return transform.Find(path).GetComponent<Image>();
        }
    }
    protected Image GetImage(Transform trans)
    {
        if (trans != null)
        {
            return trans.GetComponent<Image>();
        }
        else
        {
            return transform.GetComponent<Image>();
        }
    }
    protected Text GetText(Transform trans, string path)
    {
        if (trans != null)
        {
            return trans.Find(path).GetComponent<Text>();
        }
        else
        {
            return transform.Find(path).GetComponent<Text>();
        }
    }
    private T GetOrAddComponent<T>(GameObject go) where T : Component
    {
        T t = go.GetComponent<T>();
        if (t == null)
        {
            t = go.AddComponent<T>();
        }
        return t;
    }

    protected void OnClick(GameObject go, Action<PointerEventData, object[]> clickCB, params object[] args)
    {
        Listener listener = GetOrAddComponent<Listener>(go);
        listener.onClick = clickCB;
        if (args != null)
        {
            listener.args = args;
        }
    }
    protected void OnClickDown(GameObject go, Action<PointerEventData, object[]> clickDownCB, params object[] args)
    {
        Listener listener = GetOrAddComponent<Listener>(go);
        listener.onClickDown = clickDownCB;
        if (args != null)
        {
            listener.args = args;
        }
    }
    protected void OnClickUp(GameObject go, Action<PointerEventData, object[]> clickUpCB, params object[] args)
    {
        Listener listener = GetOrAddComponent<Listener>(go);
        listener.onClickUp = clickUpCB;
        if (args != null)
        {
            listener.args = args;
        }
    }
    protected void OnDrag(GameObject go, Action<PointerEventData, object[]> dragCB, params object[] args)
    {
        Listener listener = GetOrAddComponent<Listener>(go);
        listener.onDrag = dragCB;
        if (args != null)
        {
            listener.args = args;
        }
    }
    #endregion
}
