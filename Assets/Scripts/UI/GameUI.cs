using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject gameMenu;
    public void Pause()//����Ϸ�ڲ˵�
    {
        gameMenu?.SetActive(!gameMenu.activeInHierarchy);//���Ʋ˵�
        if (gameMenu.activeInHierarchy) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
    [Header("UIs")]
    [SerializeField] Text[] dataTexts = new Text[4];
    [SerializeField]Text dateText;
    private void Update()
    {
        for(int i=0;i<4;i++)
        {
            dataTexts[i].text = "��ǰ��:" + PlayManager.Instance.datas[i] + "/������:" + (PlayManager.Instance.useSpeed[i] - PlayManager.Instance.getSpeed[i]);
        }
        dateText.text = PlayManager.Instance.AddDay.ToString();
    }
}
