using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movespeed =30f;
    Vector2 movementValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();

    }

    private void ProcessMovement()
    {
        float zoffset = movespeed * -movementValue.x * Time.deltaTime;
        float yoffset = movespeed * movementValue.y * Time.deltaTime;
        transform.localPosition = new Vector3(0, Mathf.Clamp( transform.localPosition.y + yoffset , -3.25f,14), Mathf.Clamp(transform.localPosition.z + zoffset, -15f, 16));
    }

    public void OnMove(InputValue value)
    {
         movementValue = value.Get<Vector2>();
    }
}
