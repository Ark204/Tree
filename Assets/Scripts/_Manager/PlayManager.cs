using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoSingleton<PlayManager>
{
    public GameObject[,] map=new GameObject[60,30];//地图数据
    public GameObject root;
    //[SerializeField] Object branch;
    //public bool Create(Vector2Int mapPos)
    //{
    //    if (map[mapPos.x, mapPos.y] != null) return false;
    //    var gameObject= Instantiate(root) as GameObject;
    //    gameObject.transform.position = new Vector3(mapPos.y - 15, -mapPos.x);
    //    map[mapPos.x, mapPos.y] = gameObject;//注册入地图
    //    gameObject.GetComponent<Item>().mapPos = mapPos;
    //    return true;
    //}
    public void Start()
    {
        map[0, 15] = root;
    }
    public void OnDrawGizmos()
    {
        
    }
}
