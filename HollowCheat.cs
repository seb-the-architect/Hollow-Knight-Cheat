using System;
using UnityEngine;

class Main : MonoBehaviour
{
    bool bMenuVisible = Convert.ToBoolean(0);
    bool bSoulfull = Convert.ToBoolean(0);
    bool bInvincible = Convert.ToBoolean(0);

    int DamageSliderValue = 0;

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Insert)) // Will just unload our DLL
        {
            bMenuVisible = !bMenuVisible;
        }
        if (bSoulfull)
        {
            m_PlayerData.MPCharge = m_PlayerData.maxMP;
        }
        if (bInvincible)
        {
            m_PlayerData.health = m_PlayerData.maxHealth;
        }
        m_PlayerData = PlayerData.instance;
    }

    public void OnGUI()
    {
        if (bMenuVisible)
        {
            GUI.Box(new Rect(Screen.width-250, 10, 200, 180), "Seb's Hollow Knight Hack");

            bSoulfull = GUI.Toggle(new Rect(Screen.width - 250, 40, 160, 20), bSoulfull, "Infinite Soul");

            DamageSliderValue = (int)GUI.HorizontalSlider(new Rect(Screen.width - 250, 70, 100, 30), DamageSliderValue, 0.0F, 500.0F);

            GUI.Label(new Rect(Screen.width - 140, 90, 100, 20), DamageSliderValue.ToString());

            if (GUI.Button(new Rect(Screen.width - 140, 70, 82, 22), "Set Damage"))
            {
                m_PlayerData.nailDamage = DamageSliderValue;
            }

            bInvincible = GUI.Toggle(new Rect(Screen.width - 250, 100, 160, 20), bInvincible, "Invincible");

            if (GUI.Button(new Rect(Screen.width - 250, 130, 82, 20), "Add 50 Geo"))
            {
                m_PlayerData.geo += 50;
            }
        }
    }

    PlayerData m_PlayerData;
}

