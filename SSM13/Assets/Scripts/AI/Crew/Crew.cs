﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
namespace AI
{
    public class Crew : Human
    {
        public List<Transform> WorkZone = new List<Transform>();
        public void SetJobBehaviour(IWork behaviour) => _IWork = behaviour;
        private IWork _IWork; //Члены экипажа могут работать! Исключение ассистент кроме что (но бомл гений сделает заглушку-класс без работы)
        public BayTypes AccessLevel;
        private RandomPointGenerator randomPointGenerator;




        private void Awake()
        {
            randomPointGenerator = GameObject.FindObjectOfType<RandomPointGenerator>();
            setter = GetComponent<AIDestinationSetter>();
            bayList = GameObject.FindObjectOfType<BayList>();
            InitBehaviors();
        }
        protected void InitBehaviors()
        {
            SetWalkBehaviour(new CrewMovePattern(transform, 1f,setter));
        }
        protected void Movement(Transform Point)
        {
            PerformWalkMove(Point);
        }
        protected void RandomMovePoint()
        {
           // if(rest > 5) 
           if(_IMovable is CrewMovePattern)
            {
                    Debug.Log("Повезло, повезло");
                    ((CrewMovePattern)_IMovable).GoToRandomPoint(randomPointGenerator, AccessLevel);
            }
        }
    }
}

