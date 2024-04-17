using System.Collections;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public PlayerControls playerControls;
    public AIControls[] aiControls;
    public LapManager lapTracker;
    public TricolorLights tricolorLights;
    public AudioSource audioSource;
    public AudioClip lowBeep;
    public AudioClip highBeep;
    void Awake()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        FreezePlayers(true);
    }
    public void StartGame()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        FreezePlayers(true);
        StartCoroutine("Countdown");
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);
        yield return new WaitForSeconds(1);
        Debug.Log("3");
        tricolorLights.SetProgress(1);
        audioSource.PlayOneShot(lowBeep);
        yield return new WaitForSeconds(1);
        Debug.Log("2");
        tricolorLights.SetProgress(2);
        audioSource.PlayOneShot(lowBeep);
        yield return new WaitForSeconds(1);
        Debug.Log("1");
        tricolorLights.SetProgress(3);
        audioSource.PlayOneShot(lowBeep);
        yield return new WaitForSeconds(1);
        Debug.Log("GO");
        tricolorLights.SetProgress(4);
        audioSource.PlayOneShot(highBeep);
        StartRacing();
        yield return new WaitForSeconds(2f);
        tricolorLights.SetAllLightsOff();
    }
    public void StartRacing()
    {
        FreezePlayers(false);
    }
    void FreezePlayers(bool freeze)
    {
        if (freeze)
        {
            playerControls.enabled = false;
            aiControls[0].enabled = false;
        }
        else
        {
            playerControls.enabled = true;
            aiControls[0].enabled = true;
        }
    }
}