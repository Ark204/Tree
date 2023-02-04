using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TreeNode : Item,IPointerDownHandler
{
    [SerializeField] List<TreeNode> childs = new List<TreeNode>(); 

    public void OnPointerDown(PointerEventData eventData)
    {
        Focus.Instance.GetFocus(this);
    }
    //创建子节点
    public bool CreateChild(Vector2Int offset)
    {
        if (PlayManager.Instance.map[mapPos.x+offset.x, mapPos.y+offset.y] != null) return false;
        var gameObject = Instantiate(PlayManager.Instance.root) as GameObject;
        gameObject.transform.position = new Vector3(mapPos.y+offset.y - 15, -mapPos.x-offset.x);
        PlayManager.Instance.map[mapPos.x+offset.x, mapPos.y+offset.y] = gameObject;//注册入地图
        var child = gameObject.GetComponent<TreeNode>();
        child.mapPos = mapPos+offset;
        childs.Add(child);

        return true;
    }
    //退化
    public void Remove()
    {
        foreach(var child in childs)
        {
            child.Remove();
        }
        Destroy(this.gameObject);
        return ;
    }
}
