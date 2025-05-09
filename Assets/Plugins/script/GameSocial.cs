using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace game {
	public enum SocialRetCode
	{
		// code for leaderboard feature
		kScoreSubmitSucceed =1,/**< enum value is callback of succeeding in submiting. */
		kScoreSubmitfail,/**< enum value is callback of failing to submit . */
		
		// code for achievement feature
		kAchUnlockSucceed,/**< enum value is callback of succeeding in unlocking. */
		kAchUnlockFail,/**< enum value is callback of failing to  unlock. */
		
		kSocialSignInSucceed,/**< enum value is callback of succeeding to login. */
		kSocialSignInFail,/**< enum value is callback of failing to  login. */
		
		kSocialSignOutSucceed,/**< enum value is callback of succeeding to login. */
		kSocialSignOutFail,/**< enum value is callback of failing to  login. */
		kSocialGetGameFriends,/**< enum value is callback of getGameFriends. */
		kSocialExtensionCode = 20000 /**< enum value is  extension code . */
		
		
	} ;
	public class GameSocial
	{
		private static GameSocial _instance;
		
		public static GameSocial getInstance() {
			if( null == _instance ) {
				_instance = new GameSocial();
			}
			return _instance;
		}

		/**
     	@brief user signIn
    	 */

		public  void signIn()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameSocial_nativeSignIn ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	@brief user signOut
    	 */

		public  void signOut()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameSocial_nativeSignOut ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief submit the score
    	 @param leaderboardID
     	 @param the score
     	*/

		public  void submitScore(string leadboardID, long score)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameSocial_nativeSubmitScore (leadboardID, score);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	 @brief show the id of Leaderboard page
     	 @param leaderboardID
     	 */

		public  void showLeaderboard(string leadboardID)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameSocial_nativeShowLeaderboard (leadboardID);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		
		/**
    	 @brief methods of achievement feature
   		  @param the info of achievement
    	 */

		public  void unlockAchievement (Dictionary<string,string> achInfo)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string info = GameUtil.dictionaryToString (achInfo);
			GameSocial_nativeUnlockAchievement (info);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief show the page of achievements
     	*/

		public  void showAchievements ()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameSocial_nativeShowAchievements ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
		 * set debugmode for plugin
		 * 
		 */
		[Obsolete("This interface is obsolete!",false)]
		public  void setDebugMode(bool bDebug)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameSocial_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		/**
    	 @brief set pListener The callback object for social result
    	 @param the MonoBehaviour object
    	 @param the callback of function
    	 */

		public  void setListener(MonoBehaviour gameObject,string functionName)
		{
#if UNITY_ANDROID 
			GameUtil.registerActionCallback (GameType.Social, gameObject, functionName);
#elif UNITY_IOS
			string gameObjectName = gameObject.gameObject.name;
			GameSocial_nativeSetListener(gameObjectName,functionName);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		/**
     	@brief Check function the plugin support or not
     	*/
		
		public  bool  isFunctionSupported (string functionName)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return GameSocial_nativeIsFunctionSupported (functionName);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}
		/**
		 * Get Plugin version
		 * 
		 * @return string
	 	*/

		public  string getPluginVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameSocial_nativeGetPluginVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		/**
		 * Get Plugin version
		 * 
		 * @return string
	 	*/

		public  string getSDKVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameSocial_nativeGetSDKVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param GameParam param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, GameParam param)
		{
			#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			GameSocial_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null) 
			{
				GameSocial_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				GameSocial_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param GameParam param 
    	 *@return int
    	 */
		public  int callIntFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			return GameSocial_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return int
    	 */
		public  int  callIntFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return GameSocial_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return GameSocial_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param GameParam param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			return GameSocial_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return GameSocial_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return GameSocial_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param GameParam param 
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			return GameSocial_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return GameSocial_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return GameSocial_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param GameParam param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			StringBuilder value = new StringBuilder();
			value.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameSocial_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder value = new StringBuilder();
			value.Capacity = GameUtil.MAX_CAPACITY_NUM;
			if (param == null)
			{
				GameSocial_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				GameSocial_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM,CallingConvention=CallingConvention.Cdecl)]
		private static extern void GameSocial_RegisterExternalCallDelegate(IntPtr functionPointer);
#else
		private static void GameSocial_RegisterExternalCallDelegate(IntPtr functionPointer){}
		#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameSocial_nativeSetListener(string gameName, string functionName);
#else
		private static void GameSocial_nativeSetListener(string gameName, string functionName){}
		#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameSocial_nativeSignIn();
#else
		private static void GameSocial_nativeSignIn(){}
		#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameSocial_nativeSignOut();
#else
		private static void GameSocial_nativeSignOut(){}
		#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameSocial_nativeShowLeaderboard(string leadboardID);
#else
		private static void GameSocial_nativeShowLeaderboard(string leadboardID){}
		#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameSocial_nativeSubmitScore(string leadboardID, long score);
#else
		private static bool GameSocial_nativeSubmitScore(string leadboardID, long score)
		{
			return false;
		}
		#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameSocial_nativeUnlockAchievement(string info);
#else
		private static bool GameSocial_nativeUnlockAchievement(string info)
		{
			return false;
		}
		#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameSocial_nativeShowAchievements();
#else
		private static bool GameSocial_nativeShowAchievements()
		{
			return false;
		}
		#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameSocial_nativeIsFunctionSupported(string functionName);
#else
		private static bool GameSocial_nativeIsFunctionSupported(string functionName)
		{
			return false;
		}
		#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameSocial_nativeSetDebugMode(bool bDebug);
#else
		private static void GameSocial_nativeSetDebugMode(bool bDebug){}
		#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameSocial_nativeGetPluginVersion(StringBuilder version);
#else
		private static void GameSocial_nativeGetPluginVersion(StringBuilder version){}
		#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameSocial_nativeGetSDKVersion(StringBuilder version);
#else
		private static void GameSocial_nativeGetSDKVersion(StringBuilder version){}
		#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameSocial_nativeCallFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static void GameSocial_nativeCallFuncWithParam(string functionName, GameParam[] param,int count){}
		#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern int GameSocial_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static int GameSocial_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return 0;
		}
		#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern float GameSocial_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static float GameSocial_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return 0;
		}
		#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameSocial_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static bool GameSocial_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return false;
		}
		#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameSocial_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value);
#else
		private static void GameSocial_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value){}
		#endif
	}
	
}


