﻿using UnityEngine;
public interface IMovable
{
    float SetMoveSpeed(float speed);
    void Move(Transform point);
}
