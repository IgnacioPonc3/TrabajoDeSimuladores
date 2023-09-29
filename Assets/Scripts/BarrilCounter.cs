using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BarrilCounter : MonoBehaviour
{
    public int barrelCount = 0;
    public TextMeshProUGUI barrelCountText; 


    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (barrelCountText != null)
        {
            barrelCountText.text = "Contador de Barriles: " + barrelCount;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barril"))
        {
            barrelCount++;

            Debug.Log("Contador de Barriles: " + barrelCount);
        }
    }
}
