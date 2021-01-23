﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Ark;
using NUnit.Framework;

namespace Storage
{
    public class Inventory : MonoBehaviour
    {
        private static Inventory _instance;
        private List<GameItem> _items = new List<GameItem>();

        public static Inventory Instance
        {
            get
            {
                if (_instance == null) _instance = GameObject.FindObjectOfType<Inventory>();
                return _instance;
            }
        }
        
        private void ValidateInventory()
        {
            if (_items == null) _items = GameItemDatabase.GetListItems();
        }

        public void ClearInventory()
        {
            _items?.Clear();
        }

        /// <summary>
        /// Only DEBUG!
        /// </summary>
        public void dev_ClearCountItems()
        {
            ValidateInventory();
            foreach (var item in _items)
            {
                item.SetCount(0);
            }
        }
        
        public GameItem GetItem(int itemId)
        {
            ValidateInventory();
            return _items.Find(item => item.ItemID == itemId);
        }
        
        public GameItem GetItem(string itemName)
        {
            ValidateInventory();
            return _items.Find(item => item.ItemName == itemName);
        }

        public GameItem GetItem(GameItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            ValidateInventory();
            return _items.Find(element => element.ItemID == item.ItemID);
        }
        
        public void AddItem(GameItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            ValidateInventory();
            if (_items.Count != 0)
            {
                GetItem(item).AddCount(item.ItemCount);
                return;
            }
            else throw new ArgumentNullException(nameof(_items));
        }

        public void AddItem(int id, int count)
        {
            ValidateInventory();
            if (_items.Count != 0)
            {
                GetItem(id).AddCount(count);
            }
            else throw new ArgumentNullException(nameof(_items));
        }

        public void SubtractItem(GameItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            ValidateInventory();
            GetItem(item).RemoveCount(item.ItemCount);
        }
        
        public void SubtractItem(int id, int count)
        {
            ValidateInventory();
            GetItem(id).RemoveCount(count);
        }

    }
}
