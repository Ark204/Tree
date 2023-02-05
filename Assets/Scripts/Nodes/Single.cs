using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Single : Root
{
    [SerializeField] public Root child=null;
    public override void OnPointerDown(PointerEventData eventData)
    {
        Focus.Instance.GetFocus(this);
    }
    //创建子节点
    public override bool CreateChild(Vector2Int offset)
    {
        //目标格子已被占用
        if (PlayManager.Instance.map[mapPos.x + offset.x, mapPos.y + offset.y] != null) return false;
        
        //无法生长（已有子节点或方向错误）
        if (this.child != null) return false;
        var dir = mapPos - parent.mapPos;
        if (offset.x != dir.x && offset.y != dir.y) return false;//方向错误
        int index = PlayManager.Instance.Index;//获取当前选中
        if(index==0)//单根
        {
            if (PlayManager.Instance.map[mapPos.x + offset.x * 2, mapPos.y + offset.y * 2] != null) return false;
        }
        var gameObject = Instantiate(PlayManager.Instance.roots[index]) as GameObject;//获取当前选中的预制体
        
        gameObject.transform.position = new Vector3(mapPos.y + offset.y - 15, -mapPos.x - offset.x);//初始化坐标
        float ang = 0f;
        if (offset.y > 0) ang = 90f;
        else if (offset.y < 0) ang = -90f;
        gameObject.transform.Rotate(new Vector3(0, 0, 1), ang, Space.World); //旋转
        var child = gameObject.GetComponent<Root>();
        child.parent = this;
        child.mapPos = mapPos + offset;
        PlayManager.Instance.map[mapPos.x + offset.x, mapPos.y + offset.y] = gameObject;//注册入地图
        this.child = child;
        var single = child as Single;
        if (single != null) StartCoroutine(SecondChild(single, mapPos + 2 * offset, ang));//携程生成第二根

        return true;
    }
    IEnumerator SecondChild(Single first,Vector2Int mapPos,float ang)
    {
        yield return new WaitForSeconds(0.5f);
        var gameObject = Instantiate(PlayManager.Instance.roots[PlayManager.Instance.Index]) as GameObject;//获取当前选中的预制体
        gameObject.transform.position = new Vector3(mapPos.y - 15, -mapPos.x );//初始化坐标
        gameObject.transform.Rotate(new Vector3(0, 0, 1), ang, Space.World); //旋转
        var child = gameObject.GetComponent<Root>();
        child.parent = first;
        child.mapPos = mapPos;
        PlayManager.Instance.map[mapPos.x, mapPos.y ] = gameObject;//注册入地图
        first.child = child;
    }
    //退化
    public override void Remove()
    {
        child?.Remove();
        var gameObject = Instantiate(removePref) as GameObject;//获取当前选中的预制体

        gameObject.transform.position = transform.position;//初始化坐标
        gameObject.transform.rotation = transform.rotation;//旋转
        var newObj= gameObject.GetComponent<Item>();
        newObj.mapPos = mapPos ;
        PlayManager.Instance.map[mapPos.x , mapPos.y] = gameObject;//注册入地图
        Destroy(this.gameObject);
        return;
    }
}
