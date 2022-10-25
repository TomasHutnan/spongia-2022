using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AE.Items
{
    public class Vendor : MonoBehaviour
    {
        public float SellValueMultiplier;
        public List<Item> Inventory;
        public int Money;

        public event Action InventoryUpdateEvent;
        public bool AddItem(Item item)
        {
            Inventory.Add(item);
            triggerInventoryUpdateEvent();
            return true;
        }
        public bool RemoveItem(Item item)
        {
            if (Inventory.Remove(item))
            {
                triggerInventoryUpdateEvent();
                return true;
            }
            return false;
        }

        protected void triggerInventoryUpdateEvent()
        {
            InventoryUpdateEvent?.Invoke();
        }
    }
}
