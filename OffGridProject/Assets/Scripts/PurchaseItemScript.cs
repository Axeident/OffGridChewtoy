using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseItemScript : MonoBehaviour
{
    public Item thisItem;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>();
    }

    public void buyItem()
    {
        if(playerController.getFunds() >= thisItem.price)
        {
            playerController.changeFunds(thisItem.price * -1f);

            switch (thisItem.utilityType)
            {
                case Item.utilites.Power:
                    playerController.changePower(thisItem.utilityValue);
                    break;
                case Item.utilites.Water:
                    playerController.changeWater(thisItem.utilityValue);
                    break;
                case Item.utilites.Food:
                    playerController.changeFood(thisItem.utilityValue);
                    break;
            }


            thisItem.model.SetActive(true);
            transform.Find("PurchaseButton").GetComponentInChildren<Text>().text = "Purchased";
            transform.Find("PurchaseButton").GetComponent<Button>().interactable = false;
        }
        
    }
}
