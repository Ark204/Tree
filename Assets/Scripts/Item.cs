using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item:MonoBehaviour 
{
    public Vector2Int mapPos;//地图上的坐标
    protected virtual void Awake()
    {
        
    }
    protected virtual void Start()
    {
        PlayManager.Instance.map[mapPos.x, mapPos.y] = this.gameObject;
    }
}
