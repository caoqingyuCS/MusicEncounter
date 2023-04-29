using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCtrl : MonoBehaviour
{
    public Dictionary<int, ItemData> ItemDict = new Dictionary<int, ItemData>();
    public static DataCtrl Ins;//单例
    
    private void Awake()
    {
        Ins = this;
    }

    private void Start()
    {
        LoadItemData();
    }

    public void LoadItemData()
    {
        //read asset
        CreateItemAsset itemAsset = Resources.Load<CreateItemAsset>("Datas/ItemDataAsset");//ItemDataAsset
        // Load equipment data
        foreach (var item in itemAsset.EquipmentDataLst)
        {
            ItemDict.Add(item.Id,item);
        }
        // Load instrument data
        foreach (var item in itemAsset.InstrumentDataLst) // Add this loop
        {
            ItemDict.Add(item.Id, item);
        }
    }

    public ItemData GetItemData(int id)
    {
        if (!ItemDict.ContainsKey(id))
        {
            Debug.LogError("Not Found item id: " + id);
            return null;
        }
        return ItemDict[id];
    }
    public InstrumentData GetInstrumentData(int id)
    {
        if (ItemDict.ContainsKey(id) && ItemDict[id] is InstrumentData)
        {
            return ItemDict[id] as InstrumentData;
        }
        return null;
    }

/*
    public InstrumentData GetInstrumentData(Item item)
    {
        if (item != null && item.CurItemData != null && item.CurItemData.Type == ItemType.INSTRUMENT)
        {
            return GetItemData(item.CurItemData.Id) as InstrumentData;
        }
        return null;
    }
*/
    
}
