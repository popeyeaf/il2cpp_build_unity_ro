using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using RO;
using LitJson;
using RO.Config;
using System;
using System.IO;

namespace EditorTool
{
	[CreateAssetMenu ()]
	public class LocalBuild :ScriptableObject
	{
		public string Branch = "";
		public string SDK = "";
		public List<string> VersionUrls;
		public string plat = "";
		public bool zipBundles = true;
		public bool skipVersionCheck = false;

		public void Build ()
		{
			if (Branch != AppEnvConfig.Instance.channelEnv || SDK != AppEnvConfig.Instance.sdk) {
				Debug.Log ("修改了channel 或 sdk");
				string Define = ScriptDefines.ReplaceByPart ("_LINK_NATIVE", string.Format ("_{0}_LINK_NATIVE_", SDK));
				PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.iOS, Define);
				BuildBundleEnvInfo.SetEnv (Branch, SDK);
			}

			HttpOperationJson hj = HttpOperationJson.ReadFromResourceFolder ();
			JsonData elementsData = hj.data ["elements"];
			JsonData urlData = hj.data ["urls"];
			bool jsonChange = false;
			if (elementsData != null) {
				if (plat != elementsData ["plat"].ToString ()) {
					jsonChange = true;
				}
			}
			if (urlData != null) {
				if (urlData.IsArray) {
					if (VersionUrls.Count != urlData.Count) {
						jsonChange = true;
					} else {
						for (int i = 0; i < urlData.Count; i++) {
							string url = urlData [i].ToString ();
							if (VersionUrls.Contains (url) == false) {
								jsonChange = true;
							}
						}
					}
				}
			}
			if (jsonChange || skipVersionCheck) {
				List<string> elements = new List<string> ();
				elements.Add (string.Format ("plat:{0}", plat));
				if (skipVersionCheck) {
					elements.Add ("skipVersion:true");
				}
				Debug.Log ("版本服务器url或Plat");
				HttpOperationJsonEditor.SetHttpJson (VersionUrls, elements);
			}

			if (zipBundles) {
				#if UNITY_IOS
				IOSAutoBuilder.PerformiOSBuildBundleMode ();
				#elif UNITY_ANDROID
			AndroidAutoBuilder.PerformAndroidBuildBundleMode();
				#endif
			} else {
				string Define = ScriptDefines.Add ("DEBUG_DRAW");
				Define = ScriptDefines.Add ("DEBUG_DRAW;LUA_5_3");
				var scenes = new List<string> ();
				foreach (var scene in EditorBuildSettings.scenes) {
					if (scene.enabled) {
						scenes.Add (scene.path);
					}
				}
				#if UNITY_IOS
				PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.iOS, Define);
				BuildPipeline.BuildPlayer (scenes.ToArray (), GetXcodeProjFolder ("ROIOS"), BuildTarget.iOS, BuildOptions.None); // or None to create new one
				#elif UNITY_ANDROID
				PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.Android, Define);
				PlayerSettings.Android.keystorePass = "111111";
				PlayerSettings.Android.keyaliasPass = "111111";
				BuildPipeline.BuildPlayer (scenes.ToArray (), "../../" + "ROAndroid", BuildTarget.Android, BuildOptions.None); // or None to create new one
				#endif
			}
			AssetDatabase.Refresh ();
		}

		static string GetXcodeProjFolder (string path)
		{
			string unityProjPath = Application.dataPath;
			List<string> pathSperate = new List<string> (unityProjPath.Split (Path.DirectorySeparatorChar));
			pathSperate.Remove ("Assets");
			if (pathSperate.Count > 2) {
				pathSperate.RemoveAt (pathSperate.Count - 1);
				pathSperate.RemoveAt (pathSperate.Count - 1);
			}
			string folder = "/";
			for (int i = 0; i < pathSperate.Count; i++) {
				folder = Path.Combine (folder, pathSperate [i]);
			}
			folder = Path.Combine (folder, path);
			Debug.Log ("XcodeProj: " + folder);
			return folder;
		}

		public void ReInitConfig ()
		{
			Branch = AppEnvConfig.Instance.channelEnv;
			SDK = AppEnvConfig.Instance.sdk;

			HttpOperationJson hj = HttpOperationJson.ReadFromResourceFolder ();
			JsonData elementsData = hj.data ["elements"];
			JsonData urlData = hj.data ["urls"];
			if (elementsData != null) {
				plat = elementsData ["plat"].ToString ();
			}
			if (urlData != null) {
				if (urlData.IsArray) {
					VersionUrls = new List<string> ();
					for (int i = 0; i < urlData.Count; i++) {
						string url = urlData [i].ToString ();
						VersionUrls.Add (url);
					}
				}
			}
			EditorUtility.SetDirty (this);
			AssetDatabase.SaveAssets ();
			AssetDatabase.Refresh ();
		}
	}

	[CustomEditor (typeof(LocalBuild))]
	public class LocalBuildEditor : Editor
	{
		LocalBuild _target;

		void OnEnable ()
		{
			_target = target as LocalBuild;
		}

		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI ();
			EditorGUILayout.Separator ();
			
			if (GUILayout.Button ("打包")) {
				EditorApplication.delayCall += _target.Build;
			}

			EditorGUILayout.Separator ();
			
			if (GUILayout.Button ("重新读取配置")) {
				_target.ReInitConfig ();
			}
			EditorGUILayout.HelpBox ("Branch一般不需要改动.URL和PLAT都可以问孔鸣.\n切记自己本地测完后，全部revert。不要上传，不要上传，不要上传因为测试而产生的改动", MessageType.Warning);
		}
	}
}
// namespace EditorTool
