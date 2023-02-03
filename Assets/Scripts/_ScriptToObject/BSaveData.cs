using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ݱ������
public abstract class BSaveData : ScriptableObject
{
    //����ʱ���ô˺���
    protected abstract void OnSave();
    //����ʱ���ô˺���
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

    //���ڱ�����ʼ�����о�̬����
    public static void Save()
    {
        foreach (var elem in saveDatas)
        {
            elem.OnSave();
        }
        //������ȡstring
        foreach (var elem in saveDatas)
        { PlayerPrefs.SetString(elem.GetSaveString().Key, elem.GetSaveString().Value); }
        PlayerPrefs.Save();//ͳһ����
    }
    //���ڱ�����ʼ�����о�̬����
    public static void Load()
    {
        foreach (var elem in saveDatas)
            elem.OnLoad();
    }
    

}
