using System;
using UnityEngine;

[Serializable]
public class CarManager 
{
    public Color c_PlayerColor;            
    public Transform c_SpawnPoint;         
    [HideInInspector] public int c_PlayerNumber;             
    [HideInInspector] public string c_ColoredPlayerText;
    [HideInInspector] public GameObject c_Instance;          
    [HideInInspector] public int c_Wins;                     


    private Movement c_Movement;       
    private CarShooting c_Shooting;
    private GameObject c_CanvasGameObject;


    public void Setup()
    {
        c_Movement = c_Instance.GetComponent<Movement>();
        c_Shooting = c_Instance.GetComponent<CarShooting>();
        c_CanvasGameObject = c_Instance.GetComponentInChildren<Canvas>().gameObject;

        c_Movement.c_playerNumber = c_PlayerNumber;
        c_Shooting.c_playerNumber = c_PlayerNumber;

        c_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(c_PlayerColor) + ">PLAYER " + c_PlayerNumber + "</color>";

        MeshRenderer[] renderers = c_Instance.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            if(renderers[i].name == "main_col")
            {
                renderers[i].material.color = c_PlayerColor;
            }
        }
    }


    public void DisableControl()
    {
        c_Movement.enabled = false;
        c_Shooting.enabled = false;

        c_CanvasGameObject.SetActive(false);
    }


    public void EnableControl()
    {
        c_Movement.enabled = true;
        c_Shooting.enabled = true;

        c_CanvasGameObject.SetActive(true);
    }


    public void Reset()
    {
        c_Instance.transform.position = c_SpawnPoint.position;
        c_Instance.transform.rotation = c_SpawnPoint.rotation;

        c_Instance.SetActive(false);
        c_Instance.SetActive(true);
    }
}
