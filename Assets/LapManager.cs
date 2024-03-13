using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LapManager : MonoBehaviour
{

    public List<CheckPoint> checkpoints;
    private List<PlayerRank> playerRanks = new List<PlayerRank>();
    public UIManager uIManager;
    public int totalLaps = 3;
    private PlayerRank mainPlayerRank;
    public UnityEvent onPlayerFinished = new UnityEvent();
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (CarIdentity carIdentity in GameObject.FindObjectsOfType<CarIdentity>())
        {
            playerRanks.Add(new PlayerRank(carIdentity));
        }
        ListenCheckpoints(true);
        uIManager.UpdateLapText("Lap " + playerRanks[0].lapNumber + " / " + totalLaps);
        mainPlayerRank = playerRanks.Find(player => player.identity.gameObject.CompareTag("Player"));
    }
    
    private void ListenCheckpoints(bool subscribe)
    {
        foreach (CheckPoint checkpoint in checkpoints)
        {
            if (subscribe)
                checkpoint.onCheckPointEnter.AddListener(CheckpointActivated);
            else
                checkpoint.onCheckPointEnter.RemoveListener(CheckpointActivated);
        }
    }

    public void CheckpointActivated(CarIdentity car, CheckPoint checkpoint)
    {
        PlayerRank player = playerRanks.Find((rank) => rank.identity == car);
        int checkpointNumber = checkpoints.IndexOf(checkpoint);
        
        if (checkpointNumber != -1 && player != null)
        {
            if (!player.hasFinished)
            {
                int checkPointNumber = checkpoints.IndexOf(checkpoint);
                bool startingFirstLap = checkPointNumber == 0 && player.lastCheckpoint == -1;
                bool lapIsFinished = checkpointNumber == 0 && player.lastCheckpoint >= checkpoints.Count - 1;

                if (startingFirstLap || lapIsFinished)
                {
                    player.lapNumber += 1;
                    player.lastCheckpoint = 0;

                    if (player.lapNumber > totalLaps)
                    {
                        if (player.rank == 1)
                        {
                            Debug.Log(player.identity.drivername + " won");
                            uIManager.UpdateLapText(player.identity.drivername + " won");
                        }
                        else if (player == mainPlayerRank)
                        {
                            uIManager.UpdateLapText("\nYou finished in " + mainPlayerRank.rank + " place");
                        }

                        if (player == mainPlayerRank)
                            onPlayerFinished.Invoke();
                    }
                    else {
                        Debug.Log(player.identity.drivername + ": lap " + player.lapNumber);
                        if (car.gameObject.CompareTag("Player"))
                            uIManager.UpdateLapText("Lap " + player.lapNumber + " / " + totalLaps);
                    }
                }
                else if (checkpointNumber == player.lastCheckpoint + 1)
                {
                    player.lastCheckpoint += 1;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
