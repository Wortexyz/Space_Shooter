using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float movespeed = 30f;
    [SerializeField] float  xRotation =20f ;
     [SerializeField] float zRotation = 40f;
    [SerializeField]   float RotationSpeed =30f;
    Vector2 movementValue;
    [Header("Firing Settings")]
    [SerializeField] RectTransform CrossHairTransform;
    bool isFiring = false;
   [SerializeField] GameObject[] lasers;
    [SerializeField]Transform TargetPosition;
    [SerializeField] float targetDistace = 25f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessRotation();
        ProcessFiring();
        ProcessTarget();
        ProcessAimimg();

    }
 public void OnMove(InputValue value)
    {
         movementValue = value.Get<Vector2>();
    }
     void ProcessMovement()
    {
        float zoffset = movespeed * -movementValue.x * Time.deltaTime;
        float yoffset = movespeed * movementValue.y * Time.deltaTime;
        transform.localPosition = new Vector3(0, Mathf.Clamp( transform.localPosition.y + yoffset , -3.25f,14), Mathf.Clamp(transform.localPosition.z + zoffset, -15f, 16));
    }

    void ProcessRotation()
    {
        Quaternion targetRotationSide = Quaternion.Euler ( xRotation * -movementValue.x, 0, zRotation * movementValue.y);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotationSide, RotationSpeed *Time.deltaTime);

    }
    public void OnFire(InputValue value)
    {

        isFiring = value.isPressed;
       

    }
    void ProcessFiring()
    {
        
        
             Debug.Log("mouse pressing");

        foreach (GameObject laser in lasers) {
            //we can use "var" instead of "ParticleSystem.EmissionModule emisiionModule"
            ParticleSystem.EmissionModule emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
        
       
    }

    void ProcessTarget()
    {
        Vector3 TargetBallPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistace);
        TargetPosition.position = Camera.main.ScreenToWorldPoint(TargetBallPoint);

    }

    void ProcessAimimg()
    {
        CrossHairTransform.position=Input.mousePosition;

        foreach (GameObject laser in lasers)
        {
            Vector3 AimimgBallPoint = TargetPosition.position - this.transform.position;
            Quaternion TargetRotaion = Quaternion.LookRotation(AimimgBallPoint);
            laser.transform.rotation = TargetRotaion;

        }

    }
   
}
