﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject
{
    public int damage;
    public int health;

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.addEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        Move(18,0);
    }
}
