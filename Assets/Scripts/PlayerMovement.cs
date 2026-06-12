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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessRotation();

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

   
}
