using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    private float _inputY;
    private float _inputX;
    private Vector2 _vector;
    public UnityEvent<Vector2> onInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _inputY = Input.GetAxis("Vertical");
        _inputX = Input.GetAxis("Horizontal");
        _vector = new Vector2(_inputX, _inputY).normalized;
        onInput.Invoke(_vector);
    }
}
