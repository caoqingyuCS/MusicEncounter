using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EquipSlot : MonoBehaviour
{
    public EquipType type;
    public Item CurItem;
    
    public bool Equip(Item item)//穿装备
    {
        if (CurItem != null)
        {
            //交换
        }
        else
        {
            CurItem = item;
        }

        return true;
        
    }

    public bool isEmpty()
    {
        return CurItem == null;
    }
    
 
}
