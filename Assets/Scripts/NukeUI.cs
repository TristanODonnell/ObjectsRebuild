using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NukeUI : MonoBehaviour
{

    private int nukeCount = 0;
    [SerializeField] private TextMeshProUGUI nukeUIText;

    private void OnEnable()
    {
        Pickup.OnPickup.AddListener(OnPickup);
    }

    private void OnDisable()
    {
        Pickup.OnPickup.RemoveListener(OnPickup);
    }

    private void OnPickup(Character character, Pickup pickup)
    {
        if (pickup is NukePickup && character is Player)
        {
            nukeCount++;
            UpdateNukeUI();
        }
    }


    public void UpdateNukeUI()
    {
        if (nukeUIText != null)
        {
            nukeUIText.text = "NUKES: " + nukeCount;
        }
    }
}
