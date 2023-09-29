using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
   
    public Button deleteButton;
    public Button createButton;

    private void Start()
    {
       
        deleteButton.onClick.AddListener(DeleteProjectile);
        createButton.onClick.AddListener(CreateNewProjectile);
    }

    private void DeleteProjectile()
    {
        
        Rigidbody currentProjectile = FindObjectOfType<Rigidbody>();
        if (currentProjectile != null)
        {
            Destroy(currentProjectile.gameObject);
        }
    }

    private void CreateNewProjectile()
    {
        
        Rigidbody existingProjectile = FindObjectOfType<Rigidbody>();
        if (existingProjectile == null)
        {
            
        }
    }
}
