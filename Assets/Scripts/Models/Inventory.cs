using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Inventory : NetworkBehaviour
{
    // где-нибудь в базе данных "public Dictionary<string, Item> itemTypes;", где Key - Item.Name, Value - implement of abstract class.
    public Dictionary<string, int> Items { get; private set; }

    private GameObject inventoryObj;
    public GameObject Container;

    protected void Start()
    {
        inventoryObj = GameObject.FindWithTag("Inventory");
        Items = new Dictionary<string, int>();
    }

    protected void Update()
    {
        // нажатие на левую клавишу мыши
        if (Input.GetMouseButtonUp(1))
        {
            // луч
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // попадает ли луч на какой-то item
            if (Physics.Raycast(ray, out hit))
            {
                var item = hit.collider.GetComponent<Item>();
                if (item != null)
                {
                    // добавляем в словарь
                    AddItem(item);
                    // удаляем с поля
                    Destroy(hit.collider.gameObject);
                }
            }
        }

//        Debug.Log("Hello, Update!");
        // открыть и загрузить иконки по путям или закрыть инвентарь
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("I'm from Inventory!");
            if (inventoryObj.activeSelf)
                inventoryObj.SetActive(false);
            else
            {
                inventoryObj.SetActive(true);
                var i = 0;
                foreach (var itemName in Items.Keys)
                {
                    if (!GlobalDatabase.ItemTypes.ContainsKey(itemName))
                        throw new ArgumentNullException(string.Format("{0} is not existed in inventory!", itemName));

                    var item = GlobalDatabase.ItemTypes[itemName];
                    if (inventoryObj.transform.childCount >= 0)
                    {
                        var img = Instantiate(Container);
                        img.transform.SetParent(inventoryObj.transform.GetChild(i).transform);
                        img.GetComponent<Image>().sprite = item.Sprite;
                        i++;
                    }
                    else
                        break;
                }
            }
            //inventoryObj.SetActive(!inventoryObj.activeSelf);
        }
    }

    public void AddItem(Item item)
    {
        if (IsInInventory(item))
            Items[item.Name]++;
        else
            Items.Add(item.Name, 1);
    }

    public void DeleteItem(Item item)
    {
        if (!IsInInventory(item))
            throw new ArgumentNullException(string.Format("{0} is not existed in inventory!", item.Name));

        Items[item.Name]--;

        if (Items[item.Name] == 0)
            Items.Remove(item.Name);
    }

    // may be private
    public bool IsInInventory(Item i)
    {
        foreach (var item in Items)
            if (item.Key == i.Name)
                return true;

        return false;
    }
}