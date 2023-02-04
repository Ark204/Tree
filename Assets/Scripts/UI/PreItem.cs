using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PreItem : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Object newObj;
    public Vector2Int offset;
    public void OnPointerDown(PointerEventData eventData)
    {
        var treeNode= Focus.Instance.currentItem.GetComponent<TreeNode>();
        if(treeNode==null)Debug.Log("null");
        treeNode?.CreateChild(offset);
    }
}
