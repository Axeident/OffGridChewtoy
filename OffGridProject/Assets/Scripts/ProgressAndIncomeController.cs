using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressAndIncomeController : MonoBehaviour
{
    public Text monthText;
    public Text incomeText;
    public float baseIncome = 1000f;
    public float maxSustainBasedIncome = 20000f;

    private int month;
    private float currentIncome;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        monthText.text = "Month: " + month;
        incomeText.text = "Income: " + currentIncome;
        player = gameObject.GetComponent<PlayerController>();
    }

    public void moveToNextMonth()
    {
        month += 1;
        player.changeFunds(currentIncome);
        monthText.text = "Month: " + month;
    }

    private void Update()
    {
        float additionalIncome = (player.currentSustainability * 0.01f) * maxSustainBasedIncome;
        Debug.Log(additionalIncome);
        currentIncome = baseIncome + additionalIncome;

        incomeText.text = "Income: " + currentIncome;
    }
}
