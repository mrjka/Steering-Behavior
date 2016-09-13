using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DriveCar : MonoBehaviour {
	private Vector3 position;
    public float X,Z;
    public Vector3 destination;
	public float speed;
    public float timer;
    private string carName;
    private int prevCarName;
    public bool carMoving;

    [SerializeField]
    public double waitAtTrafficXUp;
    [SerializeField]
    public double waitAtTrafficXDown;
    [SerializeField]
    public double waitAtTrafficZUp;
    [SerializeField]
    public double waitAtTrafficZDown;

    public CarLightControl carTraffic;
    public bool isRed;

    public GameObject prevCar;
    public bool prevCarMoving;
    public float prevCarDist;

    public bool thisSide;

    // Use this for initialization
    void Start () {
        carName = gameObject.name;
        if(int.Parse(carName) > 1)
        {
            prevCarName = int.Parse(carName) - 1;
        }
        carMoving = true;

        prevCarMoving = true;

        position = gameObject.transform.position;
        if (position.x > destination.x)
        {
            thisSide = false;
        }
        else
        {
            thisSide = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        isRed = carTraffic.IsRed;
        X = gameObject.transform.position.x;
        Z = gameObject.transform.position.z;
        if (timer <= 0)
        {
            carMoving = true;
            position = gameObject.transform.position;

            //If previous car is standing still, then stand still
            if (prevCarName != 0 && prevCarName != 15)
            {
                prevCar = GameObject.Find(prevCarName + "");
                prevCarMoving = prevCar.GetComponent<DriveCar>().carMoving;
                prevCarDist = Mathf.Abs(gameObject.transform.position.x - prevCar.transform.position.x);

                if (prevCarDist <= 5 && !prevCarMoving)
                {
                    prevCarMoving = false;
                }
                else if(prevCarDist > 5)
                {
                    prevCarMoving = true;
                }
            }


            //If we have reached the destination, then stand still

            if (position.x > destination.x && thisSide)
            {
                speed = 0;
            }
            else if (position.x < destination.x && !thisSide)
            {
                speed = 0;
            }
            else if (X > waitAtTrafficXDown && X < waitAtTrafficXUp && Z < waitAtTrafficZUp && Z > waitAtTrafficZDown && isRed)
            {
                carMoving = false;
            } else if(!prevCarMoving)
            {
                carMoving = false;
            }
            else
            {
                carMoving = true;
                float noOfFrames, diffX, diffZ;
                diffX = Mathf.Abs(destination.x - position.x);
                diffZ = Mathf.Abs(destination.z - position.z);
                noOfFrames = diffX / speed;

                float newZ, newX;

                if (position.z > destination.z)
                {
                    newZ = position.z - (diffZ / noOfFrames);
                }
                else
                {
                    newZ = position.z + (diffZ / noOfFrames);
                }

                if (position.x > destination.x)
                {
                    newX = position.x - (diffX / noOfFrames);
                }
                else
                {
                    newX = position.x + (diffX / noOfFrames);
                }

                transform.position = new Vector3(newX, position.y, newZ);
            }
        }
        else
        {
            carMoving = false;
            timer -= Time.deltaTime;
        }
    }
}
