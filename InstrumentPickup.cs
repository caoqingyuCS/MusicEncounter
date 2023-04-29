using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentPickup : MonoBehaviour
{
    public InstrumentData instrumentData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Get instrument");
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                inventory.AddInstrument(instrumentData);
                // Update UI to show the collected instrument.
                Destroy(gameObject); // Destroy the pickup object
            }
        }
    }
}

