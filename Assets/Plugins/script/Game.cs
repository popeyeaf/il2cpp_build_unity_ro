using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using System.Text;

namespace game
{

	public class Game
	{
		private static Game _instance;
		
		public static Game getInstance() {
			if( null == _instance ) {
				_instance = new Game();
			}
			return _instance;
		}

		/**
   		 @breif the init of AgentManager
   		 @param the appKey of game
    	 @param the appSecret of game
   		 @param the privateKey of game
    	 @param the url of oauthLoginServer
   		 @warning Must invoke this interface before loadALLPlugin
  		*/

		public  void init(string appKey, string appSecret, string privateKey, string authLoginServer)
		{

#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)
			Game_nativeInitPluginSystem (appKey, appSecret, privateKey, authLoginServer);
#else
			Debug.Log("This platform does not support!");
#endif
		}


		[Obsolete("This interface is obsolete!",false)]
		public  void loadALLPlugin()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			Debug.Log("This interface is obsolete!");
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief Get custom param
     	@return  return value is custom param for channel.
    	 */

		public  string getCustomParam()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder customParam = new StringBuilder();
			customParam.Capacity = GameUtil.MAX_CAPACITY_NUM;
			Game_nativeGetCustomParam (customParam);
			return customParam.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif

		}

		/**
    	 @brief Get channel ID
     	@return  return value is channel ID.
     	*/
		public  string getChannelId()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder channelId = new StringBuilder();
			channelId.Capacity = GameUtil.MAX_CAPACITY_NUM;
			Game_nativeGetChannelId (channelId);
			return channelId.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif

		}

		/**
    	 @brief Get framework version
     	@return  return value is framework version.
     	*/
		public  string getFrameworkVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = GameUtil.MAX_CAPACITY_NUM;
			Game_nativeGetFrameworkVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif


		}

		/**
     		@brief release the game
     	*/

		public  void release()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			Game_nativeRelease ();
#else
			Debug.Log("This platform does not support!");
#endif

		}

		/**
		 * 
		* @Title: isUserPluginExist 
		* @Description: is UserPlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isUserPluginExist()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return Game_nativeIsUserPluginExist ();
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
		 * 
		* @Title: isIAPPluginExist 
		* @Description: is IAPPlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isIAPPluginExist()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return Game_nativeIsIAPPluginExist ();
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
		 * 
		* @Title: isAdsPluginExist 
		* @Description: is AdsPlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isAdsPluginExist()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return Game_nativeIsAdsPluginExist ();
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
		 * 
		* @Title: isAnalyticsPluginExist 
		* @Description: is AnalyticsPlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isAnalyticsPluginExist()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return Game_nativeIsAnalyticsPluginExist ();
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
		 * 
		* @Title: isPushPluginExist 
		* @Description: is PushPlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isPushPluginExist()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return Game_nativeIsPushPluginExist ();
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
		 * 
		* @Title: isSharePluginExist 
		* @Description: is SharePlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isSharePluginExist()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return Game_nativeIsSharePluginExist ();
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
		 * 
		* @Title: isSocialPluginExist 
		* @Description: is SocialPlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isSocialPluginExist()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return Game_nativeIsSocialPluginExist ();
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
	 	* 
		* @Title: setIsAnaylticsEnabled 
		* @Description: choose to open or close
		* @param @param enabled    true or false  
		* @return void   
	 	*/

		public void setIsAnaylticsEnabled(bool enabled)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			Game_nativeSetIsAnaylticsEnabled (enabled);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
		 * 
		* @Title: isAnaylticsEnabled 
		* @Description: the status of Anayltics
		* @param @return    true or false    
		* @return boolean   
		 */

		public bool isAnaylticsEnabled()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return Game_nativeIsAnaylticsEnabled ();
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void Game_nativeInitPluginSystem(string appKey, string appSecret, string privateKey, string authLoginServer);
#else
		private static void Game_nativeInitPluginSystem(string appKey, string appSecret, string privateKey, string authLoginServer){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void Game_nativeLoadPlugins();
#else
		private static void Game_nativeLoadPlugins(){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void Game_nativeGetChannelId(StringBuilder channelId);
#else
		private static void Game_nativeGetChannelId(StringBuilder channelId){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void Game_nativeGetFrameworkVersion(StringBuilder version);
#else
		private static void Game_nativeGetFrameworkVersion(StringBuilder version){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void Game_nativeGetCustomParam(StringBuilder customParam);
#else
		private static void Game_nativeGetCustomParam(StringBuilder customParam){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void Game_nativeRelease();
#else
		private static void Game_nativeRelease(){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool Game_nativeIsUserPluginExist();
#else
		private static bool Game_nativeIsUserPluginExist()
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool Game_nativeIsIAPPluginExist();
#else
		private static bool Game_nativeIsIAPPluginExist()
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool Game_nativeIsAdsPluginExist();
#else
		private static bool Game_nativeIsAdsPluginExist()
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool Game_nativeIsAnalyticsPluginExist();
#else
		private static bool Game_nativeIsAnalyticsPluginExist()
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool Game_nativeIsSharePluginExist();
#else
		private static bool Game_nativeIsSharePluginExist()
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool Game_nativeIsSocialPluginExist();
#else
		private static bool Game_nativeIsSocialPluginExist()
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool Game_nativeIsPushPluginExist();
#else
		private static bool Game_nativeIsPushPluginExist()
		{
			return false;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void Game_nativeSetIsAnaylticsEnabled(bool enabled);
#else
		private static void Game_nativeSetIsAnaylticsEnabled(bool enabled){}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool Game_nativeIsAnaylticsEnabled();
#else
		private static bool Game_nativeIsAnaylticsEnabled()
		{
			return false;
		}
#endif

	}
}

