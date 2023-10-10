using System.Linq;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float yPointFrom;
    [SerializeField] float yPointTo;

    int iSave;
    float saveSpeed;
    public CellScript[] cells;
    GameObject cellContainer;
    Transform bomb;
    void Start()
    {
        bomb = GetComponent<Transform>();
        cellContainer = GameObject.FindGameObjectWithTag("cellContainer");
        cells = cellContainer.GetComponent<CellContainer>().cells;
        saveSpeed = speed;
    }

    void FixedUpdate()
    {
        SearchForTheCorrespondingCell();
        bomb.transform.position = bomb.transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
    }

    void IsFreeChecking(int i)
    {
        if (cells[i + 1].isFree == false)
        {
            speed = 0;
        }
        else if (cells[i + 1].isFree == true)
        {
            speed = saveSpeed;
            iSave = i;
        }
    }

    void BottomChecking(int i)
    {
        switch (i)
        {
            case 5:
                speed = 0;
                cells[i].isFree = false;
                break;
            case 11:
                speed = 0;
                cells[i].isFree = false;
                break;
            case 17:
                speed = 0;
                cells[i].isFree = false;
                break;
            case 23:
                speed = 0;
                cells[i].isFree = false;
                break;
            case 29:
                speed = 0;
                cells[i].isFree = false;
                break;
            case 35:
                speed = 0;
                cells[i].isFree = false;
                break;
        }
    }

    void BottomBorder()
    {
        if (bomb.transform.position.y <= cells[iSave].transform.position.y - yPointTo)
        {
            cells[iSave].isFree = true;
        };
    }

    void SearchForTheCorrespondingCell()
    {
        for (int i = 0; i < cells.Count(); i++)
        {
            if (bomb.transform.position.x == cells[i].transform.position.x && bomb.transform.position.y <= cells[i].transform.position.y + yPointFrom && bomb.transform.position.y >= cells[i].transform.position.y - yPointTo)
            {
                cells[i].isFree = false;
                if (i + 1 == cells.Count())
                {
                    speed = 0;
                    break;
                }
                IsFreeChecking(i);
                BottomChecking(i);
            }
        }
        BottomBorder();
    }
}
