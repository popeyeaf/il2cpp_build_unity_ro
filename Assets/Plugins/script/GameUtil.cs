using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;
using System.Text.RegularExpressions;
namespace game {
	public enum GameType
	{
		Ads = 16,
		Analytics = 1,
		IAP = 8,
		Share = 2,
		User = 32,
		Social = 4,
		Push = 64,
		Crash = 128,
		Custom = 256,
		REC = 512
	} ;
	public class GameUtil 
	{
	#if !UNITY_EDITOR && UNITY_ANDROID
		public const string GAME_PLATFORM = "PluginProtocol";
	#else
		public const string GAME_PLATFORM= "__Internal";
	#endif
		public const int MAX_CAPACITY_NUM = 1024;
		/**
     	@brief the Dictionary type change to the string type 
    	 @param Dictionary<string,string> 
    	 @return  string
    	*/
		public static string dictionaryToString( Dictionary<string,string> maps  ) 
		{
			StringBuilder param = new StringBuilder();
			if ( null != maps ) {  
				foreach (KeyValuePair<string, string> kv in maps){
					if ( param.Length == 0)  
					{  
						param.AppendFormat("{0}={1}",kv.Key,kv.Value);
					}  
					else  
					{  
						param.AppendFormat("&{0}={1}",kv.Key,kv.Value); 
					} 
				} 
			}  
//			byte[] tempStr = Encoding.UTF8.GetBytes (param.ToString ());
//			string msgBody = Encoding.Default.GetString(tempStr);
			return param.ToString ();			
		}

		/**
     	@brief the Dictionary type change to the string type 
    	 @param Dictionary
    	 @return  string
    	*/
		public static Dictionary<string,string> stringToDictionary( string message ) 
		{
			Dictionary<string,string> param = new Dictionary<string,string>();
			if ( null != message) {
				if(message.Contains("&info="))
				{
					Regex regex = new Regex(@"code=(.*)&msg=(.*)&info=(.*)");
					string[] tokens = regex.Split(message);
					string code = tokens[1];
					string msg = tokens[2];
					string info = tokens[3];
					param.Add("code",code);
					param.Add("msg",msg);
					param.Add("info",info);
				}
				else
				{
					Regex regex = new Regex(@"code=(.*)&msg=(.*)");
					string[] tokens = regex.Split(message);
					string code = tokens[1];
					string msg = tokens[2];
					param.Add("code",code);
					param.Add("msg",msg);
				}
			}   
			
			return param;			
		}

		/**
     	@brief the List type change to the string type 
    	 @param List<string> 
    	 @return  string
    	*/
		public static string ListToString( List<string> list  ) 
		{
			StringBuilder param = new StringBuilder();
			if ( null != list ) {  
				foreach (string kv in list){
					if ( param.Length == 0)  
					{  
						param.AppendFormat("{0}",kv);
					}  
					else  
					{  
						param.AppendFormat("&{0}",kv); 
					} 
				} 
			}  
//			byte[] tempStr = Encoding.UTF8.GetBytes (param.ToString ());
//			string msgBody = Encoding.Default.GetString(tempStr);
			return param.ToString ();			
		}

		/**
     	@brief the string type change to the List type 
    	 @param string 
    	 @return  List<string>
    	*/
		public static List<string>   StringToList( string value  ) 
		{
			string[] temp = value.Split('&');
			List<string> param = new  List<string>();
			if ( null != temp ) {  
				foreach (string kv in temp){
					param.Add(kv); 
				} 
			}  
			
			return param;			
		}

#if !UNITY_EDITOR && UNITY_ANDROID		
		private static AndroidJavaClass mAndroidJavaClass;
#endif

		public static void registerActionCallback(GameType type,MonoBehaviour gameObject,string functionName)
		{
#if !UNITY_EDITOR && UNITY_ANDROID
			if (mAndroidJavaClass == null) 
			{
				mAndroidJavaClass = new AndroidJavaClass( "com.game.framework.unity.MessageHandle" );
			}
			string gameObjectName = gameObject.gameObject.name;
			mAndroidJavaClass.CallStatic( "registerActionResultCallback", new object[]{(int)type,gameObjectName,functionName});
#endif

		}




	}
}
