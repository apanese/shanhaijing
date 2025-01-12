using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*寻找类名及调用方法*/
using System.Diagnostics;
using System.Reflection;
using System;
//using LitJson;
public static class HELPER 
{
    // Start is called before the first frame update
    
    public static void OutPutAspectRatio()
    {
        UnityEngine.Debug.Log($"Screen.width:{Screen.width} +Screen.height:{Screen.height}");
    }
    public static void OutPutWorldPosition(GameObject obj1, GameObject obj2, GameObject obj3,GameObject obj4)
    {
        /* Debug.Log("cube1 plane position:"+obj1.transform.position);
         Debug.Log("cube2 plane position:" + obj2.transform.position);
         Debug.Log("cube3 plane position:" + obj3.transform.position);
         Debug.Log("cube1.transformPoint(cube2):"+obj1.transform.TransformPoint(obj2.transform.localPosition));
         Debug.Log("cube1.transformPoint(cube3):" + obj1.transform.TransformPoint(obj3.transform.localPosition));
         Debug.Log("cube2.transformPoint(cube3):" + obj2.transform.TransformPoint(obj3.transform.position));
         Debug.Log("cubbe2.inverseformPoint(cube3):" + obj2.transform.InverseTransformPoint(obj3.transform.position));*/
        UnityEngine.Debug.Log("obj4.transform.TransformPoint(obj3.transform.position" + obj4.transform.InverseTransformPoint(obj3.transform.position));
        //Debug.Log("obj3.transform.TransformPoint(obj4.transform.position" + obj3.transform.TransformPoint(obj4.transform.position));
        //Debug.Log("cube2.inverseformPoint(cube")
        obj4.transform.SetParent(obj3.transform,false);
    }
    public static void OutPutWorldToScreen(GameObject obj1,Camera maincamera)
    {
        UnityEngine.Debug.Log(maincamera.worldToCameraMatrix);
        Vector3 position = maincamera.WorldToScreenPoint(obj1.transform.position);
        Vector3 viewposition = maincamera.WorldToViewportPoint(obj1.transform.position);
        UnityEngine.Debug.Log(position);
        UnityEngine.Debug.Log(viewposition);
    }
    public static void OutPutFileName()
    {
        string className = MethodBase.GetCurrentMethod().ReflectedType.Name;
        StackTrace trace = new StackTrace();
        MethodBase methodName = trace.GetFrame(1).GetMethod();
        UnityEngine.Debug.Log("class name:"+className +"   ,method name:" +methodName.Name);
    }
    public static string getFileName()
    {
        string className = MethodBase.GetCurrentMethod().ReflectedType.Name;
        StackTrace trace = new StackTrace();
        MethodBase methodName = trace.GetFrame(1).GetMethod();
        //UnityEngine.Debug.Log("class name:" + className + "   ,method name:" + methodName.Name);
        string class_methodname = "class name:" + className + "   ,method name:" + methodName.Name;
        return class_methodname;
    }
    
}
