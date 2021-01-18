﻿using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Bay;

public class Station : MonoBehaviour
{
	[SerializeField]
	private int crewUpdateTime = 5000;

	private List<Crew> crewList;
	private Timer crewUpdateTimer;

	private uint money = 0;
	
	public uint Money
	{
		get
		{
			return money;
		}
	}

	public void AddMoney(uint count)
	{
		money += count;
	}

	public void TakeMoney(uint count)
	{
		money -= count;
	}

	public void AddCrew(Crew crew)
	{
		if (crewList.Contains(crew))
		{
			Debug.LogWarning("ADDING TO CREW LIST A CREW THAT ALREADY IN LIST");
		}
		crewList.Add(crew);
	}

	private void Awake()
	{
		crewUpdateTimer = new Timer(crewUpdateTime);
		crewUpdateTimer.Elapsed += crewUpdateTrigger;
	}
	private void crewUpdateTrigger(object sender, ElapsedEventArgs e)
	{
		foreach (Crew crew in crewList)
		{
			crew.CrewUpdate();
		}
	}

	public void BuyBay()
    {
	 
    }
}