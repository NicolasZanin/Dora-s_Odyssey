using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{ 
    public UnityEvent<CarIdentity, CheckPoint> onCheckPointEnter;

    private void OnTriggerEnter(Collider collider)
    {
        CarIdentity carIdentity = collider.gameObject.GetComponent<CarIdentity>();
        if (carIdentity != null)
        {
            onCheckPointEnter.Invoke(carIdentity, this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
