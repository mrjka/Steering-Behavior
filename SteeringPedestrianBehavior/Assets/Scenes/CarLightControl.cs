using UnityEngine;
using System.Collections;

public class CarLightControl : MonoBehaviour
{
    public bool isRed;
    public float timer;
    static Color redOn = Color.red;
    static Color redOff = Color.grey;
    static Color greenOn = Color.green;
    static Color greenOff = Color.grey;
    private MeshRenderer greenLight, yellowLight, redLight;

    public TrafficLightControl pedestrianLight;


    // Use this for initialization
    void Start()
    {
        greenLight = gameObject.transform.FindChild("pCylinder4_Traffic_Lights_Green_Light_Group_Traffic_Light_Traffic_Light_Selection_Stading_Green_Traffic_Light").GetComponent<MeshRenderer>();
        redLight = gameObject.transform.FindChild("pCylinder4_Traffic_Lights_Traffic_Light_Traffic_Light_Selection_Stading_Red_Light_Group_Red_Traffic_Light").GetComponent<MeshRenderer>();

        redLight.material.color = redOff;
        greenLight.material.color = greenOn;
    }

    // Update is called once per frame
    void Update()
    {
        if(pedestrianLight.IsRed)
        {
            isRed = false;
        }
        else
        {
            isRed = true;
        }
        timer -= Time.deltaTime;
        //Red to green
        if (isRed)
        {
            //Change colour of the light            
            redLight.material.color = redOn;
            greenLight.material.color = greenOff;
        }
        //Green to red
        else if (!isRed)
        {
            //Change colour of the light            
            redLight.material.color = redOff;
            greenLight.material.color = greenOn;
        }
    }

    public bool IsRed
    {
        get
        {
            return isRed;
        }
    }
}
