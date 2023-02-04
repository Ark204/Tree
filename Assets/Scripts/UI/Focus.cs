using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoSingleton<Focus>
{
    [SerializeField] public GameObject left;
    [SerializeField] public GameObject right;
    [SerializeField] public GameObject down;
    public Item currentItem;//当前Focus的Item

    public void GetFocus(TreeNode treeNode)
    {
        transform.position = treeNode.transform.position;
        currentItem = treeNode;
        //检查三个方向
    }
    private void Update()
    {
        if (currentItem == null) return;
        var tarMapPos = currentItem.mapPos;//获取节点的地图坐标
        if (0> tarMapPos.x|| tarMapPos.x>=60|| 0 > tarMapPos.y || tarMapPos.y >= 30) return;//超出范围 直接返回
        //分叉根
        //查找当前节点周围的空闲格子
        left.SetActive(tarMapPos.y-1>=0 &&PlayManager.Instance.map[tarMapPos.x , tarMapPos.y-1] == null);
        right.SetActive(tarMapPos.y + 1 < 30 && PlayManager.Instance.map[tarMapPos.x , tarMapPos.y+1] == null);
        down.SetActive(tarMapPos.x + 1 < 60 &&PlayManager.Instance.map[tarMapPos.x + 1, tarMapPos.y] == null);
        //不可分叉根
        if(Input.GetKeyDown(KeyCode.D))
        {
            var treeNode = currentItem.GetComponent<TreeNode>();
            if (treeNode != null) treeNode.Remove();
        }
    }
}
