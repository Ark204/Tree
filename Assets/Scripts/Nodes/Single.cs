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
    //�����ӽڵ�
    public override bool CreateChild(Vector2Int offset)
    {
        //Ŀ������ѱ�ռ��
        if (PlayManager.Instance.map[mapPos.x + offset.x, mapPos.y + offset.y] != null) return false;
        
        //�޷������������ӽڵ�������
        if (this.child != null) return false;
        var dir = mapPos - parent.mapPos;
        if (offset.x != dir.x && offset.y != dir.y) return false;//�������
        int index = PlayManager.Instance.Index;//��ȡ��ǰѡ��
        if(index==0)//����
        {
            if (PlayManager.Instance.map[mapPos.x + offset.x * 2, mapPos.y + offset.y * 2] != null) return false;
        }
        var gameObject = Instantiate(PlayManager.Instance.roots[index]) as GameObject;//��ȡ��ǰѡ�е�Ԥ����
        
        gameObject.transform.position = new Vector3(mapPos.y + offset.y - 15, -mapPos.x - offset.x);//��ʼ������
        float ang = 0f;
        if (offset.y > 0) ang = 90f;
        else if (offset.y < 0) ang = -90f;
        gameObject.transform.Rotate(new Vector3(0, 0, 1), ang, Space.World); //��ת
        var child = gameObject.GetComponent<Root>();
        child.parent = this;
        child.mapPos = mapPos + offset;
        PlayManager.Instance.map[mapPos.x + offset.x, mapPos.y + offset.y] = gameObject;//ע�����ͼ
        this.child = child;
        var single = child as Single;
        if (single != null) StartCoroutine(SecondChild(single, mapPos + 2 * offset, ang));//Я�����ɵڶ���

        return true;
    }
    IEnumerator SecondChild(Single first,Vector2Int mapPos,float ang)
    {
        yield return new WaitForSeconds(0.5f);
        var gameObject = Instantiate(PlayManager.Instance.roots[PlayManager.Instance.Index]) as GameObject;//��ȡ��ǰѡ�е�Ԥ����
        gameObject.transform.position = new Vector3(mapPos.y - 15, -mapPos.x );//��ʼ������
        gameObject.transform.Rotate(new Vector3(0, 0, 1), ang, Space.World); //��ת
        var child = gameObject.GetComponent<Root>();
        child.parent = first;
        child.mapPos = mapPos;
        PlayManager.Instance.map[mapPos.x, mapPos.y ] = gameObject;//ע�����ͼ
        first.child = child;
    }
    //�˻�
    public override void Remove()
    {
        child?.Remove();
        var gameObject = Instantiate(removePref) as GameObject;//��ȡ��ǰѡ�е�Ԥ����

        gameObject.transform.position = transform.position;//��ʼ������
        gameObject.transform.rotation = transform.rotation;//��ת
        var newObj= gameObject.GetComponent<Item>();
        newObj.mapPos = mapPos ;
        PlayManager.Instance.map[mapPos.x , mapPos.y] = gameObject;//ע�����ͼ
        Destroy(this.gameObject);
        return;
    }
}
