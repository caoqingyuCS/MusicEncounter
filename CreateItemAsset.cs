using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemAsset", menuName = "CreateItemAsset", order = 0)] // 创建assets的特性
public class CreateItemAsset : ScriptableObject//存放所有的Item数据， scriptable是父类，创建assets
{
    public List<ItemData> EquipmentDataLst;
}
