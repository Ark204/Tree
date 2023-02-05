using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//所有根的基类
public class Root : Item, IPointerDownHandler
{
    [SerializeField] public Root parent;

    [Header("Material")]
    public SpriteRenderer mr;
    public string _name = "_Grow";
    public float speed = 1f;
    public virtual void OnPointerDown(PointerEventData eventData) { }
    public virtual bool CreateChild(Vector2Int offset) { return true; }
    [SerializeField] protected Object removePref;
    public virtual void Remove() { }
    protected override void Awake()
    {
        base.Awake();
        mr = GetComponentInChildren<SpriteRenderer>();
    }
    protected virtual void Update()
    {
        float current = mr.material.GetFloat(_name);
        if (current < 1)
        {
            var m = mr.material;
            current += Time.deltaTime * speed;
            Mathf.Clamp(current, 0, 1);
            m.SetFloat(_name, current);
            mr.material = m;
        }
    }
}
