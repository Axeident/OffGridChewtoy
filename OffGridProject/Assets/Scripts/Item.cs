using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public enum utilites { Power, Water, Food };

    public string itemName;
    public utilites utilityType;
    public string description;
    public float price;

    public int utilityValue;

    public GameObject model;

    public Item(string namein, int utility, string descrpin, float pricein)
    {
        itemName = namein;
        switch (utility)
        {
            case 0:
                utilityType = utilites.Power;
                break;
            case 1:
                utilityType = utilites.Water;
                break;
            case 2:
                utilityType = utilites.Food;
                break;
        }
        description = descrpin;
        price = pricein;
    }
}
