﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_IAnimationJob : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ProcessAnimation(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			UnityEngine.Animations.IAnimationJob self=(UnityEngine.Animations.IAnimationJob)checkSelf(l);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l, 2, out a1);
			self.ProcessAnimation(a1);
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
	static public int ProcessRootMotion(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			UnityEngine.Animations.IAnimationJob self=(UnityEngine.Animations.IAnimationJob)checkSelf(l);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l, 2, out a1);
			self.ProcessRootMotion(a1);
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
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Animations.IAnimationJob");
		addMember(l,ProcessAnimation);
		addMember(l,ProcessRootMotion);
		createTypeMetatable(l,null, typeof(UnityEngine.Animations.IAnimationJob));
	}
}
