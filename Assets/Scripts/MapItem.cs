using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//地图资源等
public class MapItem : Item
{
    public bool isAssest=true;
    [Range(0,4)]public int type;//五种资源类型之一
    public float getSpeed;//资源获取数度
    public bool zhanling = false;
    private void Update()
    {
        if (isAssest)
        {
            var collider2Ds = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.3f, 1.3f), 0);
            foreach (var elem in collider2Ds)
            {
                var root = elem.GetComponent<Root>();
                if (root != null)
                {
                    if (zhanling == false)//还未占领
                    {
                        PlayManager.Instance.getSpeed[type] += getSpeed;
                        zhanling = true;
                    }
                    return;
                }
            }
            if (zhanling)
            {
                PlayManager.Instance.getSpeed[type] -= getSpeed;
                zhanling = false;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(1.3f, 1.3f, 1.3f));
    }
}
