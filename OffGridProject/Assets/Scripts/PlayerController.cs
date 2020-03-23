using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject PlayerUI;
    private Slider PowerSlider;
    private Slider WaterSlider;
    private Slider FoodSlider;
    private Text FundsText;
    public Text ProgressText;

    public int goalPower = 100;
    public int goalWater = 100;
    public int goalFood = 100;

    private int startPower = 0;
    private int startWater = 0;
    private int startFood = 0;

    private int currentPower = 0;
    private int currentWater = 0;
    private int currentFood = 0;

    public float startFunds = 100000.0f;
    private float currentFunds;


    // Start is called before the first frame update
    void Start()
    {
        PowerSlider = PlayerUI.transform.Find("PowerSlider").GetComponent<Slider>();
        WaterSlider = PlayerUI.transform.Find("WaterSlider").GetComponent<Slider>();
        FoodSlider = PlayerUI.transform.Find("FoodSlider").GetComponent<Slider>();
        FundsText = PlayerUI.transform.Find("FundsText").GetComponent<Text>();
        //ProgressText = PlayerUI.transform.parent.Find("Progresstext").GetComponent<Text>();

        currentPower = startPower;
        currentWater = startWater;
        currentFood = startFood;
        currentFunds = startFunds;

        PowerSlider.maxValue = goalPower;
        WaterSlider.maxValue = goalWater;
        FoodSlider.maxValue = goalFood;

    }

    public void changePower(int amount)
    {
        currentPower += amount;
    }

    public void changeWater(int amount)
    {
        currentWater += amount;
    }
    
    public void changeFood(int amount)
    {
        currentFood += amount;
    }

    public float getFunds() {
        return currentFunds;
    }

    public void changeFunds(float amount)
    {
        currentFunds += amount;
    }

    // Update is called once per frame
    void Update()
    {
        PowerSlider.value = currentPower;
        WaterSlider.value = currentWater;
        FoodSlider.value = currentFood;
        FundsText.text = "Available Funds: " + currentFunds.ToString();
        float sustainability = (((currentPower>goalPower? 1 : currentPower / (float) goalPower) /3.0f) 
            + ((currentWater>goalWater ? 1: currentWater / (float)goalWater) / 3.0f) 
            + ((currentFood>goalFood ? 1: currentFood / (float)goalFood) / 3.0f)) * 100;
        ProgressText.text = "Currently " + sustainability.ToString() + "% Sustainable";
    }
}
