﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_CubemapArray : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.CubemapArray o;
			if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.DefaultFormat),typeof(UnityEngine.Experimental.Rendering.TextureCreationFlags))){
				System.Int32 a1;
				checkType(l, 2, out a1);
				System.Int32 a2;
				checkType(l, 3, out a2);
				UnityEngine.Experimental.Rendering.DefaultFormat a3;
				checkEnum(l,4,out a3);
				UnityEngine.Experimental.Rendering.TextureCreationFlags a4;
				checkEnum(l,5,out a4);
				o=new UnityEngine.CubemapArray(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(UnityEngine.Experimental.Rendering.TextureCreationFlags))){
				System.Int32 a1;
				checkType(l, 2, out a1);
				System.Int32 a2;
				checkType(l, 3, out a2);
				UnityEngine.Experimental.Rendering.GraphicsFormat a3;
				checkEnum(l,4,out a3);
				UnityEngine.Experimental.Rendering.TextureCreationFlags a4;
				checkEnum(l,5,out a4);
				o=new UnityEngine.CubemapArray(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(UnityEngine.Experimental.Rendering.TextureCreationFlags),typeof(int))){
				System.Int32 a1;
				checkType(l, 2, out a1);
				System.Int32 a2;
				checkType(l, 3, out a2);
				UnityEngine.Experimental.Rendering.GraphicsFormat a3;
				checkEnum(l,4,out a3);
				UnityEngine.Experimental.Rendering.TextureCreationFlags a4;
				checkEnum(l,5,out a4);
				System.Int32 a5;
				checkType(l, 6, out a5);
				o=new UnityEngine.CubemapArray(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.TextureFormat),typeof(int),typeof(bool))){
				System.Int32 a1;
				checkType(l, 2, out a1);
				System.Int32 a2;
				checkType(l, 3, out a2);
				UnityEngine.TextureFormat a3;
				checkEnum(l,4,out a3);
				System.Int32 a4;
				checkType(l, 5, out a4);
				System.Boolean a5;
				checkType(l, 6, out a5);
				o=new UnityEngine.CubemapArray(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.TextureFormat),typeof(bool),typeof(bool))){
				System.Int32 a1;
				checkType(l, 2, out a1);
				System.Int32 a2;
				checkType(l, 3, out a2);
				UnityEngine.TextureFormat a3;
				checkEnum(l,4,out a3);
				System.Boolean a4;
				checkType(l, 5, out a4);
				System.Boolean a5;
				checkType(l, 6, out a5);
				o=new UnityEngine.CubemapArray(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.TextureFormat),typeof(bool))){
				System.Int32 a1;
				checkType(l, 2, out a1);
				System.Int32 a2;
				checkType(l, 3, out a2);
				UnityEngine.TextureFormat a3;
				checkEnum(l,4,out a3);
				System.Boolean a4;
				checkType(l, 5, out a4);
				o=new UnityEngine.CubemapArray(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			return error(l,"New object failed.");
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
	static public int GetPixels(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
				UnityEngine.CubemapFace a1;
				checkEnum(l,2,out a1);
				System.Int32 a2;
				checkType(l, 3, out a2);
				var ret=self.GetPixels(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
				UnityEngine.CubemapFace a1;
				checkEnum(l,2,out a1);
				System.Int32 a2;
				checkType(l, 3, out a2);
				System.Int32 a3;
				checkType(l, 4, out a3);
				var ret=self.GetPixels(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetPixels to call");
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetPixels32(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
				UnityEngine.CubemapFace a1;
				checkEnum(l,2,out a1);
				System.Int32 a2;
				checkType(l, 3, out a2);
				var ret=self.GetPixels32(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
				UnityEngine.CubemapFace a1;
				checkEnum(l,2,out a1);
				System.Int32 a2;
				checkType(l, 3, out a2);
				System.Int32 a3;
				checkType(l, 4, out a3);
				var ret=self.GetPixels32(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetPixels32 to call");
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetPixels(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
				UnityEngine.Color[] a1;
				checkArray(l, 2, out a1);
				UnityEngine.CubemapFace a2;
				checkEnum(l,3,out a2);
				System.Int32 a3;
				checkType(l, 4, out a3);
				self.SetPixels(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
				UnityEngine.Color[] a1;
				checkArray(l, 2, out a1);
				UnityEngine.CubemapFace a2;
				checkEnum(l,3,out a2);
				System.Int32 a3;
				checkType(l, 4, out a3);
				System.Int32 a4;
				checkType(l, 5, out a4);
				self.SetPixels(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetPixels to call");
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetPixels32(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
				UnityEngine.Color32[] a1;
				checkArray(l, 2, out a1);
				UnityEngine.CubemapFace a2;
				checkEnum(l,3,out a2);
				System.Int32 a3;
				checkType(l, 4, out a3);
				self.SetPixels32(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
				UnityEngine.Color32[] a1;
				checkArray(l, 2, out a1);
				UnityEngine.CubemapFace a2;
				checkEnum(l,3,out a2);
				System.Int32 a3;
				checkType(l, 4, out a3);
				System.Int32 a4;
				checkType(l, 5, out a4);
				self.SetPixels32(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetPixels32 to call");
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Apply(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
				self.Apply();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
				System.Boolean a1;
				checkType(l, 2, out a1);
				self.Apply(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
				System.Boolean a1;
				checkType(l, 2, out a1);
				System.Boolean a2;
				checkType(l, 3, out a2);
				self.Apply(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Apply to call");
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cubemapCount(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cubemapCount);
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_format(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.format);
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isReadable(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			UnityEngine.CubemapArray self=(UnityEngine.CubemapArray)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isReadable);
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
		getTypeTable(l,"UnityEngine.CubemapArray");
		addMember(l,GetPixels);
		addMember(l,GetPixels32);
		addMember(l,SetPixels);
		addMember(l,SetPixels32);
		addMember(l,Apply);
		addMember(l,"cubemapCount",get_cubemapCount,null,true);
		addMember(l,"format",get_format,null,true);
		addMember(l,"isReadable",get_isReadable,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.CubemapArray),typeof(UnityEngine.Texture));
	}
}
