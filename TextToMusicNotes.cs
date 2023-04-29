using System.Collections.Generic;
using UnityEngine;

public class TextToMusicNotes : MonoBehaviour
{
    public AudioSource audioSource;
    private float friendly;
    private float sensitive;
    private int characteristic;
    private int musicGenre;
    public InstrumentData currentInstrumentData;
    public InstrumentManager instrumentManager;
    private Dictionary<char, int> noteMappings;
    private void Awake()
    {
        noteMappings = new Dictionary<char, int>
        {
            {'a', 0}, {'b', 1}, {'c', 2}, {'d', 3}, {'e', 4}, {'f', 5}, {'g', 6}, {'h', 7}, {'i', 8}, {'j', 9}, {'k', 10}, {'l', 11},
            {'m', 12}, {'n', 13}, {'o', 14}, {'p', 15}, {'q', 16}, {'r', 17}, {'s', 18}, {'t', 19}, {'u', 20}, {'v', 21}, {'w', 22}, {'x', 23}, {'y', 24}, {'z', 25}
        };

        audioSource = GetComponent<AudioSource>();
        // Load the values from PlayerPrefs
        friendly = PlayerPrefs.GetFloat("Friendly");
        sensitive = PlayerPrefs.GetFloat("Sensitiveness");
        characteristic = PlayerPrefs.GetInt("Characteristic");
        musicGenre = PlayerPrefs.GetInt("MusicGenre");
    }

   public void PlayNoteForCharacter(char character)
    {
        character = char.ToLower(character);
        if (noteMappings.ContainsKey(character))
        {
            int noteIndex = noteMappings[character];
            Instrument currentInstrument = instrumentManager.GetCurrentInstrument();

            if (currentInstrument == null)
            {
                Debug.LogWarning("Current instrument is not set. Cannot play a note.");
                return;
            }

            AudioClip note = currentInstrument.notes[noteIndex];
            audioSource.PlayOneShot(note);
        }
    }
}
