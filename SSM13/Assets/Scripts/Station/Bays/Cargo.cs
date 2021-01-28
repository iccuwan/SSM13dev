﻿using System;
using System.Collections;
using System.Collections.Generic;
using Ark;
using Storage;
using UnityEngine;
using UnityEngine.UI;


public class Cargo : Ark.Bay
{
    // ================ fields ================
    [Header("System setup")]
    public Station station;
    public Transform spawn;
    public GameObject Assistent;


    // DON'T use GameItem from assets!!!
    
    
    // ================ inventory ================
    private Inventory _inventory;
    /// <summary>
    /// Validate inventory. 
    /// </summary>
    private void Awake() => _inventory = Storage.Inventory.Instance;
    
    // ================ methods ================
    private void BuyItem(GameItem element)
    {
        
    }

}
