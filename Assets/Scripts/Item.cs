using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item:MonoBehaviour 
{
    public Vector2Int mapPos;//��ͼ�ϵ�����
    protected virtual void Awake()
    {
        //PlayManager.Instance.map[]
    }
}
