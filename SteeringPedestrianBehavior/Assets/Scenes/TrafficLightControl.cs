using UnityEngine;
using System.Collections;

public class TrafficLightControl : MonoBehaviour
{
    private bool isRed;
    public float timer;
    static Color redOn = Color.red;
    static Color redOff = Color.grey;
    static Color greenOn = Color.green;
    static Color greenOff = Color.grey;
    public MeshRenderer greenLight, redLight;


    // Use this for initialization
    void Start()
    {
        isRed = true;
        timer = 10.0f;               //Timer 
        
        greenLight = gameObject.transform.FindChild("pCylinder4_Traffic_Lights_Green_Light_Group_Traffic_Light_Traffic_Light_Selection_Stading_Green_Traffic_Light").GetComponent<MeshRenderer>();
        redLight = gameObject.transform.FindChild("pCylinder4_Traffic_Lights_Traffic_Light_Traffic_Light_Selection_Stading_Orange_Light_Group_Yellow_Traffic_Light").GetComponent<MeshRenderer>();

        redLight.material.color = redOn;
        greenLight.material.color = greenOff;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && isRed)
        {
            isRed = false;

            //Change colour of the light            
            redLight.material.color = redOff;
            greenLight.material.color = greenOn;
            
            timer = 5.0f;
        }
        else if (timer <= 0 && !isRed)
        {
            isRed = true;

            //Change colour of the light            
            redLight.material.color = redOn;
            greenLight.material.color = greenOff;

            timer = 10.0f;
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
