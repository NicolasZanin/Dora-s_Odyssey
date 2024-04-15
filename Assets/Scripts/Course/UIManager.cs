using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateLapText(string message)
    {
        textMeshProUGUI.text = message;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
