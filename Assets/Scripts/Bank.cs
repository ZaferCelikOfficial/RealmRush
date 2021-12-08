using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int StartingBalance = 150;
    [SerializeField] int CurrentBalance;
    [SerializeField] TextMeshProUGUI GoldText;
    public int GetCurrentBalance { get { return CurrentBalance; } }

    void Awake()
    {
        CurrentBalance = StartingBalance;
        GoldText.text = "Gold : " + CurrentBalance.ToString() ;
    }
    public void Deposit(int amount)
    {
        CurrentBalance += Mathf.Abs(amount);
        GoldText.text = "Gold : " + CurrentBalance.ToString();
    }
    public void Withdrawal(int amount)
    {
        CurrentBalance -= Mathf.Abs(amount);
        GoldText.text = "Gold : " + CurrentBalance.ToString();
        if (CurrentBalance < 0)
        {
            ReloadLevel();
        }
    }
    void ReloadLevel()
    {
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex);
    }
}
