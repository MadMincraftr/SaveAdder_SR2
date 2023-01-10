using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using SaveMod; // The namespace of your mod class
using HarmonyLib;
using UnityEngine;
using UnityEditor;
using Unity;
using UnityEngineInternal;
using UnityEngine.UI;
using System.Threading;

namespace SaveMod
{
    public class MyMod : MelonMod
    {
        public AutoSaveDirector director;
        public GameObject SavesMenuScrollBox;
        public ScrollRect SaveMenuScroll;
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg("A Scene was loaded!");
            if (sceneName == "GameCore")
            {
                LoggerInstance.Warning("GameCore scene loaded.");
                director = GameObject.FindObjectOfType<AutoSaveDirector>();
                director.saveSlotCount = 99;
            }
            else if (sceneName == "MainMenuUI")
            {
                LoggerInstance.Warning("Main Menu UI scene loaded.");
                SavesMenuScrollBox = GameObject.Find("ButtonsScrollView");
                if (SavesMenuScrollBox != null)
                {

                    LoggerInstance.Msg(SavesMenuScrollBox.name);
                    SaveMenuScroll = SavesMenuScrollBox.GetComponent<ScrollRect>();
                    SaveMenuScroll.vertical = true;
                    SaveMenuScroll.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.Permanent;
                    SaveMenuScroll.m_VSliderWidth = 25;
                    LoggerInstance.Msg("Set slider data!");
                }
                else
                {
                    LoggerInstance.Error("Save Menu came back with a NULL? hmm");
                }
            }
        }
    }
}
