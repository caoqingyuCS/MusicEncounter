using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentManager : MonoBehaviour
{
    public KnapsackCtrl knapsackCtrl;
    public DataCtrl dataCtrl;
    public Image instrumentIcon;
    public TextToMusicNotes textToMusicNotes;
    public int currentInstrumentIndex;

    public void SwitchToInstrument(int index)
    {
        InstrumentData instrumentData = PlayerInfoCtrl.Ins.KnapsackLst[index].CurItemData as InstrumentData;

        if (instrumentData != null)
        {
            textToMusicNotes.currentInstrumentData = instrumentData;
            instrumentIcon.sprite = instrumentData.instrument.icon;
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
            InstrumentData instrumentData = dataCtrl.GetInstrumentData(item);
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
           InstrumentData instrumentData = dataCtrl.GetInstrumentData(item);

            return instrumentData?.instrument;
        }
        return null;
    }
}
