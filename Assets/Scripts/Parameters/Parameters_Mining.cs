﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters_Mining : MonoBehaviour
{
    public static Parameters_Mining Instance;

    [SerializeField] public float gloves_mining_multplier = 1f;
    [SerializeField] public float pickaxe_mining_multplier = 1f;
    [SerializeField] public float hammer_mining_multplier = 1f;
    [SerializeField] public float bomb_mining_multplier = 1f;
    [SerializeField] public float bomb_radius = 1f;
    [SerializeField] public float bomb_mine_level_scale = 0.1f;
    [SerializeField] public float staff_mining_multplier = 1f;
    [SerializeField] public float staff_chain_radius = 1f;
    [SerializeField] public float staff_mine_level_scale = 0.01f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
