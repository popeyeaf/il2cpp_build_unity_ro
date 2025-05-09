using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace game {
	public enum AdsResultCode
	{
		kAdsReceived = 0,           /**< enum the callback: the ad is received is at center. */
		
		kAdsShown,                  /**< enum the callback: the advertisement dismissed. */
		kAdsDismissed,             /**< enum the callback: the advertisement dismissed. */
		
		kPointsSpendSucceed,       /**< enum the callback: the points spend succeed. */
		kPointsSpendFailed,        /**< enum the callback: the points spend failed. */
		
		
		
		kNetworkError,              /**< enum the callback of Network error at center. */
		kUnknownError,              /**< enum the callback of Unknown error. */
		kOfferWallOnPointsChanged,   /**< enum the callback of Changing the point of offerwall. */
		kAdsExtension = 40000 /**< enum value is  extension code . */
	} ;
	/** @brief AdsPos enum, with inline docs */
	public enum AdsPos
	{
		kPosCenter = 0,/**< enum the toolbar is at center. */
		kPosTop,/**< enum the toolbar is at top. */
		kPosTopLeft,/**< enum the toolbar is at topleft. */
		kPosTopRight,/**< enum the toolbar is at topright. */
		kPosBottom,/**< enum the toolbar is at bottom. */
		kPosBottomLeft,/**< enum the toolbar is at bottomleft. */
		kPosBottomRight,/**< enum the toolbar is at bottomright. */
	};
	/** @brief AdsType enum, with inline docs */
	public enum AdsType
	{
		AD_TYPE_BANNER = 0,/**< enum value is banner ads . */
		AD_TYPE_FULLSCREEN,/**< enum value is fullscreen ads . */
		AD_TYPE_MOREAPP,/**< enum value is moreapp ads . */
		AD_TYPE_OFFERWALL,/**< enum value is offerwall ads . */
	} ;

	public class GameAds
	{
		
		private static GameAds _instance;
		
		public static GameAds getInstance() {
			if( null == _instance ) {
				_instance = new GameAds();
			}
			return _instance;
		}

		
		/**
		 * 
		* @Title: showAds 
		* @Description: show ad with the type and idx
		* @param @param adsType  the type of ad
		* @param @param idx     
		* @return void   
	 	*/

		public  void showAds(AdsType adsType, int idx = 1)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAds_nativeShowAds (adsType,idx);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
	 	* 
		* @Title: hideAds 
		* @Description: hide ad with the type and idx
		* @param @param adsType  the type of ad
		* @param @param idx     
		* @return void   
		 */

		public  void hideAds(AdsType adsType, int idx = 1)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAds_nativeHideAds (adsType,idx);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
-		 * 
-		* @Title: preloadAds 
-		* @Description: preload ad with the type and idx
-		* @param @param adsType  the type of ad
-		* @param @param idx     
-		* @return void   
-		 */
			

		public void  preloadAds(AdsType adsType, int idx = 1)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAds_nativePreloadAds (adsType,idx);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
		 * 
		* @Title: queryPoints 
		* @Description: query the ponits in the type of offerwall 
		* @param @return     
		* @return float   
		 */

		public  float queryPoints()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return GameAds_nativeQueryPoints ();
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
		 * 
		* @Title: spendPoints 
		* @Description: spend the ponits in the type of offerwall 
		* @param @param points     
		* @return void   
		 */
		public  void spendPoints (int points)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAds_nativeSpendPoints (points);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
		 * 
		* @Title: isAdTypeSupported 
		* @Description: does the plugin support the type of ad
		* @param @param adsType
		* @param @return     
		* @return boolean   
	 	*/
		public bool isAdTypeSupported(AdsType adType)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return GameAds_nativeIsAdTypeSupported (adType);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
			
		}

		/**
     	@brief Check function the plugin support or not
     	*/
		
		public  bool  isFunctionSupported (string functionName)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return GameAds_nativeIsFunctionSupported (functionName);
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
			GameAds_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief set pListener The callback object for ads result
    	 @param the MonoBehaviour object
    	 @param the callback of function
    	 */

		public  void setListener(MonoBehaviour gameObject,string functionName)
		{
#if UNITY_ANDROID
			GameUtil.registerActionCallback (GameType.Ads, gameObject, functionName);
#elif UNITY_IOS
			string gameObjectName = gameObject.gameObject.name;
			GameAds_nativeSetListener(gameObjectName,functionName);
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
			GameAds_nativeGetPluginVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
		 * Get Sdk version
		 * 
		 * @return string
		 */

		public  string getSDKVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameAds_nativeGetSDKVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		
		/**
    	 *@brief methods for reflections
    	 *@param function name
    	 *@param GameParam* param
     	*@return void
    	 */

		public  void callFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			GameAds_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
    	 *@param function name
    	 *@param List<GameParam> params
    	 *@return void
    	 */

		public  void callFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null) 
			{
				GameAds_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				GameAds_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GameAds_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GameAds_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return GameAds_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GameAds_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GameAds_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return GameAds_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return GameAds_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return GameAds_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return GameAds_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
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
			GameAds_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
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
				GameAds_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				GameAds_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM,CallingConvention=CallingConvention.Cdecl)]
		private static extern void GameAds_RegisterExternalCallDelegate(IntPtr functionPointer);
#else
		private static void GameAds_RegisterExternalCallDelegate(IntPtr functionPointer){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAds_nativeSetListener(string gameName, string functionName);
#else
		private static void GameAds_nativeSetListener(string gameName, string functionName){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAds_nativeShowAds(AdsType adsType, int idx = 1);
#else
		private static void GameAds_nativeShowAds(AdsType adsType, int idx = 1){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAds_nativeHideAds(AdsType adsType, int idx = 1);
#else
		private static void GameAds_nativeHideAds(AdsType adsType, int idx = 1){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAds_nativePreloadAds(AdsType adsType, int idx = 1);
#else
		private static void GameAds_nativePreloadAds(AdsType adsType, int idx = 1){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern float GameAds_nativeQueryPoints();
#else
		private static float GameAds_nativeQueryPoints()
		{
			return 0;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAds_nativeSpendPoints(int points);
#else
		private static void GameAds_nativeSpendPoints(int points){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameAds_nativeIsAdTypeSupported(AdsType adsType);
#else
		private static bool GameAds_nativeIsAdTypeSupported(AdsType adsType)
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameAds_nativeIsFunctionSupported(string functionName);
#else
		private static bool GameAds_nativeIsFunctionSupported(string functionName)
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAds_nativeSetDebugMode(bool bDebug);
#else
		private static void GameAds_nativeSetDebugMode(bool bDebug){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAds_nativeGetPluginVersion(StringBuilder version);
#else
		private static void GameAds_nativeGetPluginVersion(StringBuilder version){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAds_nativeGetSDKVersion(StringBuilder version);
#else
		private static void GameAds_nativeGetSDKVersion(StringBuilder version){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAds_nativeCallFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static void GameAds_nativeCallFuncWithParam(string functionName, GameParam[] param,int count){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern int GameAds_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static int GameAds_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return 0;
		}
	#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern float GameAds_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static float GameAds_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return 0;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameAds_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count);
#else
		private static bool GameAds_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count)
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAds_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value);
#else
		private static void GameAds_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value){}
#endif
	}
}


