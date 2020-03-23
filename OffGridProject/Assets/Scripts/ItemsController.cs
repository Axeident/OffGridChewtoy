using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsController : MonoBehaviour
{
    public GameObject panelContainer;
    public GameObject storeUICanavs;
    private GameObject powerPanel;
    private GameObject waterPanel;
    private GameObject foodPanel;
    public GameObject UIItemPrefab;
    public Item[] items;

    // Start is called before the first frame update
    void Start()
    {
        powerPanel = panelContainer.transform.Find("PowerPanel").gameObject;
        waterPanel = panelContainer.transform.Find("WaterPanel").gameObject;
        foodPanel = panelContainer.transform.Find("FoodPanel").gameObject;

        foreach (Item asset in items)
        {
            GameObject newUIItem = Instantiate(UIItemPrefab) as GameObject;
            newUIItem.transform.Find("ItemName").GetComponent<Text>().text = asset.itemName;
            newUIItem.transform.Find("ItemDescription").GetComponent<Text>().text = asset.description;
            newUIItem.transform.Find("CostText").GetComponent<Text>().text = asset.price.ToString();
            newUIItem.GetComponent<PurchaseItemScript>().thisItem = asset;

            switch (asset.utilityType)
            {
                case Item.utilites.Power:
                    newUIItem.transform.parent = powerPanel.transform; 
                    break;

                case Item.utilites.Water:
                    newUIItem.transform.parent = waterPanel.transform;
                    break;

                case Item.utilites.Food:
                    newUIItem.transform.parent = foodPanel.transform;
                    break;
            }
        }

        // needed to preload the items properly
        storeUICanavs.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
