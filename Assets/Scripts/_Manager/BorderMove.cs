using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderMove : MonoBehaviour
{
    public int Test;
    [Header("��Ե�ƶ�")]
    [SerializeField] float m_MoveSpeed=3.5f;//����
    [SerializeField] float borderWith = 50f;//�߽緶Χ
    [SerializeField] Vector2 xRange;//x�᷶Χ
    [SerializeField] Vector2 yRange;//y�᷶Χ
    [Header("����")]
    [SerializeField]float m_ScaleSpeed = 500f;//�����ٶ�
    [SerializeField] Vector2 zRange;//���ŷ�Χ

    Transform m_transform;
    Camera m_camera;
    private void Awake()
    {
        m_transform = transform;
        m_camera = GetComponent<Camera>();
    }
    void Update()
    {
        //��Ե�ƶ�
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
        //����
        float scrollWhell = Input.GetAxis("Mouse ScrollWheel");
        var size = m_camera.orthographicSize + scrollWhell * m_ScaleSpeed * Time.deltaTime;
        size = Mathf.Clamp(size, zRange.x, zRange.y);//���������С�ߴ�
        m_camera.orthographicSize = size;
        // m_transform.Translate(m_transform.forward*scrollWhell*m_ScaleSpeed*Time.deltaTime, Space.World);


        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, xRange.x, xRange.y);
        pos.y = Mathf.Clamp(pos.y, yRange.x, yRange.y);
        //pos.z = Mathf.Clamp(pos.z, zRange.x, zRange.y);
        transform.position = pos;

    }
}
