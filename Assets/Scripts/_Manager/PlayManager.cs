using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoSingleton<PlayManager>
{
    public GameObject[,] map=new GameObject[60,30];//地图数据
    public Object[] roots=new Object[2];//两种根的预制体
    [Range(0,1)] int m_index;//0为single 1为branch
    public int Index { 
        get=>m_index; 
        set { 
            m_index = value;
            foreach (var elem in images) elem.color = Color.white;//初始化颜色
            images[m_index].color = Color.red;//高亮选中
        }
    }
    [SerializeField] Image[] images = new Image[2];
    public GameObject root;//出生点
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

    //Data
    private int m_day=0;//天数
    public int AddDay { 
        get => m_day; 
        set {
            m_day ++; 
            for(int i=0;i<4;i++)//资源更新
            {
                datas[i] -= (useSpeed[i] - getSpeed[i]);
            }
            //其他操作
        } 
    }
    public float[] datas = new float[4];//四项数据
    public float[] useSpeed = new float[4];//销耗速度
    public float[] getSpeed = new float[4];//补给速度

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
