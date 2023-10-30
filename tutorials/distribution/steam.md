# steam

### Introduction

FlatRedball games can be distributed on Steam with or without adding code to handle Steam integration. Steam integration can be added using the Steamworks.NET library. This includes support for achievements and responding to the Steam overlay being shown.

### Adding Steamworks.NET Library

To add Steamworks.NET library to your project:

1. Go to the [Steamworks.NET github releases page](https://github.com/rlabrecque/Steamworks.NET/releases)
2.  Download the latest release standalone

    ![](../../../media/2022-09-img_6324fbac1a1fa.png)
3. Unzip the downloaded file
4. Link the Steamworks.NET.dll file in your project
   1. If you are making a Desktop GL (.NET Framework) project, be sure to link to the x86 version as this version of FlatRedBall does not support 64 bit builds
   2.  If you are targeting .NET 6, use the 64 bit version.

       ![](../../../media/2022-09-img_6324fdc469a67.png)
5. Copy the steam_api64.dll or steam_api.dll file to the same folder as your game's .csproj (and .gluj) depending on whether you linked to the 64 bit version of Steamworks.NET.dll
6.  &#x20;Add the steam_api file to your project in Visual Studio and mark it as **Copy if Newer** so that the file ends up in your game's bin folder next to the built .exe.

    ![](../../../media/2022-09-img_6324fea5eb27b.png)
7. Add your steam_appid.txt file to the folder where your game's exe is located.
8. When testing, be sure to have Steam running or else your tests won't work.

### Adding SteamManager

Once the Steamworks library is added to your project, you can interact directly with the library to award achievements and respond to the tab overlay being shown. If you would like to work directly with this library, you can find additional information on the [Steamworks github page](https://steamworks.github.io/). The documentation is focused on Unity but may of the concepts apply. Alternatively, the following SteamManager class can be used to set up a project quickly. Note that this is provided to help get a project set up quickly. Future versions of FlatRedBall may provide more integrated solutions such as code gen:

```
    #region Achievement Class

    abstract class AchievementBase
    {

    }

    class BoolAchievement : AchievementBase
    {
        string AchievementName;
        Func GetCurrentValue;

        public BoolAchievement(string achievementName, Func getCurrentValue)
        {
            AchievementName = achievementName;
            GetCurrentValue = getCurrentValue;

        }

        public void TryApply()
        {
            if(GetCurrentValue())
            {
                SteamManager.Self.AwardAchievement(AchievementName);
            }
        }
    }

    class NumericAchievement : AchievementBase
    {
        string ProgressStat;
        Func GetCurrentValue;

        public NumericAchievement(string progressStat, Func getCurrentValue)
        {
            ProgressStat = progressStat;
            GetCurrentValue = getCurrentValue;
        }

        public void TryApply()
        {
            SteamManager.Self.SetStat(ProgressStat, GetCurrentValue());
        }
    }

    #endregion

    #region Achievements list
    class Achievements
    {

        //// start level select screen
        //public static NumericAchievement ExampleAchievement = new NumericAchievement(
        //    "star_one_count", // This is the variable of the achievement
        //    () => MyGameObject.GetCurrentValue() // This is value that the player has obtained so far, like the number of powerups collected
        //    );

    }

    #endregion

    #region SteamManager
    class SteamManager : IManager
    {
        static SteamManager self;
        public static SteamManager Self
        {
            get
            {
                if (self == null) self = new SteamManager();
                return self;
            }
        }

        static bool isInitialized;
        static AppId_t appId;

        static Callback gameOverlayActivatedCallback;
        static Callback userStatsReceivedCallback;
        static Callback userStatsStoredCallback;
        static Callback userAchievementStoredCallback;

        public static Action SteamOverlayVisibilityChanged;

        public void Initialize()
        {
            // this requires steam_appid.txt in the bin folder, and also that Steam is running
            isInitialized = Steamworks.SteamAPI.Init();


            if (isInitialized)
            {
                //var name = Steamworks.SteamFriends.GetPersonaName();

                appId = Steamworks.SteamUtils.GetAppID();

                SteamUserStats.RequestCurrentStats();

                gameOverlayActivatedCallback = Callback.Create(HandleOverlayActivated);
                userStatsReceivedCallback = Callback.Create(HandleUserStatsReceived);
                userStatsStoredCallback = Callback.Create(HandleUserStatsStored);
                userAchievementStoredCallback = Callback.Create(HandleUserAchievementStored);

                // Example: Gets an achievement by ID
                //var achievement = SteamUserStats.GetAchievementName(2);
                // Example: Gets the number of achievemtns the user has been awarded:
                //var achievementCount = SteamUserStats.GetNumAchievements();
            }
        }

        public void AwardAchievement(string achievementId)
        {
            if (isInitialized)
            {
                SteamUserStats.SetAchievement(achievementId);
            }
        }

        public void SetStat(string statId, long value)
        {
            if (isInitialized)
            {
                var clamped = (int)(Math.Min(value, int.MaxValue));
                SteamUserStats.SetStat(statId, clamped);
            }
        }

        private static void HandleUserAchievementStored(UserAchievementStored_t param)
        {

        }

        private static void HandleUserStatsStored(UserStatsStored_t param)
        {

        }

        private static void HandleUserStatsReceived(UserStatsReceived_t param)
        {

        }

        private static void HandleOverlayActivated(GameOverlayActivated_t param)
        {
            SteamOverlayVisibilityChanged?.Invoke(param.m_bActive > 0);
        }

        public void Update()
        {
            if(isInitialized)
            {
                Steamworks.SteamAPI.RunCallbacks();

            }
#if DEBUG

            // If you want to test awarding achievements, try this:
            //var keyboard = FlatRedBall.Input.InputManager.Keyboard;


            //if (keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift))
            //{

            //    if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.D1))
            //    {
            //        ResetAllStats();
            //    }

            //    if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.D2))
            //    {
                    //AwardAchievement(Achievements.Destroy1_5Base);
                    //AwardAchievement(Achievements.Research15Creatures);
                    //AwardAchievement(Achievements.Research30Creatures);
                    //AwardAchievement(Achievements.Research45Creatures);
            //    }

            //}


#endif




        }



        internal static void StoreStats()
        {
            if (isInitialized)
            {
                SteamUserStats.StoreStats();
            }
        }


#if DEBUG
        private static void ResetAllStats()
        {
            const bool resetAchievements = true;
            SteamUserStats.ResetAllStats(resetAchievements);
        }
#endif

        internal void Exit()
        {
            SteamAPI.Shutdown();
        }

        void IManager.UpdateDependencies(){}
    }

    #endregion
```

#### steam_appid.txt

The steam_appid.txt file is a text file which is added to the same location as your game's .exe file. It is a text file which should contain only your app ID (which is a 7 digit number athte time of this writing, but may increase to 8 or 9 digits in the future).  Note that creating the file in Visual Studio may add a byte order mark which makes your file unreadable by the Steam api, so create the file as a plain text file through Windows Explorer.

#### SteamManager Setup

To use the SteamManager:

1. Add `SteamManager.Self.Initialize();` to Game1 constructor
2. Add `SteamManager.Self.Update();` to Game1 Update
3. Add `SteamManager.Self.Exit();` to Game1 OnExiting (you may need to manually override this method in your game)

#### Handling SteamManager Steam Overlay

Normally games should be paused when the Steam overlay is shown. Games which use GameScreen as their base class for all levels can respond to the SteamManager's SteamOverlayVisibilityChanged event by pausing. For example, the following code snippet could be used to pause the game:

```
void CustomInitialize()
{
   ...
   SteamManager.SteamOverlayVisibilityChanged += HandleSteamOverlayVisibilityChange;
}

private void HandleSteamOverlayVisibilityChange(bool isSteamOverlayVisible)
{
    if(isSteamOverlayVisible && !IsPaused)
    {
        // This will pause the screen, but you may want to call your own custom pause function to handle showing menus
        // or other game-specific logic
        PauseThisScreen();
    }
}

void CustomDestroy()
{
    SteamManager.SteamOverlayVisibilityChanged -= HandleSteamOverlayVisibilityChange;
}
```

### Defining Achievements

Steam achievements are handled in two places:

1. The achievements must be defined in the Steam dashboard for your game
2. Achievement logic must be added to your game

If using the SteamManager, the second point is fairly easy to do:

1. Find the Achievements class in the code above
2. Follow the example achievement to create your own achievement. Note that this pattern requires access to the game data, such as the profile information which may have values controlling whether an achievement has been fulfilled
3. In game code, call TryApply on achievements which may be achieved in response to certain game events. You may choose to award achievements the moment they are awarded, or at certain points of the game execution (such as the end of a level)

For example, consider an achievement which is awarded when the player has collected all possible power-ups in a game. This may be checked in the collision function between PlayerList and PowerUpList as follows:

```
Achievements.PowerUpCollection.TryApply();
```

The TryApply method performs a local check for awarding before sending anything to Steam, so making these calls frequently will typically not cause performance problems. Of course, be aware of situations where the checking of an achievement requires time intensive checks, such as loading files from disk or performing a large number of calculations.

### .NET 6 Self Contained Builds

If your game uses .NET 6 or newer, then it can be published as a self-contained app which includes all of the .NET 6 runtime files. While this increases the size of your game, it enables your game to run on any machine regardless of whether .NET 6 runtime is installed. Furthermore, it allows your game to run on SteamDeck. To do this, first add the following highlighted text to your csproj under the PropertyGroup tag.

![](../../../media/2022-11-img_636bcbde5f619.png)

Once you have done this, you can publish your application using the dotnet publish command or you can grab the files from the bin folder that Visual Studio creates. &#x20;
