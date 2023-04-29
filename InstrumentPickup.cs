using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentPickup : MonoBehaviour
{
    public CreateItemAsset itemAsset;
    public int instrumentDataIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KnapsackCtrl knapsackCtrl = FindObjectOfType<KnapsackCtrl>();
            InstrumentManager instrumentManager = FindObjectOfType<InstrumentManager>();
            
            InstrumentData instrumentData = itemAsset.InstrumentDataLst[instrumentDataIndex];
            if (knapsackCtrl.PickUpInstrument(instrumentData))
            {
                // Find the index of the picked-up instrument in the KnapsackLst
                int instrumentIndex = PlayerInfoCtrl.Ins.KnapsackLst.FindIndex(item => item.CurItemData?.Id == instrumentData.Id);

                // If the instrument is found in the KnapsackLst, switch to it
                if (instrumentIndex >= 0)
                {
                    Debug.Log("switch to instrument"); 
                    instrumentManager.SwitchToInstrument(instrumentIndex);
                    Destroy(gameObject);
                }
            }
            
        }
    }
}
