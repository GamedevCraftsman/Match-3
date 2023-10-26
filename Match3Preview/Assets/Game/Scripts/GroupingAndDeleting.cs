using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEditor;
using System.Data;

public class GroupingAndDeleting : MonoBehaviour, IPointerClickHandler
{
    public enum bombsColor { Blue, Red, Green, Orange, Purple, Nothing };
    public bombsColor color;

    const int offset = 1;
    const int columnSize = 6;
    const int numberOfNeighbors = 1;
    int[] farBombsIndexes = { 5, 6, 11, 12, 17, 18, 23, 34, 29, 30 };
    List<GameObject> bombsForDelete = new List<GameObject>();
    int clickedCellIndex = -1;
    CellScript[] cells;
    GameObject cellContainer;
    void Start()
    {
        cellContainer = GameObject.FindGameObjectWithTag("cellContainer");
        cells = cellContainer.GetComponent<CellContainer>().cells;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        FindClickedCellIndex();

        CheckAndAddNeighborToList(-offset);
        CheckAndAddNeighborToList(offset);
        CheckAndAddNeighborToList(-columnSize);
        CheckAndAddNeighborToList(columnSize);

        CheckingTheNumberAndDeleteNeighbors();
    }

    void CheckAndAddNeighborToList(int offset)
    {
        int neighborIndex = clickedCellIndex + offset;

        if (CheckBorders(neighborIndex) && IsNeighborMatchingColor(neighborIndex))
        {
            bombsForDelete.Add(cells[neighborIndex].bomb);
            cells[neighborIndex].isFree = true;
        }
        CheckingFarBombs(neighborIndex);    
    }

    bool CheckBorders(int neighborIndex)
    {
        return (neighborIndex < cells.Length && neighborIndex >= 0);
    }

    bool IsNeighborMatchingColor(int neighborIndex)
    {
        if (cells[neighborIndex].bomb.GetComponent<GroupingAndDeleting>().color == color)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void CheckingTheNumberAndDeleteNeighbors()
    {
        if (bombsForDelete.Count() >= numberOfNeighbors)
        {
            DeleteBombsFromList();
        }
        bombsForDelete.Clear();
    }

    void DeleteBombsFromList()
    {
        foreach (var bomb in bombsForDelete)
        {
            cells[clickedCellIndex].isFree = true;           
            Destroy(bomb);
            Destroy(gameObject);           
        }
    }

    void FindClickedCellIndex()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i].bomb == gameObject)
            {
                clickedCellIndex = i;
                break;
            }
        }
    }

    void CheckingFarBombs(int neighborIndex)
    {
        for (int i = 0; i < farBombsIndexes.Length; i++)
        {
            CheckUpBombs(neighborIndex, i);
            CheckDownBombs(neighborIndex, i);
        }
    }

    void CheckUpBombs(int neighborIndex, int i)
    {
        if (CheckBorders(neighborIndex) && neighborIndex == clickedCellIndex + 1 && neighborIndex == farBombsIndexes[i])
        {
            bombsForDelete.Remove(cells[clickedCellIndex + offset].bomb);
            cells[clickedCellIndex + offset].isFree = false;
        }
    }

    void CheckDownBombs(int neighborIndex, int i)
    {
        if (CheckBorders(neighborIndex) && neighborIndex == clickedCellIndex - 1 && neighborIndex == farBombsIndexes[i])
        {
            bombsForDelete.Remove(cells[clickedCellIndex - offset].bomb);
            cells[clickedCellIndex + offset].isFree = false;
        }
    }
}

