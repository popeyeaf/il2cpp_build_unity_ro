﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_U2D_SpriteRendererDataAccessExtensions : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DeactivateDeformableBuffer_s(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#endif
			UnityEngine.SpriteRenderer a1;
			checkType(l, 1, out a1);
			UnityEngine.U2D.SpriteRendererDataAccessExtensions.DeactivateDeformableBuffer(a1);
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
		getTypeTable(l,"UnityEngine.U2D.SpriteRendererDataAccessExtensions");
		addMember(l,DeactivateDeformableBuffer_s);
		createTypeMetatable(l,null, typeof(UnityEngine.U2D.SpriteRendererDataAccessExtensions));
	}
}
