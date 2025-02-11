
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{


    
        public List<unit> ActiveUnit = new List<unit>();

    private Vector2 m_initialPosition;

    void Update()
    {
        Vector2 inputPosition = Input.touchCount > 0 ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;

        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            m_initialPosition = inputPosition;
        }


        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            if (Vector2.Distance(m_initialPosition, inputPosition) < 10)
            {
                DetecClikc(inputPosition);
            }

        }

        void DetecClikc(Vector2 position)
        {

            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position);
            
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if(HasClickedOnUnit(hit, out var UNIT))
            {
                 HandleClickOnUnit(UNIT);
            }
            else {
                       HandleClickOnGround(worldPosition);
            }
          

        }

    }

    bool HasClickedOnUnit(RaycastHit2D hit, out unit UNIT)
    {

        if (hit.collider != null && hit.collider.TryGetComponent<unit>(out var Clickedunit))
        {
            UNIT = Clickedunit;
            return true;

        }
        UNIT = null;
        return false;
    }


    void HandleClickOnGround(Vector2 worldPoint)
    {
        List<Vector2> path = new List<Vector2>{
            worldPoint + new Vector2(1, 1),
            worldPoint + new Vector2(2, 2),
        };
        int index = 0;

        for(int i = 0; i < ActiveUnit.Count; i++)
        {
            ActiveUnit[i].MoveTo(path[index]);
            index++;
        }
        
    }
    void HandleClickOnUnit(unit Unit)
    {
        if (!checkIfUnitIsSelected(Unit))
        {
            SetActiveUnit(Unit);
        }
        else
        {
            ClearActiveUnit(Unit);
           
        }
        
    }
    public void SetActiveUnit(unit Unit)
    {
        ActiveUnit.Add(Unit);
    }
    bool  checkIfUnitIsSelected(unit Unit)
    {
        return ActiveUnit.Contains(Unit);
    }
    void ClearActiveUnit(unit Unit){
        ActiveUnit.Remove(Unit);
    }

}