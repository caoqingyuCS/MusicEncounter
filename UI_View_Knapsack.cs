using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_View_Knapsack : UIViewBase
{

    public List<UI_Obj_Slot> SlotList;

    //Start ItemInfoView
    public GameObject ItemInfoViewGo;
    public Text ItemName;
    public Image ItemIcon;
    public Button[] BtnArr;
    public Button BtnClose;

    //这个是什么用的？
    [SerializeField] private int CurSlotIndexOnClick = -1;
    private Item CurItem;
    public Text PlayerDmg, PlayerArmour;
    public EquipSlot[] EquipSlotArr;
    
    
    private void Start()
    {    //Lamda 表达式? 匿名方法，没有名称的方法. Addlistener又是啥？
        BtnClose.onClick.AddListener(()=> {
            ItemInfoViewGo.SetActive(false);
            CurSlotIndexOnClick = -1;
        });
        BtnArr[0].onClick.AddListener(()=>
        {
            if (CurSlotIndexOnClick != -1)
            {
                
                ItemInfoViewGo.SetActive(false);
            }
        });

        BtnArr[2].onClick.AddListener(()=>
        {
            if (CurSlotIndexOnClick != -1)
            {
                KnapsackCtrl.Ins.Dropitem(CurSlotIndexOnClick);
                ItemInfoViewGo.SetActive(false);
            }
        });
        for (int i = 0; i < SlotList.Count; i++)
        {
            SlotList[i].Index = i;
        }
    }
    //End Iteminfo view
    
    
    public override void BeforeOpenView()
    {
        UpdateRoleInfo();
        Debug.Log("UI: Open Knapsack");
    }

    public void UpdateKnapsackView(List<Item> itemLst)   
    {
        for (int i = 0; i < itemLst.Count; i++)
        {
            if (itemLst[i].CurItemData != null)//数据不为空，update
                SlotList[i].UpdateView(itemLst[i],itemLst[i].CurCount);
            else//数据为空，清除显示的物品
            {
                SlotList[i].ClearView();
            }
        }
    }

    public void UpdateAndOpenItemInfoView(Item item,int curSlotIndex)//传Item过来
    {
        if (item.CurItemData == null)
        {
            Debug.LogError("更新视图失败，item为空"+item.CurItemData.Id);
            return;
        }

        CurSlotIndexOnClick = curSlotIndex;//赋值
        ItemInfoViewGo.SetActive(true);
        switch (item.CurItemData.Type)//switch是什么？
        {    //按钮更新
            case ItemType.EQUIPMENT:
                BtnArr[0].gameObject.SetActive(true);
                BtnArr[2].gameObject.SetActive(true);
                break;
            case ItemType.MONEY:
                break;
            case ItemType.INSTRUMENT:
                break;
        }

        CurItem = item;
        ItemIcon.sprite = Resources.Load<Sprite>(item.CurItemData.Icon);
        ItemName.text = item.CurItemData.Name;
    }

    
    public void UpdateRoleInfo()
    {
        //PlayerDmg.text = PlayerCtrl.Ins.InfoCtrl.Damage.ToString();
        //PlayerArmour.text = PlayerCtrl.Ins.InfoCtrl.Armour.ToString();
    }
    

}

//删除：遍历一遍，删掉数据层，更新视图层