using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoSingleton<Focus>
{
    [SerializeField] public GameObject left;
    [SerializeField] public GameObject right;
    [SerializeField] public GameObject down;
    public Item currentItem;//��ǰFocus��Item

    public void GetFocus(TreeNode treeNode)
    {
        transform.position = treeNode.transform.position;
        currentItem = treeNode;
        //�����������
    }
    private void Update()
    {
        if (currentItem == null) return;
        var tarMapPos = currentItem.mapPos;//��ȡ�ڵ�ĵ�ͼ����
        if (0> tarMapPos.x|| tarMapPos.x>=60|| 0 > tarMapPos.y || tarMapPos.y >= 30) return;//������Χ ֱ�ӷ���
        //�ֲ��
        //���ҵ�ǰ�ڵ���Χ�Ŀ��и���
        left.SetActive(tarMapPos.y-1>=0 &&PlayManager.Instance.map[tarMapPos.x , tarMapPos.y-1] == null);
        right.SetActive(tarMapPos.y + 1 < 30 && PlayManager.Instance.map[tarMapPos.x , tarMapPos.y+1] == null);
        down.SetActive(tarMapPos.x + 1 < 60 &&PlayManager.Instance.map[tarMapPos.x + 1, tarMapPos.y] == null);
        //���ɷֲ��
        if(Input.GetKeyDown(KeyCode.D))
        {
            var treeNode = currentItem.GetComponent<TreeNode>();
            if (treeNode != null) treeNode.Remove();
        }
    }
}
