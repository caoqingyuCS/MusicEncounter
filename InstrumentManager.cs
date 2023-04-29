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
    private int currentInstrumentIndex;

    public void SwitchToInstrument(int index)
    {
        Item item = PlayerInfoCtrl.Ins.KnapsackLst[index];
        if (item != null && item.CurItemData != null && item.CurItemData.Type == ItemType.INSTRUMENT)
        {
            InstrumentData instrumentData = dataCtrl.GetInstrumentData(item.CurItemData.Id) as InstrumentData;
            if (instrumentData != null)
            {
                textToMusicNotes.currentInstrumentData = instrumentData;
                // Update the UI to show the selected instrument.
            }
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
        Item item = PlayerInfoCtrl.Ins.KnapsackLst[currentInstrumentIndex];
        if (item != null && item.CurItemData != null && item.CurItemData.Type == ItemType.INSTRUMENT)
        {
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
