using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace game {
	public enum PayResultCode
	{
		kPaySuccess = 0,/**< enum value is callback of succeeding in paying . */
		kPayFail,/**< enum value is callback of failing to pay . */
		kPayCancel,/**< enum value is callback of canceling to pay . */
		kPayNetworkError,/**< enum value is callback of network error . */
		kPayProductionInforIncomplete,/**< enum value is callback of incompleting info . */
		kPayInitSuccess,/**< enum value is callback of succeeding in initing sdk . */
		kPayInitFail,/**< enum value is callback of failing to init sdk . */
		kPayNowPaying,/**< enum value is callback of paying now . */
		kPayRechargeSuccess,/**< enum value is callback of  succeeding in recharging. */
		kPayExtension = 30000 /**< enum value is  extension code . */
	} ;
	/** @brief RequestResultCode enum, with inline docs */
	public enum RequestResultCode
	{
		kRequestSuccess = 31000,/**< enum value is callback of succeeding in paying . */
		kRequestFail/**< enum value is callback of failing to pay . */
	} ;
	public class GameIAP
	{
		private static GameIAP _instance;
		
		public static GameIAP getInstance() {
			if( null == _instance ) {
				_instance = new GameIAP();
			}
			return _instance;
		}

		/**
   	 	@brief pay for product
   		 @param info The info of product, must contains key:
   		 @warning  Look at the manual of plugins.

    	*/

		public  void payForProduct(Dictionary<string,string> info,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string value = GameUtil.dictionaryToString (info);
			GameIAP_nativePayForProduct(value,pluginId);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		/**
    	 @brief get order id
    	 @return the order id
    	 */

		public  string getOrderId(string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder value = new StringBuilder ();
			value.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameIAP_nativeGetOrderId (value,pluginId);
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
     	@brief Check function the plugin support or not
     	*/
		
		public  bool  isFunctionSupported (string functionName, string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return GameIAP_nativeIsFunctionSupported (functionName,pluginId);
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
			GameIAP_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		/**
    	 @brief set pListener The callback object for IAP result
    	 @param the MonoBehaviour object
    	 @param the callback of function
    	 */

		public  void setListener(MonoBehaviour gameObject,string functionName)
		{
#if UNITY_ANDROID  
			GameUtil.registerActionCallback (GameType.IAP, gameObject, functionName);
#elif UNITY_IOS
			string gameObjectName = gameObject.gameObject.name;
			GameIAP_nativeSetListener(gameObjectName,functionName);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief get plugin ids
     	@return List<string> the plugin ids
     	*/

		public List<string> getPluginId()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder value = new StringBuilder ();
			value.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameIAP_nativeGetPluginId (value);
			List<string> list = GameUtil.StringToList (value.ToString());
			return list;
#else
			Debug.Log("This platform does not support!");
			return null;
#endif
		}

		/**
   		 @brief change the state of paying
    	 @param the state
		*/

		public void resetPayState()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameIAP_nativeResetPayState ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
		 * Get Plugin version
		 * @param  pluginid
		 * @return string
	 	*/

		public  string getPluginVersion(string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			StringBuilder version = new StringBuilder();
			version.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameIAP_nativeGetPluginVersion (version,pluginId);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		/**
		 * Get SDK version
		 *@param  pluginid 
		 * @return string
	 	*/

		public  string getSDKVersion(string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameIAP_nativeGetSDKVersion (version,pluginId);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		
		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  GameParam param 
   		 *@param  pluginid
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, GameParam param,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			GameIAP_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count,pluginId);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  List<GameParam> param 
   		 *@param  pluginid
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, List<GameParam> param = null,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			if (param == null) 
			{
				GameIAP_nativeCallFuncWithParam (functionName, null, 0,pluginId);
				
			} else {
				GameIAP_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count,pluginId);
			}
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  GameParam param 
   		 *@param  pluginid
    	 *@return int
    	 */
		public  int callIntFuncWithParam(string functionName, GameParam param,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			return GameIAP_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count,pluginId);
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  List<GameParam> param 
   		 *@param  pluginid
    	 *@return int
    	 */
		public  int  callIntFuncWithParam(string functionName, List<GameParam> param = null,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return GameIAP_nativeCallIntFuncWithParam (functionName, null, 0,pluginId);
				
			} else {
				return GameIAP_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count,pluginId);
			}
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  GameParam param 
   		 *@param  pluginid
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, GameParam param,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			return GameIAP_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count,pluginId);
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  List<GameParam> param 
   		 *@param  pluginid
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, List<GameParam> param = null,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return GameIAP_nativeCallFloatFuncWithParam (functionName, null, 0,pluginId);
				
			} else {
				return GameIAP_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count,pluginId);
			}
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  GameParam param 
   		 *@param  pluginid
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, GameParam param,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			return GameIAP_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count,pluginId);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  List<GameParam> param
   		 *@param  pluginid
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, List<GameParam> param = null,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return GameIAP_nativeCallBoolFuncWithParam (functionName, null, 0,pluginId);
				
			} else {
				return GameIAP_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count,pluginId);
			}
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  GameParam param 
   		 *@param  pluginid 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, GameParam param,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			StringBuilder value = new StringBuilder();
			value.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameIAP_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value,pluginId);
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  List<GameParam> param 
   		 *@param  pluginid 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, List<GameParam> param = null,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder value = new StringBuilder();
			value.Capacity = GameUtil.MAX_CAPACITY_NUM;
			if (param == null)
			{
				GameIAP_nativeCallStringFuncWithParam (functionName, null, 0,value,pluginId);
				
			} else {
				GameIAP_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value,pluginId);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM,CallingConvention=CallingConvention.Cdecl)]
		private static extern void GameIAP_RegisterExternalCallDelegate(IntPtr functionPointer);
