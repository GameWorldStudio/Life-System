using System;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameFinish = false;

    [SerializeField] private static int playerScore;

    [SerializeField] private static int playerMoney;

    public static UIManager UIManager;

    public static GameManager game { get; set; }

    private void Awake()
    {
        UIManager = FindObjectOfType<UIManager>();

        if(game != null)
        {
            Destroy(this);
        }

        game = this;
    }

    public static void AddPlayerScore(int score)
    {
        playerScore += score;
        playerMoney += score;

        try
        {
            UIManager.ShowScore(score);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void RemovePlayerMoney(int value)
    {
        playerMoney -= value;
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public int GetPlayerMoney()
    {
        return playerMoney;
    }
}
