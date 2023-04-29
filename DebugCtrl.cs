using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCtrl : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            KnapsackCtrl.Ins.OpenView();
        }
        
        if(Input.GetKeyDown((KeyCode.G)))
        {
            KnapsackCtrl.Ins.PickUpItem(1001);
        }
    }
}
