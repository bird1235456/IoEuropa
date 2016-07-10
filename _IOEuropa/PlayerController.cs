using UnityEngine;
using System.Collections;
[System.Serializable]
//public class Boundry { public float xMin, xMax, zMin, zMax; }
public class PlayerController : MonoBehaviour
{
    public float speed;
    //public Boundry boundry;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    float rotationY = 1F;
    void Update()


    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse Z") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;


            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, 0, Input.GetAxis("Mouse X") * sensitivityX);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;


            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

























    void FixedUpdate()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject clone = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
            GetComponent<AudioSource>().Play();
        }








        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        //rigidbody.velocity = movement;
        GetComponent<Rigidbody>().velocity = movement * speed;
        //GetComponent<Rigidbody>().position = new Vector3;
        //      (Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundry.xMin, boundry.xMax), 
        //    0.0f,
        //  Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundry.zMin, boundry.zMax));


        //GetComponent<Rigidbody>().rotation = Quaternion.Euler(270.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }




}
