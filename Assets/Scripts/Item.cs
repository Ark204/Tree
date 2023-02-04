using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item:MonoBehaviour 
{
    public Vector2Int mapPos;//地图上的坐标
    protected virtual void Awake()
    {
        //PlayManager.Instance.map[]
    }
}
