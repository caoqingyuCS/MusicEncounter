using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoleSelectionController : MonoBehaviour
{
    public ToggleGroup musicGenre,characteristic;
    public Slider friendlySlider;
    public Slider sensitiveSlider;
    public Button submitButton;

    private void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
    }

    private void OnSubmit()
    {
        // Store the user selections
        PlayerPrefs.SetFloat("Friendly", friendlySlider.value);
        PlayerPrefs.SetFloat("Sensitiveness", sensitiveSlider.value);
        int characteristicIndex = GetSelectedToggleIndex(characteristic);
        PlayerPrefs.SetInt("Characteristic", characteristicIndex);
        int musicGenreIndex = GetSelectedToggleIndex(musicGenre);
        PlayerPrefs.SetInt("MusicGenre", musicGenreIndex);

        // Load the main game scene
        SceneManager.LoadScene("Main_Music");
    }

    private int GetSelectedToggleIndex(ToggleGroup toggleGroup)
    {
        int index = 0;
        var toggles = toggleGroup.transform.GetComponentsInChildren<Toggle>();
        foreach (var toggle in toggles)
        {
            if (toggle.isOn)
            {
                break;
            }
            index++;
        }
        return index;
    }

}
