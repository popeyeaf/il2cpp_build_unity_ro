using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace game {
	public enum PushActionResultCode
	{
		kPushReceiveMessage = 0,/**value is callback of Receiving Message . */
		kPushExtensionCode = 60000 /**< enum value is  extension code . */
		
		
	} ;
	public class GamePush
	{
		private static GamePush _instance;
		
		public static GamePush getInstance() {
			if( null == _instance ) {
				_instance = new GamePush();
			}
			return _instance;
		}

		/**
    	 *@brief start/register  Push services
   	 	 *@return void
    	 */

		public  void startPush()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GamePush_nativeStartPush ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	*@brief close Push services
    	 *@return void
    	 */

		public  void closePush()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GamePush_nativeClosePush ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	*@brief set alias
    	 *@param tags
     	*@return void
     	*/

		public  void setAlias(string alia)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GamePush_nativeSetAlias (alia);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	*@brief del alias
    	 *@param tags
     	*@return void
     	*/

		public  void delAlias(string alia)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GamePush_nativeDelAlias (alia);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief set tag
    	 *@param tags
    	 *@return void
    	 */

		public  void setTags (List<string> tags)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string value = GameUtil.ListToString(tags);
			GamePush_nativeSetTags (value);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief del tag
    	 *@param tags
    	 *@return void
    	 */

		public  void delTags (List<string> tags)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string value = GameUtil.ListToString(tags);
			GamePush_nativeDelTags (value);
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
			return GamePush_nativeIsFunctionSupported (functionName);
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
			GamePush_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief set pListener The callback object for push result
    	 @param the MonoBehaviour object
    	 @param the callback of function
    	 */

		public  void setListener(MonoBehaviour gameObject,string functionName)
		{
#if UNITY_ANDROID 
			GameUtil.registerActionCallback (GameType.Push, gameObject, functionName);
#elif UNITY_IOS
			string gameObjectName = gameObject.gameObject.name;
			GamePush_nativeSetListener(gameObjectName,functionName);
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
			GamePush_nativeGetPluginVersion (version);
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
			GamePush_nativeGetSDKVersion (version);
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
			GamePush_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
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
				GamePush_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				GamePush_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param GameParam param 
    	 *@return void
    	 */
		public  int callIntFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			return GamePush_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return void
    	 */
		public  int  callIntFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return GamePush_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return GamePush_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GamePush_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GamePush_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return GamePush_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GamePush_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GamePush_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return GamePush_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
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
			GamePush_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
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
				GamePush_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				GamePush_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM,CallingConvention=CallingConvention.Cdecl)]
		private static extern void GamePush_RegisterExternalCallDelegate(IntPtr functionPointer);
#else
		private static void GamePush_RegisterExternalCallDelegate(IntPtr functionPointer){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GamePush_nativeSetListener(string gameName, string functionName);
#else
		private static void GamePush_nativeSetListener(string gameName, string functionName){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GamePush_nativeStartPush();
#else
		private static void GamePush_nativeStartPush(){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GamePush_nativeClosePush();
#else
		private static void GamePush_nativeClosePush(){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GamePush_nativeSetAlias(string alia);
#else
		private static void GamePush_nativeSetAlias(string alia){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GamePush_nativeDelAlias(string alia);
#else
		private static void GamePush_nativeDelAlias(string alia){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GamePush_nativeSetTags(string tags);
#else
		private static void GamePush_nativeSetTags(string tags){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GamePush_nativeDelTags(string tags);
#else
		private static void GamePush_nativeDelTags(string tags){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GamePush_nativeIsFunctionSupported(string functionName);
#else
		private static bool GamePush_nativeIsFunctionSupported(string functionName)
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GamePush_nativeSetDebugMode(bool bDebug);
#else
		private static void GamePush_nativeSetDebugMode(bool bDebug){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GamePush_nativeGetPluginVersion(StringBuilder version);
#else
		private static void GamePush_nativeGetPluginVersion(StringBuilder version){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GamePush_nativeGetSDKVersion(StringBuilder version);
#else
		private static void GamePush_nativeGetSDKVersion(StringBuilder version){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GamePush_nativeCallFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static void GamePush_nativeCallFuncWithParam(string functionName, GameParam[] param,int count){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern int GamePush_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static int GamePush_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return 0;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern float GamePush_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static float GamePush_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return 0;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GamePush_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static bool GamePush_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GamePush_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value);
#else
		private static void GamePush_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value){}
#endif
	}
	
}


