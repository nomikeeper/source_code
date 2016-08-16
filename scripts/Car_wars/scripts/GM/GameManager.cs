using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int c_NumRoundsToWin = 5;        
    public float c_StartDelay = 3f;         
    public float c_EndDelay = 3f;           
    public CameraControl c_CameraControl;   
    public Text c_MessageText;              
    public GameObject c_CarPrefab;         
    public CarManager[] c_Cars;           


    private int c_RoundNumber;              
    private WaitForSeconds c_StartWait;     
    private WaitForSeconds c_EndWait;       
    private CarManager c_RoundWinner;
    private CarManager c_GameWinner;       


    private void Start()
    {
        c_StartWait = new WaitForSeconds(c_StartDelay);
        c_EndWait = new WaitForSeconds(c_EndDelay);

        SpawnAllTanks();
        SetCameraTargets();

        StartCoroutine(GameLoop());
    }


    private void SpawnAllTanks()
    {
        for (int i = 0; i < c_Cars.Length; i++)
        {
            c_Cars[i].c_Instance =
                Instantiate(c_CarPrefab, c_Cars[i].c_SpawnPoint.position, c_Cars[i].c_SpawnPoint.rotation) as GameObject;
            c_Cars[i].c_PlayerNumber = i + 1;
            c_Cars[i].Setup();
        }
    }


    private void SetCameraTargets()
    {
        Transform[] targets = new Transform[c_Cars.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = c_Cars[i].c_Instance.transform;
        }

        c_CameraControl.m_Targets = targets;
    }


    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

        if (c_GameWinner != null)
        {
            SceneManager.GetActiveScene();
        }
        else
        {
            StartCoroutine(GameLoop());
        }
    }


    private IEnumerator RoundStarting()
    {
        ResetAllTanks();
        DisableTankControl();
        
        c_CameraControl.SetStartPositionAndSize();
        c_RoundNumber++;
        c_MessageText.text = "Round: " + c_RoundNumber;
        yield return c_StartWait;
    }


    private IEnumerator RoundPlaying()
    {
        EnableTankControl();

        c_MessageText.text = string.Empty;

        while(!OneTankLeft())
        {
            yield return null;
        }
        
    }


    private IEnumerator RoundEnding()
    {
        DisableTankControl();

        c_RoundWinner = null;
        c_RoundWinner = GetRoundWinner();

        if (c_RoundWinner != null)
            c_RoundWinner.c_Wins++;

        c_GameWinner = GetGameWinner();

        string message = EndMessage();
        c_MessageText.text = message;

        yield return c_EndWait;
    }


    private bool OneTankLeft()
    {
        int numTanksLeft = 0;

        for (int i = 0; i < c_Cars.Length; i++)
        {
            if (c_Cars[i].c_Instance.activeSelf)
                numTanksLeft++;
        }

        return numTanksLeft <= 1;
    }


    private CarManager GetRoundWinner()
    {
        for (int i = 0; i < c_Cars.Length; i++)
        {
            if (c_Cars[i].c_Instance.activeSelf)
                return c_Cars[i];
        }

        return null;
    }


    private CarManager GetGameWinner()
    {
        for (int i = 0; i < c_Cars.Length; i++)
        {
            if (c_Cars[i].c_Wins == c_NumRoundsToWin)
                return c_Cars[i];
        }

        return null;
    }


    private string EndMessage()
    {
        string message = "DRAW!";

        if (c_RoundWinner != null)
            message = c_RoundWinner.c_ColoredPlayerText + " WINS THE ROUND!";

        message += "\n\n\n\n";

        for (int i = 0; i < c_Cars.Length; i++)
        {
            message += c_Cars[i].c_ColoredPlayerText + ": " + c_Cars[i].c_Wins + " WINS\n";
        }

        if (c_GameWinner != null)
            message = c_GameWinner.c_ColoredPlayerText + " WINS THE GAME!";

        return message;
    }


    private void ResetAllTanks()
    {
        for (int i = 0; i < c_Cars.Length; i++)
        {
            c_Cars[i].Reset();
        }
    }


    private void EnableTankControl()
    {
        for (int i = 0; i < c_Cars.Length; i++)
        {
            c_Cars[i].EnableControl();
        }
    }


    private void DisableTankControl()
    {
        for (int i = 0; i < c_Cars.Length; i++)
        {
            c_Cars[i].DisableControl();
        }
    }
}