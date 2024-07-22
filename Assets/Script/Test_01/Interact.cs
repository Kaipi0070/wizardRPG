using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Ensure InteractType is correctly imported or defined in the script
public enum InteractType
{
    NONE,
    CARROT_SEED,
    // Add more types as needed
}

public class Interactable : MonoBehaviour
{
    public InteractType type;

    public void OnMouseDown()
    {
        // Check if left mouse button (button index 0) is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Find the Player object in the scene (assuming there is only one Player object)
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                // Add the interactable item to the player's inventory
                player.inventory.Add(type);

                // Log interaction for debugging purposes
                Debug.Log("Added " + type + " to inventory.");
            }

            // Destroy this GameObject (the interactable item)
            Destroy(gameObject);
            SceneManager.LoadScene("Scene 1");
        }
    }
}

