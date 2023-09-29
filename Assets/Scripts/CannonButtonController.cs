using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonButtonController : MonoBehaviour
{
    public CannonController cannonController; 

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(FireCannon); 
        }
    }

    // Método que se llama cuando se presiona el botón.
    void FireCannon()
    {
       
        cannonController.FireProjectile();
    }
}
