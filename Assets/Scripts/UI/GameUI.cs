using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject gameMenu;
    public void Pause()//弹游戏内菜单
    {
        gameMenu?.SetActive(!gameMenu.activeInHierarchy);//控制菜单
        if (gameMenu.activeInHierarchy) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
