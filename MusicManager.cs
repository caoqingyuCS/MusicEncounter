using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> personaMusicList; // Assign your persona music clips in the Unity Inspector

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Load the stored values
        float friendly = PlayerPrefs.GetFloat("Friendly", 0);
        float sensitive = PlayerPrefs.GetFloat("Sensitiveness", 0);
        int characteristic = PlayerPrefs.GetInt("Characteristic", 0);
        int musicGenre = PlayerPrefs.GetInt("MusicGenre", 0);

        // Determine the persona music
        AudioClip personaMusic = ChoosePersonaMusic(friendly, sensitive, characteristic, musicGenre);

        // Play the persona music
        audioSource.clip = personaMusic;
        audioSource.Play();
    }

    private AudioClip ChoosePersonaMusic(float friendly, float sensitive, int characteristic, int musicGenre)
    {
        // Implement your logic to determine the appropriate persona music based on the stored values
        // This is just a simple example
        int musicIndex = 0;

        if (musicGenre == 0) // Example genre: Rock
        {
            if (characteristic == 0) // Example characteristic: Funny
            {
                musicIndex = 0; // Rock + Funny combination
            }
            else
            {
                musicIndex = 1; // Rock + another characteristic combination
            }
        }
        else // Example genre: Pop
        {
            if (characteristic == 0) // Example characteristic: Funny
            {
                musicIndex = 2; // Pop + Funny combination
            }
            else
            {
                musicIndex = 3; // Pop + another characteristic combination
            }
        }
        Debug.Log("Current music index: " + musicIndex);
        Debug.Log("Friendly: " + friendly + " Sensitive: " + sensitive + " Characteristic: " +characteristic + " Genre: " + musicGenre );
        return personaMusicList[musicIndex];
    }
}
