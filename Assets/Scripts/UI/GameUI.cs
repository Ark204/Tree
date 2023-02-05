using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject gameMenu;
    public void Pause()//弹游戏内菜单
    {
        gameMenu?.SetActive(!gameMenu.activeInHierarchy);//控制菜单
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
            dataTexts[i].text = "当前量:" + PlayManager.Instance.datas[i] + "/净消耗:" + (PlayManager.Instance.useSpeed[i] - PlayManager.Instance.getSpeed[i]);
        }
        dateText.text = PlayManager.Instance.AddDay.ToString();
    }
}
