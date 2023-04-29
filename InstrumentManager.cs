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
        int initialIndex = currentInstrumentIndex;
        do
        {
            currentInstrumentIndex = (currentInstrumentIndex + 1) % PlayerInfoCtrl.Ins.KnapsackLst.Count;
        } while (PlayerInfoCtrl.Ins.KnapsackLst[currentInstrumentIndex].CurItemData.Type != ItemType.INSTRUMENT && currentInstrumentIndex != initialIndex);

        UpdateInstrument();
    }

    public void SelectPreviousInstrument()
    {
        int initialIndex = currentInstrumentIndex;
        do
        {
            currentInstrumentIndex = (currentInstrumentIndex - 1 + PlayerInfoCtrl.Ins.KnapsackLst.Count) % PlayerInfoCtrl.Ins.KnapsackLst.Count;
        } while (PlayerInfoCtrl.Ins.KnapsackLst[currentInstrumentIndex].CurItemData.Type != ItemType.INSTRUMENT && currentInstrumentIndex != initialIndex);

        UpdateInstrument();
    }

    private void UpdateInstrument()
    {
        InstrumentData instrumentData = PlayerInfoCtrl.Ins.KnapsackLst[currentInstrumentIndex].CurItemData as InstrumentData;
        if (instrumentData != null)
        {
            textToMusicNotes.currentInstrumentData = instrumentData;
            instrumentIcon.sprite = instrumentData.instrument.icon;
        }
    }

    public Instrument GetCurrentInstrument()
    {
        InstrumentData instrumentData = PlayerInfoCtrl.Ins.KnapsackLst[currentInstrumentIndex].CurItemData as InstrumentData;//Cannot implicitly convert type 'ItemData' to 'InstrumentData'
        return instrumentData?.instrument;
    }
}
