﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_ISelectHandler : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnSelect(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			UnityEngine.EventSystems.ISelectHandler self=(UnityEngine.EventSystems.ISelectHandler)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l, 2, out a1);
			self.OnSelect(a1);
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
		getTypeTable(l,"UnityEngine.EventSystems.ISelectHandler");
		addMember(l,OnSelect);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.ISelectHandler));
	}
}
