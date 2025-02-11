
using UnityEngine;

public class SingletonManager<T> : MonoBehaviour where T : MonoBehaviour
{

 protected virtual void Awake()
 {

   T[] managers = FindObjectsByType<T>(FindObjectsSortMode.None);
   if(managers.Length > 1)
   {
     Destroy(gameObject);
     return;
   }
   
}

public static T Get(){

    var tag = typeof(T).Name;
    GameObject obj = GameObject.FindWithTag(tag);
    if(obj == null){
        obj = new GameObject(tag);
        obj.tag = tag;
       return  obj.AddComponent<T>();
    }
    GameObject goo = new(tag);
    goo.tag = tag;
    return goo.AddComponent<T>();


}
}