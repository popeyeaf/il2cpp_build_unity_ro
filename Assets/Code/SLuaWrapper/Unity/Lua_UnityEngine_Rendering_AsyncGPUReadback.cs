﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Rendering_AsyncGPUReadback : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int WaitAllRequests_s(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			UnityEngine.Rendering.AsyncGPUReadback.WaitAllRequests();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			UnityEngine.Profiling.Profiler.EndSample();
		}
		#endif
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Request_s(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.ComputeBuffer),typeof(System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest>))){
				UnityEngine.ComputeBuffer a1;
				checkType(l, 1, out a1);
				System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest> a2;
				checkDelegate(l,2,out a2);
				var ret=UnityEngine.Rendering.AsyncGPUReadback.Request(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.GraphicsBuffer),typeof(System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest>))){
				UnityEngine.GraphicsBuffer a1;
				checkType(l, 1, out a1);
				System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest> a2;
				checkDelegate(l,2,out a2);
				var ret=UnityEngine.Rendering.AsyncGPUReadback.Request(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.Texture a1;
				checkType(l, 1, out a1);
				System.Int32 a2;
				checkType(l, 2, out a2);
				System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest> a3;
				checkDelegate(l,3,out a3);
				var ret=UnityEngine.Rendering.AsyncGPUReadback.Request(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.ComputeBuffer),typeof(int),typeof(int),typeof(System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest>))){
				UnityEngine.ComputeBuffer a1;
				checkType(l, 1, out a1);
				System.Int32 a2;
				checkType(l, 2, out a2);
				System.Int32 a3;
				checkType(l, 3, out a3);
				System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest> a4;
				checkDelegate(l,4,out a4);
				var ret=UnityEngine.Rendering.AsyncGPUReadback.Request(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.GraphicsBuffer),typeof(int),typeof(int),typeof(System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest>))){
				UnityEngine.GraphicsBuffer a1;
				checkType(l, 1, out a1);
				System.Int32 a2;
				checkType(l, 2, out a2);
				System.Int32 a3;
				checkType(l, 3, out a3);
				System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest> a4;
				checkDelegate(l,4,out a4);
				var ret=UnityEngine.Rendering.AsyncGPUReadback.Request(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Texture),typeof(int),typeof(UnityEngine.TextureFormat),typeof(System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest>))){
				UnityEngine.Texture a1;
				checkType(l, 1, out a1);
				System.Int32 a2;
				checkType(l, 2, out a2);
				UnityEngine.TextureFormat a3;
				checkEnum(l,3,out a3);
				System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest> a4;
				checkDelegate(l,4,out a4);
				var ret=UnityEngine.Rendering.AsyncGPUReadback.Request(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Texture),typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest>))){
				UnityEngine.Texture a1;
				checkType(l, 1, out a1);
				System.Int32 a2;
				checkType(l, 2, out a2);
				UnityEngine.Experimental.Rendering.GraphicsFormat a3;
				checkEnum(l,3,out a3);
				System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest> a4;
				checkDelegate(l,4,out a4);
				var ret=UnityEngine.Rendering.AsyncGPUReadback.Request(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==9){
				UnityEngine.Texture a1;
				checkType(l, 1, out a1);
				System.Int32 a2;
				checkType(l, 2, out a2);
				System.Int32 a3;
				checkType(l, 3, out a3);
				System.Int32 a4;
				checkType(l, 4, out a4);
				System.Int32 a5;
				checkType(l, 5, out a5);
				System.Int32 a6;
				checkType(l, 6, out a6);
				System.Int32 a7;
				checkType(l, 7, out a7);
				System.Int32 a8;
				checkType(l, 8, out a8);
				System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest> a9;
				checkDelegate(l,9,out a9);
				var ret=UnityEngine.Rendering.AsyncGPUReadback.Request(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Texture),typeof(int),typeof(int),typeof(int),typeof(int),typeof(int),typeof(int),typeof(int),typeof(UnityEngine.TextureFormat),typeof(System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest>))){
				UnityEngine.Texture a1;
				checkType(l, 1, out a1);
				System.Int32 a2;
				checkType(l, 2, out a2);
				System.Int32 a3;
				checkType(l, 3, out a3);
				System.Int32 a4;
				checkType(l, 4, out a4);
				System.Int32 a5;
				checkType(l, 5, out a5);
				System.Int32 a6;
				checkType(l, 6, out a6);
				System.Int32 a7;
				checkType(l, 7, out a7);
				System.Int32 a8;
				checkType(l, 8, out a8);
				UnityEngine.TextureFormat a9;
				checkEnum(l,9,out a9);
				System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest> a10;
				checkDelegate(l,10,out a10);
				var ret=UnityEngine.Rendering.AsyncGPUReadback.Request(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Texture),typeof(int),typeof(int),typeof(int),typeof(int),typeof(int),typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest>))){
				UnityEngine.Texture a1;
				checkType(l, 1, out a1);
				System.Int32 a2;
				checkType(l, 2, out a2);
				System.Int32 a3;
				checkType(l, 3, out a3);
				System.Int32 a4;
				checkType(l, 4, out a4);
				System.Int32 a5;
				checkType(l, 5, out a5);
				System.Int32 a6;
				checkType(l, 6, out a6);
				System.Int32 a7;
				checkType(l, 7, out a7);
				System.Int32 a8;
				checkType(l, 8, out a8);
				UnityEngine.Experimental.Rendering.GraphicsFormat a9;
				checkEnum(l,9,out a9);
				System.Action<UnityEngine.Rendering.AsyncGPUReadbackRequest> a10;
				checkDelegate(l,10,out a10);
				var ret=UnityEngine.Rendering.AsyncGPUReadback.Request(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Request to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			UnityEngine.Profiling.Profiler.EndSample();
		}
		#endif
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Rendering.AsyncGPUReadback");
		addMember(l,WaitAllRequests_s);
		addMember(l,Request_s);
		createTypeMetatable(l,null, typeof(UnityEngine.Rendering.AsyncGPUReadback));
	}
}
