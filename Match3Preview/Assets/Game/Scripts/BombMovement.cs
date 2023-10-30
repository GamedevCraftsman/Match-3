using System.Linq;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] public float yPointFrom;
    [SerializeField] public float yPointTo;

    public CellScript[] cells;

    int stopSpeed = 0;
    int iSave;
    float saveSpeed;
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
            speed = stopSpeed;
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
                speed = stopSpeed;
                cells[i].isFree = false;
                break;
            case 11:
                speed = stopSpeed;
                cells[i].isFree = false;
                break;
            case 17:
                speed = stopSpeed;
                cells[i].isFree = false;
                break;
            case 23:
                speed = stopSpeed;
                cells[i].isFree = false;
                break;
            case 29:
                speed = stopSpeed;
                cells[i].isFree = false;
                break;
            case 35:
                speed = stopSpeed;
                cells[i].isFree = false;
                break;
        }
    }

    void BottomBorder()
    {
        if (bomb.transform.position.y <= cells[iSave].transform.position.y - yPointTo)
        {
            cells[iSave].isFree = true;
        }
    }

    void SearchForTheCorrespondingCell()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (IsXPointsEquals(i) && IsYPointsEqualsFrom(i) && IsYPointEqualsTo(i))
            {
                cells[i].bomb = gameObject;
                cells[i].isFree = false;
                if (i + 1 == cells.Count())
                {
                    speed = stopSpeed;
                    break;
                }
                IsFreeChecking(i);
                BottomChecking(i);
            }
        }
        BottomBorder();
    }

    bool IsXPointsEquals(int i)
    {
        return bomb.transform.position.x == cells[i].transform.position.x;
    }

    bool IsYPointsEqualsFrom(int i)
    {
        return bomb.transform.position.y <= cells[i].transform.position.y + yPointFrom;
    }

    bool IsYPointEqualsTo(int i)
    {
        return bomb.transform.position.y >= cells[i].transform.position.y - yPointTo;
    }
}
