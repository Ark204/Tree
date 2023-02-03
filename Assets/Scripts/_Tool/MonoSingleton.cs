using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T:MonoSingleton<T>
{
    private static T m_instance;
    public static T Instance
    {
        get 
        {
            if (m_instance == null) Debug.LogError(message: "场景中未找到类的引用对象 类名为：" + typeof(T).Name);
            return m_instance;
        }
    }
    protected virtual void Awake()
    {
        if (m_instance == null) m_instance = (T)this;
        else Destroy(gameObject);
    }
    public static bool IsInitialized => m_instance != null;
    protected virtual void OnDestory()
    {
        if (m_instance == this) m_instance = null;
    }
}
