using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace game {
	public class GameCrash
	{
		private static GameCrash _instance;
		
		public static GameCrash getInstance() {
			if( null == _instance ) {
				_instance = new GameCrash();
			}
			return _instance;
		}

		/**
	 	*  set user identifier
	 	*
	 	*  @param userInfo
	 	*/
		public void setUserIdentifier(string identifier)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameCrash_nativeSetUserIdentifier (identifier);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		
		/**
	 	*  The uploader captured in exception information
	 	*
	 	*	@param message   Set the custom information
	 	*  @param exception  The exception
	 	*/
		public void reportException(string message, string exception)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameCrash_nativeReportException (message, exception);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		
		/**
	 	*  customize logging
	 	*
	 	*  @param String Custom log
	 	*/
		public void leaveBreadcrumb(string breadcrumb)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameCrash_nativeLeaveBreadcrumb (breadcrumb);
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
			return GameCrash_nativeIsFunctionSupported (functionName);
#else
			Debug.Log("This platform does not support!");
			return false;
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
			GameCrash_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
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
			GameCrash_nativeGetPluginVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
		 * Get SDK version
		 * 
		 * @return string
	 	*/

		public  string getSDKVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameCrash_nativeGetSDKVersion (version);
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
			GameCrash_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
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
				GameCrash_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				GameCrash_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GameCrash_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GameCrash_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return GameCrash_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GameCrash_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GameCrash_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return GameCrash_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
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
    	 *@return string
    	 */
		public  bool callBoolFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			return GameCrash_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return string
    	 */
		public  bool callBoolFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return GameCrash_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return GameCrash_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			StringBuilder value = new StringBuilder();
			value.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameCrash_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
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
				GameCrash_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				GameCrash_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameCrash_nativeSetUserIdentifier(string identifier);
#else
		private static void GameCrash_nativeSetUserIdentifier(string identifier){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameCrash_nativeReportException(string message, string exception);
#else
		private static void GameCrash_nativeReportException(string message, string exception){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameCrash_nativeLeaveBreadcrumb(string breadcrumb);
#else
		private static void GameCrash_nativeLeaveBreadcrumb(string breadcrumb){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameCrash_nativeIsFunctionSupported(string functionName);
#else
		private static bool GameCrash_nativeIsFunctionSupported(string functionName)
		{
			return false;
		}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameCrash_nativeSetDebugMode(bool bDebug);
#else
		private static void GameCrash_nativeSetDebugMode(bool bDebug){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameCrash_nativeGetPluginId(StringBuilder pluginID);
#else
		private static void GameCrash_nativeGetPluginId(StringBuilder pluginID){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameCrash_nativeGetPluginVersion(StringBuilder version);
#else
		private static void GameCrash_nativeGetPluginVersion(StringBuilder version){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameCrash_nativeGetSDKVersion(StringBuilder version);
#else
		private static void GameCrash_nativeGetSDKVersion(StringBuilder version){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameCrash_nativeCallFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static void GameCrash_nativeCallFuncWithParam(string functionName, GameParam[] param,int count){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern int GameCrash_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static int GameCrash_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return 0;
		}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern float GameCrash_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static float GameCrash_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return 0;
		}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameCrash_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static bool GameCrash_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return false;
		}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameCrash_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value);
#else
		private static void GameCrash_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value){}
#endif
	}
	
}


