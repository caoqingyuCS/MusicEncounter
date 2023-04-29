using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InstrumentManager : MonoBehaviour
{
    public KnapsackCtrl knapsackCtrl;
    public DataCtrl dataCtrl; // Add this line
    public Image instrumentIcon;
    public TextToMusicNotes textToMusicNotes;
    public int currentInstrumentIndex;

    public void SwitchToInstrument(int index)
    {
        InstrumentData instrumentData = dataCtrl.GetInstrumentData(PlayerInfoCtrl.Ins.KnapsackLst[index].CurItemData.Id);

        if (instrumentData != null)
        {
            textToMusicNotes.currentInstrumentData = instrumentData;
            instrumentIcon.sprite = instrumentData.instrument.icon; // Add this line to update the UI
        }
    }

    private void Start()
    {
        currentInstrumentIndex = 0;
        UpdateInstrument();
    }

    public void SelectNextInstrument()
    {
        currentInstrumentIndex = (currentInstrumentIndex + 1) % PlayerInfoCtrl.Ins.KnapsackLst.Count;
        UpdateInstrument();
    }

    public void SelectPreviousInstrument()
    {
        currentInstrumentIndex = (currentInstrumentIndex - 1 + PlayerInfoCtrl.Ins.KnapsackLst.Count) % PlayerInfoCtrl.Ins.KnapsackLst.Count;
        UpdateInstrument();
    }

    private void UpdateInstrument()
    {
        Debug.Log("UPdate!");
        Item item = PlayerInfoCtrl.Ins.KnapsackLst[currentInstrumentIndex];
        if (item != null && item.CurItemData != null && item.CurItemData.Type == ItemType.INSTRUMENT)
        {
            Debug.Log("UPdate instrument success!");
            InstrumentData instrumentData = dataCtrl.GetInstrumentData(item.CurItemData.Id) as InstrumentData;
            if (instrumentData != null)
            {
                instrumentIcon.sprite = instrumentData.instrument.icon;
                textToMusicNotes.currentInstrumentData = instrumentData;
            }
        }
        }
    public Instrument GetCurrentInstrument()
    {
        Item item = PlayerInfoCtrl.Ins.KnapsackLst[currentInstrumentIndex];
        if (item != null && item.CurItemData != null && item.CurItemData.Type == ItemType.INSTRUMENT)
        {
            InstrumentData instrumentData = dataCtrl.GetInstrumentData(item.CurItemData.Id) as InstrumentData;
            return instrumentData?.instrument;
        }
        return null;
    }
}
