﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    //  color
    static Color COLOR_TRIGGER = new Color(0.8f, 1, 0.8f);
    static Color COLOR_NONE = new Color(1, 1, 1);

    //  play
    static Play play;

    //  button
    static GameObject[] subbutton_BubbleRay;
    static GameObject button_Cue_FishPole;
    static GameObject button_Cue_Bubble;
    static GameObject[] subbutton_Technique;

    //  menu setting
    static string setting_BubbleRay;
    static string setting_Technique;
    static bool change_BubbleRay = true;
    static bool change_Cue_FishPole = true;
    static bool change_Cue_Bubble = true;
    static bool change_Technique = true;
    
    void Start() {
        play = GameObject.Find("Play").GetComponent<Play>();

        //  static gameobject
        subbutton_BubbleRay = GameObject.FindGameObjectsWithTag("subbutton bubble ray");
        button_Cue_FishPole = GameObject.Find("Menu/Cue/Button Fish Pole");
        button_Cue_Bubble = GameObject.Find("Menu/Cue/Button Bubble");
        subbutton_Technique = GameObject.FindGameObjectsWithTag("subbutton technique");

        //  initiate
        setting_BubbleRay = "Hand Distance";
        setting_Technique = "Bubble Ray";
    }
    
    void Update() {
        //  set method
        string method = setting_Technique;
        if (setting_Technique == "Bubble Ray") method = setting_BubbleRay;
        play.technique.method = method;

        //  renew button bubble ray
        if (change_BubbleRay) {
            change_BubbleRay = false;
            foreach (GameObject g in subbutton_BubbleRay) SetButtonColor(g, COLOR_NONE);
            SetButtonColor(GameObject.Find("Menu/Bubble Ray/Button " + setting_BubbleRay), COLOR_TRIGGER);
        }

        //  renew button cue
        if (change_Cue_FishPole) {
            change_Cue_FishPole = false;
            SetButtonColor(button_Cue_FishPole, BubbleRay.visibilityFishPole ? COLOR_TRIGGER : COLOR_NONE);
        }
        if (change_Cue_Bubble) {
            change_Cue_Bubble = false;
            SetButtonColor(button_Cue_Bubble, BubbleRay.visibilityBubble ? COLOR_TRIGGER : COLOR_NONE);
        }
        
        //  renew button technique
        if (change_Technique) {
            change_Technique = false;
            foreach (GameObject g in subbutton_Technique) SetButtonColor(g, COLOR_NONE);
            SetButtonColor(GameObject.Find("Menu/Technique/Button " + setting_Technique), COLOR_TRIGGER);
            switch (setting_Technique) {
                case "Naive Ray":
                    play.ChangeTechnique<NaiveRay>();
                    break;
                case "Bubble Ray":
                    play.ChangeTechnique<BubbleRay>();
                    break;
                case "3D Bubble Cursor":
                    play.ChangeTechnique<X3DBubbleCursor>();
                    break;
                case "Go Go":
                    play.ChangeTechnique<GoGo>();
                    break;
                case "Heuristic Ray":
                    play.ChangeTechnique<HeuristicRay>();
                    break;
                case "SQUAD Cone":
                    play.ChangeTechnique<SQUADCone>();
                    break;
            }
        }
    }
    
    void SetButtonColor(GameObject g, Color c) {
        g.GetComponent<Image>().color = c;
    }
    void ClearTriggeredButton(GameObject[] group) {
        foreach (GameObject g in group) {
            SetButtonColor(g, COLOR_NONE);
        }
    }
    
    public void OnClick_BubbleRay_HandDistance() {
        change_BubbleRay = true;
        setting_BubbleRay = "Hand Distance";
    }
    public void OnClick_BubbleRay_HandAngular() {
        change_BubbleRay = true;
        setting_BubbleRay = "Hand Angular";
    }
    public void OnClick_BubbleRay_HandAngularNear() {
        change_BubbleRay = true;
        setting_BubbleRay = "Hand Angular Near";
    }
    public void OnClick_BubbleRay_Test() {
        change_BubbleRay = true;
    }
    
    public void OnClick_Cue_FishPole() {
        change_Cue_FishPole = true;
        BubbleRay.visibilityFishPole = !BubbleRay.visibilityFishPole;
    }
    public void OnClick_Cue_Bubble() {
        change_Cue_Bubble = true;
        BubbleRay.visibilityBubble = !BubbleRay.visibilityBubble;
    }

    public void OnClick_Technique_NaiveRay() {
        string prevSetting_Technique = setting_Technique;
        setting_Technique = "Naive Ray";
        change_Technique = (setting_Technique != prevSetting_Technique);
    }
    public void OnClick_Technique_BubbleRay() {
        string prevSetting_Technique = setting_Technique;
        setting_Technique = "Bubble Ray";
        change_Technique = (setting_Technique != prevSetting_Technique);
    }
    public void OnClick_Technique_3DBubbleCursor() {
        string prevSetting_Technique = setting_Technique;
        setting_Technique = "3D Bubble Cursor";
        change_Technique = (setting_Technique != prevSetting_Technique);
    }
    public void OnClick_Technique_GoGo() {
        string prevSetting_Technique = setting_Technique;
        setting_Technique = "Go Go";
        change_Technique = (setting_Technique != prevSetting_Technique);
    }
    public void OnClick_Technique_HeuristicRay() {
        string prevSetting_Technique = setting_Technique;
        setting_Technique = "Heuristic Ray";
        change_Technique = (setting_Technique != prevSetting_Technique);
    }
    public void OnClick_Technique_SQUADCone() {
        string prevSetting_Technique = setting_Technique;
        setting_Technique = "SQUAD Cone";
        change_Technique = (setting_Technique != prevSetting_Technique);
    }
}
