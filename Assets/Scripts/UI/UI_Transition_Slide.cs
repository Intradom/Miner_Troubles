﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Transition_Slide : MonoBehaviour
{
    [SerializeField] private RectTransform ref_base_transform = null;
    [SerializeField] private Vector2 offset = Vector2.zero;
    [SerializeField] private bool start_active = true;
    [SerializeField] private float transition_speed = 0f;
    
    private bool active;
    private float active_level; // 0 is inactive, 1 is active
    private Vector2 loc_start = Vector2.zero;
    private Vector2 starting_res;

    public void ToggleActive(bool new_active)
    {
        active = new_active;
    }

    private void Awake()
    {
        loc_start = ref_base_transform.transform.position;
        starting_res = new Vector2(Screen.width, Screen.height);
    }

    private void Start()
    {
        active = start_active;
        active_level = active ? 1f : 0f;
        ref_base_transform.position = loc_start + offset * (1f - active_level);
    }

    private void Update()
    {
        float width_diff = (Screen.width - starting_res.x) / 2f;
        Vector2 new_loc = loc_start + new Vector2(width_diff, 0f); // Don't scale height since canvas only scales width

        if ((active && active_level < 1f) || (!active && active_level > 0f)) // Needs to change locations
        {
            active_level += transition_speed * Time.deltaTime * (active ? 1f : -1f);
            active_level = Mathf.Clamp(active_level, 0f, 1f);
            ref_base_transform.position = new_loc + offset * (1f - active_level);
        }
    }
}
