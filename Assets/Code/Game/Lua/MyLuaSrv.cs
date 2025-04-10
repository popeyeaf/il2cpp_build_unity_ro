
using UnityEngine;
using System.Collections;
using SLua;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using RO.Test;

[CustomLuaClass]
public class MyLuaSrv
{
    static MyLuaSrv _Instance;
    LuaSvr _origin;
    static Func<string, string> processFile;
    private static HashSet<string> ms_includedFiles = new HashSet<string>();

#if UNITY_IPHONE && !UNITY_EDITOR
    const string PB = "__Internal";
#else
    const string PB = "slua";
#endif

    public LuaState luaState {
        get { return LuaSvr.mainState; }
    }

    public LuaSvr origin {
        get {
            return _origin;
        }
    }

    public static bool EnablePrint =
#if UNITY_EDITOR || UNITY_EDITOR_OSX || UNITY_EDITOR_WIN
        true;
#else
        false;
#endif

    public static MyLuaSrv Instance {
        get {
            if (_Instance == null)
                _Instance = new MyLuaSrv();
            return _Instance;
        }
    }

    public static bool IsRunning {
        get {
            return _Instance != null;
        }
    }

    public static void SDispose()
    {
        if (_Instance != null)
            _Instance.Dispose();
    }

    public void Dispose()
    {
        if (_origin != null) {
            ms_includedFiles.Clear();
            GameObject go = GameObject.Find("LuaSvrProxy");
            if (go != null)
                GameObject.DestroyImmediate(go);
            luaState.Dispose();
            _origin = null;
            _Instance = null;
        }
    }

    private MyLuaSrv(string main = null)
    {
        _origin = new LuaSvr();
        _origin.init(null, InitLuaLibs);
    }

    [MonoPInvokeCallback(typeof(LuaCSFunction))]
    public static int import(IntPtr l)
    {
        return LuaStatic.import(l);
    }

    [MonoPInvokeCallback(typeof(LuaCSFunction))]
    public static int printStack(IntPtr l)
    {
        return LuaStatic.printStack(l);
    }

    [MonoPInvokeCallback(typeof(LuaCSFunction))]
    public static int print(IntPtr l)
    {
        return LuaStatic.print(l);
    }

    [MonoPInvokeCallback(typeof(LuaCSFunction))]
    public static int buglyError(IntPtr l)
    {
        return LuaStatic.buglyError(l);
    }

    [MonoPInvokeCallback(typeof(LuaCSFunction))]
    public static int SetParent(IntPtr l)
    {
        return LuaStatic.SetParent(l);
    }

    public static void InitLuaLibs()
    {
        LuaDLL.luaS_openextlibs(LuaSvr.mainState.L);
        LuaDLL.lua_settop(LuaSvr.mainState.L, 0);

        LuaDLL.lua_pushcfunction(LuaSvr.mainState.L, import);
        LuaDLL.lua_setglobal(LuaSvr.mainState.L, "using");

        LuaDLL.lua_pushcfunction(LuaSvr.mainState.L, printStack);
        LuaDLL.lua_setglobal(LuaSvr.mainState.L, "stack");

        LuaDLL.lua_pushcfunction(LuaSvr.mainState.L, print);
        LuaDLL.lua_setglobal(LuaSvr.mainState.L, "print");

        LuaDLL.lua_pushcfunction(LuaSvr.mainState.L, buglyError);
        LuaDLL.lua_setglobal(LuaSvr.mainState.L, "buglyError");

        LuaDLL.lua_pushcfunction(LuaSvr.mainState.L, SetParent);
        LuaDLL.lua_setglobal(LuaSvr.mainState.L, "SetParent");
    }
}
