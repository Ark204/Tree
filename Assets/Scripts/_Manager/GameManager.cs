using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoSingleton<GameManager>
{
    public enum Selection//当前选择的操作
    {
        DeleteRoot,//删除根
        SingleRoot,//不可分叉根
        BranchRoot//可分叉根
    }
    public Selection currentSelection;//当前选择的操作
    public Button currentButton=null;//当前选择的按钮
    public Color selectColor=Color.red;//按钮选中后的颜色
    [SerializeField] Button deleteBtn;
    [SerializeField] Button singleBtn;
    [SerializeField] Button branchBtn;
    public void Selecte(Button button)
    {
        if (button == deleteBtn) currentSelection = Selection.DeleteRoot;
        else if (button == singleBtn) currentSelection = Selection.SingleRoot;
        else if (button == branchBtn) currentSelection = Selection.BranchRoot;

        if (currentButton && button != currentButton) currentButton.GetComponent<Image>().color = button.GetComponent<Image>().color;//初始上一个选中按钮的颜色
        currentButton = button;//更新当前选中按钮
        currentButton.GetComponent<Image>().color = selectColor;//更新颜色
    }
    protected override void Awake()
    {
        base.Awake();
        currentButton = null;
    }
    public void Save()
    {
        BSaveData.Save();
    }
    public void Load()
    {
        BSaveData.Load();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
