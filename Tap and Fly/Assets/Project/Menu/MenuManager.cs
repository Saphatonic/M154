﻿using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public Menu CurrentMenu;

    public void Start()
    {
        ShowMenu(CurrentMenu);
    }

    public void ShowMenu(Menu menu)
    {
        if (menu == null)
        {
            return;
        }

        if (CurrentMenu != null)
        {
            CurrentMenu.Active = false;
        }

        CurrentMenu = menu;
        CurrentMenu.Active = true;        
    }
}
