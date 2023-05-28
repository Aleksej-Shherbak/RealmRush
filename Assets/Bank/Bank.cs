using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startedBalance = 150;
    [SerializeField] private int currentBalance = 0;
    [SerializeField] private TextMeshProUGUI display;

    public int CurrentBalance => currentBalance;
    
    private void Awake()
    {
        currentBalance = startedBalance;
        UpdateDisplay(currentBalance);
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay(currentBalance);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);

        if (currentBalance < 0)
        {
            ReloadScene();
            return;
        }

        
        UpdateDisplay(currentBalance);
    }

    void ReloadScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void UpdateDisplay(int amount)
    {
        display.text = $"Gold: {amount}";

    }
}