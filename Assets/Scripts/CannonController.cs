using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CannonController : MonoBehaviour
{

    public Transform cannonTransform; 
    public Transform projectileSpawnPoint; 
    public Rigidbody projectilePrefab; 
    public Slider horizontalAngleSlider; 
    public Slider verticalAngleSlider;
    public Slider launchForceSlider;
    public float launchForce = 10f;
    public float minLaunchForce = 5f;
    public float maxLaunchForce = 20f;
    private Rigidbody currentProjectile;
    public TextMeshProUGUI horizontalAngleText; 
    public TextMeshProUGUI verticalAngleText;
    public TextMeshProUGUI launchForceText;
    public TextMeshProUGUI projectileMassText;
    public Slider projectileMassSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        currentProjectile.gameObject.SetActive(false);

        horizontalAngleSlider.onValueChanged.AddListener(UpdateHorizontalAngleText);
        verticalAngleSlider.onValueChanged.AddListener(UpdateVerticalAngleText);

        launchForceSlider.minValue = minLaunchForce;
        launchForceSlider.maxValue = maxLaunchForce;
        launchForceSlider.value = minLaunchForce;

    }


    void UpdateProjectileMass()
    {
        float mass = projectileMassSlider.value;

        projectileMassText.text = "Masa del Proyectil: " + mass.ToString("F1"); 

        if (currentProjectile != null)
        {
            currentProjectile.mass = mass;
        }
    }

    void Update()
    {
        UpdateCannonAngulo();
        UpdateLaunchForce();
        UpdateProjectileMass();
    }

    private void UpdateHorizontalAngleText(float value)
    {
        horizontalAngleText.text = "Ángulo Horizontal: " + value.ToString("F1"); 
    }


    void UpdateLaunchForce()
    {
        launchForce = launchForceSlider.value;
        launchForceText.text = "Fuerza de Lanzamiento: " + launchForce.ToString("F1");
    }

    private void UpdateVerticalAngleText(float value)
    {
        verticalAngleText.text = "Ángulo Vertical: " + value.ToString("F1"); 
    }




    void UpdateCannonAngulo()
    {
        float horizontalAngulo = horizontalAngleSlider.value;
        float verticalAngulo = verticalAngleSlider.value;

        Vector3 launchDirection = cannonTransform.forward;
        currentProjectile.transform.rotation = Quaternion.LookRotation(launchDirection);

        Vector3 newRotation = new Vector3(verticalAngulo, horizontalAngulo, 0f);
        cannonTransform.eulerAngles = newRotation;
    }

    public void FireProjectile()
    {
        currentProjectile.gameObject.SetActive(true);

        Vector3 launchDirection = cannonTransform.forward;

        Debug.DrawRay(projectileSpawnPoint.position, cannonTransform.forward * 10f, Color.red, 2f);

        currentProjectile.AddForce(launchDirection * launchForce, ForceMode.Impulse);
    }
}
