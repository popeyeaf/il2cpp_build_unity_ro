using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace game {
	public enum AccountType
	{
		ANONYMOUS,/**< enum value is anonymous typek. */
		REGISTED,/**< enum value is registed type. */
		SINA_WEIBO,/**< enum value is sineweibo type. */
		TENCENT_WEIBO,/**< enum value is tecentweibo type */
		QQ,/**< enum value is qq type */
		ND91,/**< enum value is nd91 type. */

	} ;
	public enum AccountOperate
	{
		LOGIN,/**< enum value is the login operate. */
		LOGOUT,/**< enum value is the logout operate. */
		REGISTER,/**< enum value is the register operate. */

	} ;
	public enum AccountGender
	{
		MALE,/**< enum value is male. */
		FEMALE,/**< enum value is female. */
		UNKNOWN,/**< enum value is unknow. */

		
	} ;
	public enum TaskType
	{
		GUIDE_LINE,/**< enum value is the guideline type.. */
		MAIN_LINE,/**< enum value is the mainline type.. */
		BRANCH_LINE,/**<enum value is the branchline type.. */
		DAILY,/**< enum value is the daily type.. */
		ACTIVITY,/**< enum value is the activity type.  */
		OTHER,/**< enum value is other type. */

	} ;
	public class GameAnalytics
	{
		private static GameAnalytics _instance;
		
		public static GameAnalytics getInstance() {
			if( null == _instance ) {
				_instance = new GameAnalytics();
			}
			return _instance;
		}

		/**
     	@brief Start a new session.
    	 */

		public  void startSession()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAnalytics_nativeStartSession ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	@brief Stop a session.
    	 @warning This interface only worked on android
    	 */

		public  void stopSession()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAnalytics_nativeStopSession ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief Set the timeout for expiring a session.
    	 @param millis In milliseconds as the unit of time.
    	 @note It must be invoked before calling startSession.
    	 */

		public  void setSessionContinueMillis(long millis)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAnalytics_nativeSetSessionContinueMillis (millis);
#else
			Debug.Log("This platform does not support!");
#endif

		}

		/**
     	@brief log an error
     	@param errorId The identity of error
     	@param message Extern message for the error
     	*/

		public  void  logError(string errorId, string message)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAnalytics_nativeLogError (errorId, message);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief log an event.
     	 @param eventId The identity of event
    	 @param paramMap Extern parameters of the event, use NULL if not needed.
     	*/

		public  void  logEvent (string errorId,Dictionary<string,string> paramMap = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string value;
			if (paramMap == null) value = null; 
			else value = GameUtil.dictionaryToString (paramMap);
			GameAnalytics_nativeLogEvent (errorId,value);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	@brief Track an event begin.
     	@param eventId The identity of event
     	*/

		public  void  logTimedEventBegin (string errorId)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAnalytics_nativeLogTimedEventBegin (errorId);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief Track an event end.
     	@param eventId The identity of event
    	 */

		public  void  logTimedEventEnd (string eventId)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAnalytics_nativeLogTimedEventEnd (eventId);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	@brief Whether to catch uncaught exceptions to server.
    	 @warning This interface only worked on android.
     	*/

		public  void  setCaptureUncaughtException (bool enabled)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAnalytics_nativeSetCaptureUncaughtException (enabled);
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
			return GameAnalytics_nativeIsFunctionSupported (functionName);
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
			GameAnalytics_nativeSetDebugMode (bDebug);
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
			GameAnalytics_nativeGetPluginVersion (version);
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
			GameAnalytics_nativeGetSDKVersion (version);
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
			GameAnalytics_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
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
				GameAnalytics_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				GameAnalytics_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GameAnalytics_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GameAnalytics_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return GameAnalytics_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GameAnalytics_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GameAnalytics_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return GameAnalytics_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GameAnalytics_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GameAnalytics_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return GameAnalytics_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
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
			GameAnalytics_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
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
				GameAnalytics_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				GameAnalytics_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeStartSession();
#else
		private static void GameAnalytics_nativeStartSession(){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeStopSession();
#else
		private static void GameAnalytics_nativeStopSession(){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeSetSessionContinueMillis(long milli);
#else
		private static void GameAnalytics_nativeSetSessionContinueMillis(long milli){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeLogError(string errorId, string message);
#else
		private static void GameAnalytics_nativeLogError(string errorId, string message){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeLogEvent(string eventId, string message);
#else
		private static void GameAnalytics_nativeLogEvent(string eventId, string message){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeLogTimedEventBegin(string eventId);
#else
		private static void GameAnalytics_nativeLogTimedEventBegin(string eventId){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeLogTimedEventEnd(string eventId);
#else
		private static void GameAnalytics_nativeLogTimedEventEnd(string eventId){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeSetCaptureUncaughtException(bool enabled);
#else
		private static void GameAnalytics_nativeSetCaptureUncaughtException(bool enabled){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameAnalytics_nativeIsFunctionSupported(string functionName);
#else
		private static bool GameAnalytics_nativeIsFunctionSupported(string functionName)
		{
			return false;
		}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeSetDebugMode(bool bDebug);
#else
		private static void GameAnalytics_nativeSetDebugMode(bool bDebug){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeGetPluginVersion(StringBuilder version);
#else
		private static void GameAnalytics_nativeGetPluginVersion(StringBuilder version){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeGetSDKVersion(StringBuilder version);
#else
		private static void GameAnalytics_nativeGetSDKVersion(StringBuilder version){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeCallFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static void GameAnalytics_nativeCallFuncWithParam(string functionName, GameParam[] param,int count){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern int GameAnalytics_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static int GameAnalytics_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return 0;
		}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern float GameAnalytics_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static float GameAnalytics_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return 0;
		}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameAnalytics_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static bool GameAnalytics_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return false;
		}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAnalytics_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value);
#else
		private static void GameAnalytics_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value){}
#endif
	}
	
}


