using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//数据保存基类
public abstract class BSaveData : ScriptableObject
{
    //保存时调用此函数
    protected abstract void OnSave();
    //加载时调用此函数
    protected abstract void OnLoad();
    protected virtual KeyValuePair<string, string> GetSaveString()
    {
        return default(KeyValuePair<string, string>);
    }
    protected virtual void OnEnable()
    {
        if (!saveDatas.Contains(this)) saveDatas.Add(this);
    }
    protected virtual void OnDestroy()
    {
        if (saveDatas.Contains(this)) saveDatas.Remove(this);
    }

    //static
    //private static string ListProcessor(List<BSaveData> bSaves)
    //{
    //    return "count:  " + bSaves.Count + "\n";
    //}
    //[Baracuda.Monitoring.Monitor]
    //[Baracuda.Monitoring.MValueProcessor(nameof(ListProcessor))]
    static List<BSaveData> saveDatas = new List<BSaveData>();

    //用于遍历初始化所有静态数据
    public static void Save()
    {
        foreach (var elem in saveDatas)
        {
            elem.OnSave();
        }
        //遍历获取string
        foreach (var elem in saveDatas)
        { PlayerPrefs.SetString(elem.GetSaveString().Key, elem.GetSaveString().Value); }
        PlayerPrefs.Save();//统一保存
    }
    //用于遍历初始化所有静态数据
    public static void Load()
    {
        foreach (var elem in saveDatas)
            elem.OnLoad();
    }
    

}
