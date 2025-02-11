using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class AiUnit : MonoBehaviour
{
    private float m_speed = 5f;
    private Vector3? m_targetPosition;

    public Vector3? Destination => m_targetPosition;
    
    /* this line of code is the same as the code below
  public Vector3? Destination
{
    get { return m_targetPosition; }
    }

 */
   

    void Update(){
        if(m_targetPosition.HasValue){

            transform.position += (m_targetPosition.Value - transform.position).normalized * Time.deltaTime * m_speed;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        m_targetPosition = destination;
    }



}