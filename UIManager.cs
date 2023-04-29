using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject actionPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            actionPanel.SetActive(!actionPanel.active);
        }
    }
}
