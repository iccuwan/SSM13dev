﻿using System;
using UnityEngine;

namespace Ark
{
    public class Economics : MonoBehaviour
    {
        // ============= fields =============
        [Header("Economics value")]
        [SerializeField] private int _storedMoney;

        public int StoredMoney => _storedMoney;
        public bool IsEmpty => _storedMoney == 0 ? true : false;
        
        // ============= instance =============
        private static Economics _instance;
        public static Economics Instance
        {
            get
            {
                if (_instance == null) _instance = GameObject.FindObjectOfType<Economics>();
                return _instance;
            }
        }
        
        // ============= method =============

        public void SubtractMoney(int value)
        {
            
            if ((_storedMoney - value) < 0)
                throw new ArgumentOutOfRangeException(nameof(StoredMoney),
                    $"The {nameof(StoredMoney)} value cannot become negative.");
            _storedMoney -= value;
        }

        public void AddMoney(int value)
        {
            if (value >= 0)
            {
                _storedMoney += value;
            }
            else throw new ArgumentOutOfRangeException(nameof(value),
                $"The {nameof(value)} value cannot be negative.");
        }
    }
}