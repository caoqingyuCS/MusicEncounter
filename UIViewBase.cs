using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIViewBase : MonoBehaviour
{
   public virtual void BeforeOpenView()
   {
      
   }

   public virtual void BeforeCloseView()
   {
      
   }

   public void OpenView()
   {
      BeforeOpenView();
      gameObject.SetActive(true);
   }

   public void CloseView()
   {
      BeforeCloseView();
      gameObject.SetActive(false);
   }
   
}
