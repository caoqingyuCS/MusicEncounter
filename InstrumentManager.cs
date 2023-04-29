using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentManager : MonoBehaviour
{
    public Inventory inventory;
    public Image instrumentIcon;
    public TextToMusicNotes textToMusicNotes;
    private int currentInstrumentIndex;
    public InstrumentData instrumentData;
    public void SwitchToInstrument(int index)
    {
        if (index >= 0 && index < inventory.collectedInstruments.Count)
        {
            textToMusicNotes.currentInstrumentData = inventory.collectedInstruments[index];
            // Update the UI to show the selected instrument.
        }
    }

    private void Start()
    {
        currentInstrumentIndex = 0;
        UpdateInstrument();
    }

    public void SelectNextInstrument()
    {
        currentInstrumentIndex = (currentInstrumentIndex + 1) % instrumentData.instruments.Count;
        UpdateInstrument();
    }

    public void SelectPreviousInstrument()
    {
        currentInstrumentIndex = (currentInstrumentIndex - 1 + instrumentData.instruments.Count) % instrumentData.instruments.Count;
        UpdateInstrument();
    }

    private void UpdateInstrument()
    {
        instrumentIcon.sprite = instrumentData.instruments[currentInstrumentIndex].icon;
        textToMusicNotes.currentInstrumentData = instrumentData;
    }


    public Instrument GetCurrentInstrument()
    {
        return instrumentData.instruments[currentInstrumentIndex];
    }
}
