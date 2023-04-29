using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoCtrl : MonoBehaviour
{
   public int Hp = 100;
   public int Damage = 10;

   //public PlayerCtrl Ctrl;
   
   //背包属性
   [SerializeField] private const int maxKnapssackSlotCount = 21;
   public List<Item> KnapsackLst = new List<Item>(maxKnapssackSlotCount);
   //数据层

   //单例模式
   public static PlayerInfoCtrl Ins;

   private void Awake()
   {
      Ins = this;
      for (int i = 0; i < maxKnapssackSlotCount; i++)
      {
         var item = new Item();//initialize
         KnapsackLst.Add(item);
      }
   }

   public void UpdatePlayerInfo()
   {
      
   }
   
   //1.遍历背包
   //2.找相同类物品-> 找到/找不到；找到->capacity满，或者不满； 满->往后继续找相同类物品，直到都返回false
   //3.找空格，有空格放，没空格false

   public bool StoreItem(ItemData data)
   {
      if (!FindSameItemToStore(data)) //如果不存在相同的，找空槽
      {
         return FindEmptySlotAndStore(data);
      }
      return true;
   }

   public bool FindSameItemToStore(ItemData data)
   {
      int SameCount = 0;//记录相同的个数
      foreach (var item in KnapsackLst)
      {
         if (item.CurItemData != null)
         {
            if (item.CurItemData.Id == data.Id)
            {
               SameCount++;//同类物品++
            }
         }
      }

      int curIndex = 0;
      foreach (var item in KnapsackLst) //遍历背包
      {
         if (item.CurItemData != null)
         {
            if (item.CurItemData.Id == data.Id) //说明是同类物品
            {
               curIndex++;
               if (item.CurCount == data.Capacity)
               {
                  //已经等于最大容量
                  //如果已经遍历到了最后一个相同物品
                  if (curIndex == SameCount)
                     return false;
                  continue;
               }
               else // curcount < capacity
               {
                  item.CurCount++; //存储成功
                  return true;
               }
            }//if 2
         }
      }
      return false;
   }

   public bool FindEmptySlotAndStore(ItemData data)//有空槽，存储数据
   {
      foreach (var item in KnapsackLst)
      {
         if (item.CurItemData == null)
         {
            item.CurItemData = data;
            item.CurCount += 1;
            return true;
         }
      }
      return false;
   }

   public void DropItem(int Index)
   {
      if (KnapsackLst[Index] != null)
      {
         KnapsackLst[Index].CurCount--;
         if (KnapsackLst[Index].CurCount <= 0)
         {
            KnapsackLst[Index]=new Item();//初始到0
         }
      }
   }
}
