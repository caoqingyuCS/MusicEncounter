using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackCtrl : MonoBehaviour
{
    public static KnapsackCtrl Ins;
    private void Awake()
    {
        Ins = this;
    }

    public UI_View_Knapsack KnapsackView;

    public void OpenView()
    {
        KnapsackView.OpenView();
        UpdateKnapsackView();
    }

    public void UpdateKnapsackView()
    {
        KnapsackView.UpdateKnapsackView(PlayerInfoCtrl.Ins.KnapsackLst);//Update after opening the backpack
    }
    
    //pick up item
    public void PickUpItem(int id)
    {
        var data = DataCtrl.Ins.GetItemData(id);
        if (data!= null)
        {
            //todo update data
            if (PlayerInfoCtrl.Ins.StoreItem(DataCtrl.Ins.GetItemData(id)))
            {
                Debug.LogWarning("Store item success");
                foreach (var item in PlayerInfoCtrl.Ins.KnapsackLst)
                {
                    if(item.CurItemData!=null)
                        print(item);
                }

                if (KnapsackView.gameObject.activeInHierarchy)
                {
                    UpdateKnapsackView();
                }
            }
            else
            {
                Debug.LogWarning("Store item failed");
            }
        }
    }

  public bool PickUpInstrument(int id)
{
    var data = DataCtrl.Ins.GetInstrumentData(id);
    if (data!= null)
    {
       //todo update data
        if (PlayerInfoCtrl.Ins.StoreItem(DataCtrl.Ins.GetInstrumentData(id)))
        {
            Debug.LogWarning("Store item success");
            foreach (var item in PlayerInfoCtrl.Ins.KnapsackLst)
            {
                if(item.CurItemData!=null)
                print(item);
            }

            if (KnapsackView.gameObject.activeInHierarchy)
            {
                UpdateKnapsackView();
            }
        }
        else
        {
            Debug.LogWarning("Store item failed");
        }
    }
    return false; // Return false if instrumentData is null
}

    public void Dropitem(int Index)
    {
        PlayerInfoCtrl.Ins.DropItem(Index);
        if (KnapsackView.gameObject.activeInHierarchy)
        {
            UpdateKnapsackView();
        }
    }
    
    
}
