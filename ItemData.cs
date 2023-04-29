using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType //constdefine
{
    EQUIPMENT,
    MONEY,
    INSTRUMENT
}

public enum EquipType
{
    HEAD,
    WEAPON,
    WINGS
}

[Serializable]//可序列化，显示在inspector 面板上
public class ItemData //物品的属性，不变的
{
    public int Id;
    public string Name;
    public string Icon;
    public int Capacity;
    public ItemType Type;
}

[Serializable]
public class EquipmentData : ItemData //不变的
{
    //public int Damage;
    //public int Armour;
    public EquipType EquipType;
}

public class Item //会变的，运行时会修改的，比如装备等级之类的
{
    public ItemData CurItemData;
    public int CurCount;
}

