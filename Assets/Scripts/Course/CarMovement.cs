using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody rg;
    public float forwardMoveSpeed;
    public float backwardMoveSpeed;
    public float steerSpeed;

    private Vector2 _input;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        // Accelerate
        float speed = _input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        
        if (_input.y == 0)
            speed = 0;
        
        rg.AddForce(transform.forward * speed, ForceMode.Acceleration);
        
        
        // Steer
        float rotation = _input.x * steerSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, rotation, 0, Space.World);
    }

    public void SetInputs(Vector2 input)
    {
        _input = input;
    }
}
