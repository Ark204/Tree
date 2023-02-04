using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoSingleton<GameManager>
{
    public enum Selection//��ǰѡ��Ĳ���
    {
        DeleteRoot,//ɾ����
        SingleRoot,//���ɷֲ��
        BranchRoot//�ɷֲ��
    }
    public Selection currentSelection;//��ǰѡ��Ĳ���
    public Button currentButton=null;//��ǰѡ��İ�ť
    public Color selectColor=Color.red;//��ťѡ�к����ɫ
    [SerializeField] Button deleteBtn;
    [SerializeField] Button singleBtn;
    [SerializeField] Button branchBtn;
    public void Selecte(Button button)
    {
        if (button == deleteBtn) currentSelection = Selection.DeleteRoot;
        else if (button == singleBtn) currentSelection = Selection.SingleRoot;
        else if (button == branchBtn) currentSelection = Selection.BranchRoot;

        if (currentButton && button != currentButton) currentButton.GetComponent<Image>().color = button.GetComponent<Image>().color;//��ʼ��һ��ѡ�а�ť����ɫ
        currentButton = button;//���µ�ǰѡ�а�ť
        currentButton.GetComponent<Image>().color = selectColor;//������ɫ
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
