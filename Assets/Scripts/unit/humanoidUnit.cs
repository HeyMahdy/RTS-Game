using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class humanoidUnit : unit
{


     protected Vector2 m_velocity;
     protected Vector2 lastPosition;

     public float currenrSpeed => m_velocity.magnitude;

     void Start(){
         lastPosition = transform.position;
     }
 protected void Update(){

    m_velocity = new Vector2(

        (transform.position.x - lastPosition.x),(transform.position.y-lastPosition.y)
    ) / Time.deltaTime;
    lastPosition = transform.position;
    isMoving = m_velocity.magnitude > 0.1f;
    
    
 }

}