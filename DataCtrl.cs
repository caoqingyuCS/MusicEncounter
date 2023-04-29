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
        foreach (var item in itemAsset.EquipmentDataLst)
        {
            ItemDict.Add(item.Id,item);
            //print(item.Name);
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
    
}
