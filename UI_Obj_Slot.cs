using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_Slot : MonoBehaviour
{
    public Item CurItem;//可变的数据
    public Image Icon;
    public Text Count;
    public int Index;
    
    public void UpdateView(Item item, int count)
    {
        CurItem = item;
        Icon.sprite = Resources.Load<Sprite>(item.CurItemData.Icon);//加载更新背包内物品的图
        Count.text = count.ToString();
    }

    public void UpdateView(Sprite icon, int count)
    {
        Icon.sprite = icon;
        Count.text = count.ToString();
    }

    public void UpdataView(string spritePath, int count) //加载背包物品图标，文字数量
    {
        Icon.sprite = Resources.Load<Sprite>(spritePath);//
        Count.text = count.ToString();
    }

    public void ClearView()
    {
        Icon.sprite = Resources.Load<Sprite>("Icon/tianfu_02");//"Icon/tianfu_02" "UIMask"
        //清空时候背包啥东西都没有，选一个图片路径
        Count.text = "";
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnSlotClick);
    }

    private void OnSlotClick()
    {
        if (CurItem!= null)//防止点击空格子调用
        {
            KnapsackCtrl.Ins.KnapsackView.UpdateAndOpenItemInfoView(CurItem,Index);//curslotindex
        }
    }

}
