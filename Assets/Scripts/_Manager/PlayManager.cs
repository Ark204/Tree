using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoSingleton<PlayManager>
{
    public GameObject[,] map=new GameObject[60,30];//��ͼ����
    public Object[] roots=new Object[2];//���ָ���Ԥ����
    [Range(0,1)] int m_index;//0Ϊsingle 1Ϊbranch
    public int Index { 
        get=>m_index; 
        set { 
            m_index = value;
            foreach (var elem in images) elem.color = Color.white;//��ʼ����ɫ
            images[m_index].color = Color.red;//����ѡ��
        }
    }
    [SerializeField] Image[] images = new Image[2];
    public GameObject root;//������
    //[SerializeField] Object branch;
    //public bool Create(Vector2Int mapPos)
    //{
    //    if (map[mapPos.x, mapPos.y] != null) return false;
    //    var gameObject= Instantiate(root) as GameObject;
    //    gameObject.transform.position = new Vector3(mapPos.y - 15, -mapPos.x);
    //    map[mapPos.x, mapPos.y] = gameObject;//ע�����ͼ
    //    gameObject.GetComponent<Item>().mapPos = mapPos;
    //    return true;
    //}

    //Data
    private int m_day=0;//����
    public int AddDay { 
        get => m_day; 
        set {
            m_day ++; 
            for(int i=0;i<4;i++)//��Դ����
            {
                datas[i] -= (useSpeed[i] - getSpeed[i]);
            }
            //��������
        } 
    }
    public float[] datas = new float[4];//��������
    public float[] useSpeed = new float[4];//�����ٶ�
    public float[] getSpeed = new float[4];//�����ٶ�

    public void Start()
    {
        map[0, 15] = root;
    }
    //public List<Item> GetRound(Vector2Int mapPos)
    //{
    //    Vector2Int xRange = new Vector2Int(Mathf.Clamp(mapPos.x-1,0,59), Mathf.Clamp(mapPos.x + 1, 0, 59));
    //    Vector2Int yRange = new Vector2Int(Mathf.Clamp(mapPos.y - 1, 0, 29), Mathf.Clamp(mapPos.y+ 1, 0, 59));
    //    List<Item> items = new List<Item>();
    //    Item item;
    //    try
    //    {
    //        item=map[]
    //    }
    //    catch
    //    {

    //    }
    //}
}
