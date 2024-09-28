using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";
    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent) 
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
    }

    private void OnMouseDown()
    {
        PlaceDefenderAt(GetSquareClicked());
    }
    public void SetDefenderSpawner(Defender defenderToSelect) 
    {
        defender = defenderToSelect ;
    }
    private void PlaceDefenderAt(Vector2 gridPos) 
    {
        var starDisplay = FindObjectOfType<StarsDisplay>();
        var defenderCost = defender.GetStarCost();
        if (defenderCost ==null) return;
        if (starDisplay.HaveEnoughStar(defenderCost)) 
        {
            starDisplay.SpendStars(defenderCost);
            SpawnDefender(gridPos);
        }
    }
    private Vector2 GetSquareClicked() 
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }
    private Vector2 SnapToGrid(Vector2 rawWolrdPos) 
    {
        float newX = Mathf.RoundToInt(rawWolrdPos.x);
        float newy = Mathf.RoundToInt(rawWolrdPos.y);
        return new Vector2(newX, newy);
    }
    private void SpawnDefender(Vector2 roundedPos) 
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}
