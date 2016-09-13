using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class PedestrainZebraCrossing : MonoBehaviour {
    //Current position of the person
    public double X;
    public double Z;
    Vector3 position;
    public bool isRed;
    TrafficLightControl traffic;
    AutonomousVehicle walking;
    [SerializeField] public float timer;
    [SerializeField] public double waitAtCrossingXUp;
    [SerializeField] public double waitAtCrossingXDown;
    [SerializeField] public double waitAtCrossingZUp;
    [SerializeField] public double waitAtCrossingZDown;

    // Use this for initialization
    void Start () {
        position = gameObject.transform.position;
        X = position.x;
        Z = position.z;

        GameObject trafficLight = GameObject.Find("TrafficLight");
        traffic = trafficLight.GetComponent<TrafficLightControl>();

        walking = gameObject.GetComponent<AutonomousVehicle>();

        if(timer > 0)
        {
            walking.CanMove = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        position = gameObject.transform.position;
        X = position.x;
        Z = position.z;
        
        isRed = traffic.IsRed;
        if (X > waitAtCrossingXDown && X < waitAtCrossingXUp && Z < waitAtCrossingZUp && Z > waitAtCrossingZDown && isRed)
        {
            walking.CanMove = false;           
        }
        else
        {
            walking.CanMove = true;
        }

        if (timer > 0)
        {
            walking.CanMove = false;
            timer -= Time.deltaTime;
        }
    }
}
