using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject gameMenu;
    public void Pause()//����Ϸ�ڲ˵�
    {
        gameMenu?.SetActive(!gameMenu.activeInHierarchy);//���Ʋ˵�
        if (gameMenu.activeInHierarchy) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
