using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace game {

	public enum ToolBarPlace
	{
		kToolBarTopLeft = 1,/**< enum the toolbar is at topleft. */
		kToolBarTopRight,/**< enum the toolbar is at topright. */
		kToolBarMidLeft,/**< enum the toolbar is at midleft. */
		kToolBarMidRight,/**< enum the toolbar is at midright. */
		kToolBarBottomLeft,/**< enum the toolbar is at bottomleft. */
		kToolBarBottomRight,/**< enum the toolbar is at bottomright. */
	} ;

	public enum UserActionResultCode
	{
		kInitSuccess = 0,/**< enum value is callback of succeeding in initing sdk. */
		kInitFail,/**< enum  value is callback of failing to init sdk. */
		kLoginSuccess,/**< enum value is callback of succeeding in login.*/
		kLoginNetworkError,/**< enum value is callback of network error*/
		kLoginNoNeed,/**< enum value is callback of no need login.*/
		kLoginFail,/**< enum value is callback of failing to login. */
		kLoginCancel,/**< enum value is callback of canceling to login. */
		kLogoutSuccess,/**< enum value is callback of succeeding in logout. */
		kLogoutFail,/**< enum value is callback of failing to logout. */
		kPlatformEnter,/**< enum value is callback after enter platform. */
		kPlatformBack,/**< enum value is callback after exit antiAddiction. */
		kPausePage,/**< enum value is callback after exit pause page. */
		kExitPage,/**< enum value is callback after exit exit page. */
		kAntiAddictionQuery,/**< enum value is callback after querying antiAddiction. */
		kRealNameRegister,/**< enum value is callback after registering realname. */
		kAccountSwitchSuccess,/**< enum alue is callback of succeeding in switching account. */
		kAccountSwitchFail,/**< enum value is callback of failing to switch account. */
		kOpenShop,/**< enum value is callback of open the shop. */
		kUserExtension = 50000 /**< enum value is  extension code . */
		
		
	} ;

	public class GameUser
	{
		private static GameUser _instance;
		
		public static GameUser getInstance() {
			if( null == _instance ) {
				_instance = new GameUser();
			}
			return _instance;
		}
		/**
    	 @brief User login
    	 */

		public  void login()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			GameUser_nativeLogin ();
#else
			Debug.Log("This platform does not support!");
#endif
		}
		/**
     	@brief User login
     	 	if the process of logining need to know  the param of server_id ,
     	 	you can use the function
     	 	and if you must change oauthloginserver, you can add the param of oauthLoginServer
    	 @param server_id
    	 @param oauthLoginServer
    	*/

		public  void login(string serverID,string authLoginServer = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			GameUser_nativeLoginWithParam (serverID,authLoginServer);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		/**
   	 	 @brief Get user ID
    	 @return If user logined, return value is userID;
             else return value is empty string.
    	 */

		public  string getUserID()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			StringBuilder userID = new StringBuilder();
			userID.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameUser_nativeGetUserID (userID);
			return userID.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
   	 	 @brief Check whether the user logined or not
    	 @return If user logined, return value is true;
             else return value is false.
    	 */

		public  bool isLogined()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			return GameUser_nativeIsLogined ();
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}
		/**
     	@brief Check function the plugin support or not
    	 @param the name of plugin
    	 @return if the function support ,return true
    	 	 	 else retur false
    	 */

		public  bool isFunctionSupported (string functionName)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			return GameUser_nativeIsFunctionSupported (functionName);
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
			GameUser_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief set pListener The callback object for user result
    	 @param the MonoBehaviour object
    	 @param the callback of function
    	 */

		public  void setListener(MonoBehaviour gameObject,string functionName)
		{
#if UNITY_ANDROID  
			GameUtil.registerActionCallback (GameType.User, gameObject, functionName);
#elif UNITY_IOS
			string gameObjectName = gameObject.gameObject.name;
			GameUser_nativeSetListener(gameObjectName,functionName);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		/**
     	@brief get plugin id
   		 @return the plugin id
    	 */

		public string getPluginId()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			StringBuilder pluginlId = new StringBuilder();
			pluginlId.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameUser_nativeGetPluginId (pluginlId);
			return pluginlId.ToString();
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

		public  string getPluginVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			StringBuilder version = new StringBuilder();
			version.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameUser_nativeGetPluginVersion (version);
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
			GameUser_nativeGetSDKVersion (version);
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
			GameUser_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
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
				GameUser_nativeCallFuncWithParam (functionName, null, 0);

			} else {
				GameUser_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GameUser_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GameUser_nativeCallIntFuncWithParam (functionName, null, 0);

			} else {
				return GameUser_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GameUser_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GameUser_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return GameUser_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GameUser_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GameUser_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return GameUser_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
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
			GameUser_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
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
				GameUser_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				GameUser_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM,CallingConvention=CallingConvention.Cdecl)]
		private static extern void GameUser_RegisterExternalCallDelegate(IntPtr functionPointer);
#else
		private static void GameUser_RegisterExternalCallDelegate(IntPtr functionPointer){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameUser_nativeLogin();
#else
		private static void GameUser_nativeLogin(){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameUser_nativeSetListener(string gameName, string functionName);
#else
		private static void GameUser_nativeSetListener(string gameName, string functionName){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameUser_nativeLoginWithParam(string serverID, string authLoginServer);
#else
		private static void GameUser_nativeLoginWithParam(string serverID, string authLoginServer){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameUser_nativeGetUserID(StringBuilder userID);
#else
		private static void GameUser_nativeGetUserID(StringBuilder userID){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameUser_nativeIsLogined();
#else
		private static bool GameUser_nativeIsLogined()
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameUser_nativeIsFunctionSupported(string functionName);
#else
		private static bool GameUser_nativeIsFunctionSupported(string functionName)
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameUser_nativeSetDebugMode(bool bDebug);
#else
		private static void GameUser_nativeSetDebugMode(bool bDebug){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameUser_nativeGetPluginId(StringBuilder pluginID);
#else
		private static void GameUser_nativeGetPluginId(StringBuilder pluginID){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameUser_nativeGetPluginVersion(StringBuilder version);
#else
		private static void GameUser_nativeGetPluginVersion(StringBuilder version){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameUser_nativeGetSDKVersion(StringBuilder version);
#else
		private static void GameUser_nativeGetSDKVersion(StringBuilder version){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameUser_nativeCallFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static void GameUser_nativeCallFuncWithParam(string functionName, GameParam[] param,int count){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern int GameUser_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static int GameUser_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return 0;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern float GameUser_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static float GameUser_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return 0;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameUser_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static bool GameUser_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameUser_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value);
#else
		private static void GameUser_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value){}
#endif
	}

}


