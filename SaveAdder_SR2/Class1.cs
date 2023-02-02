using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using SaveMod; // The namespace of your mod class
using HarmonyLib;
using UnityEngine;
using UnityEditor;
using Unity;
using UnityEngineInternal;
using UnityEngine.UI;
using System.Threading;
using Il2CppMonomiPark.SlimeRancher.SceneManagement;
using Il2CppMonomiPark.SlimeRancher.UI;
using Harmony;
using UnityEngine.UIElements;
using UnityEngine.IO;
using System.Security.Cryptography.X509Certificates;
using Il2CppMonomiPark.SlimeRancher.UI.MainMenu;

namespace SaveMod
{
    public class MyMod : MelonMod
    {
        public static AutoSaveDirector director;
        public static GameObject SavesMenuScrollBox;
        public static ScrollRect SaveMenuScroll;
        public SceneLoader Loader;
        public static bool IsFound = true;
        public SaveGamesRootUI saveui;



        public override void OnUpdate()
        {
            if (GameObject.Find("ButtonsScrollView") != null)
            {
                
                if (IsFound == false)
                {
                    saveui = GameObject.FindObjectOfType<SaveGamesRootUI>();
                    SavesMenuScrollBox = GameObject.Find("ButtonsScrollView");
                    SaveMenuScroll = SavesMenuScrollBox.GetComponent<ScrollRect>();
                    SaveMenuScroll.vertical = true;
                    SaveMenuScroll.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.Permanent;
                    LoggerInstance.Msg("Set Scroll Data!");
                    IsFound = true;
                }
            }
        }

        public static void ScrollerSet()
        {

        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "GameCore")
            {
                LoggerInstance.Warning("GameCore scene loaded.");
                director = GameObject.FindObjectOfType<AutoSaveDirector>();
                director.saveSlotCount = 100;

            }
            else if (sceneName == "MainMenuUI")
            {

                LoggerInstance.Warning("Main Menu UI scene loaded.");

                IsFound = false;
            }
        }
    }
}