#else
		private static void GameIAP_RegisterExternalCallDelegate(IntPtr functionPointer){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameIAP_nativeSetListener(string gameName, string functionName);
#else
		private static void GameIAP_nativeSetListener(string gameName, string functionName){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameIAP_nativePayForProduct(string info,string pluginId);
#else
		private static void GameIAP_nativePayForProduct(string info,string pluginId){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameIAP_nativeGetOrderId(StringBuilder orderId,string pluginId);
#else
		private static void GameIAP_nativeGetOrderId(StringBuilder orderId,string pluginId){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameIAP_nativeResetPayState();
#else
		private static void GameIAP_nativeResetPayState(){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameIAP_nativeIsFunctionSupported(string functionName, string pluginId);
#else
		private static bool GameIAP_nativeIsFunctionSupported(string functionName, string pluginId)
		{
			return false;
		}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameIAP_nativeSetDebugMode(bool bDebug);
#else
		private static void GameIAP_nativeSetDebugMode(bool bDebug){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameIAP_nativeGetPluginId(StringBuilder pluginID);
#else
		private static void GameIAP_nativeGetPluginId(StringBuilder pluginID){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameIAP_nativeGetPluginVersion(StringBuilder version, string pluginId);
#else
		private static void GameIAP_nativeGetPluginVersion(StringBuilder version, string pluginId){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameIAP_nativeGetSDKVersion(StringBuilder version, string pluginId);
#else
		private static void GameIAP_nativeGetSDKVersion(StringBuilder version, string pluginId){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameIAP_nativeCallFuncWithParam(string functionName, GameParam[] param,int count, string pluginId);
#else
		private static void GameIAP_nativeCallFuncWithParam(string functionName, GameParam[] param,int count, string pluginId){}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern int GameIAP_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count, string pluginId);
#else
		private static int GameIAP_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count, string pluginId)
		{
			return 0;
		}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern float GameIAP_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count, string pluginId);
#else
		private static float GameIAP_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count, string pluginId)
		{
			return 0;
		}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameIAP_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count, string pluginId);
#else
		private static bool GameIAP_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count, string pluginId)
		{
			return false;
		}
#endif
		
#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameIAP_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value, string pluginId);
#else
		private static void GameIAP_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value, string pluginId){}
#endif
	}
	
}


