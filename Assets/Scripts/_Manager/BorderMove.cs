using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderMove : MonoBehaviour
{
    public int Test;
    [Header("边缘移动")]
    [SerializeField] float m_MoveSpeed=3.5f;//移速
    [SerializeField] float borderWith = 50f;//边界范围
    [SerializeField] Vector2 xRange;//x轴范围
    [SerializeField] Vector2 yRange;//y轴范围
    [Header("缩放")]
    [SerializeField]float m_ScaleSpeed = 500f;//缩放速度
    [SerializeField] Vector2 zRange;//缩放范围

    Transform m_transform;
    Camera m_camera;
    private void Awake()
    {
        m_transform = transform;
        m_camera = GetComponent<Camera>();
    }
    void Update()
    {
        //边缘移动
        Vector2 mousePos = Input.mousePosition;
        if(mousePos.x>Screen.width-borderWith)
        {
            m_transform.Translate(m_transform.right * m_MoveSpeed * Time.deltaTime,Space.World);
        }
        else if(mousePos.x<borderWith)
        {
            m_transform.Translate(-m_transform.right * m_MoveSpeed * Time.deltaTime,Space.World);
        }
        if (mousePos.y > Screen.height - borderWith)
        {
            m_transform.Translate(m_transform.up * m_MoveSpeed * Time.deltaTime,Space.World);
        }
        else if (mousePos.y < borderWith)
        {
            m_transform.Translate(-m_transform.up * m_MoveSpeed * Time.deltaTime,Space.World);
        }
        //缩放
        float scrollWhell = Input.GetAxis("Mouse ScrollWheel");
        var size = m_camera.orthographicSize + scrollWhell * m_ScaleSpeed * Time.deltaTime;
        size = Mathf.Clamp(size, zRange.x, zRange.y);//限制最大最小尺寸
        m_camera.orthographicSize = size;
        // m_transform.Translate(m_transform.forward*scrollWhell*m_ScaleSpeed*Time.deltaTime, Space.World);


        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, xRange.x, xRange.y);
        pos.y = Mathf.Clamp(pos.y, yRange.x, yRange.y);
        //pos.z = Mathf.Clamp(pos.z, zRange.x, zRange.y);
        transform.position = pos;

    }
}
