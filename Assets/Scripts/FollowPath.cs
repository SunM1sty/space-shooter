using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    public enum MovementType
    {
        Moveing,
        Lerping
    }

    public MovementType Type = MovementType.Moveing;
    public MovementPath MyPath;
    public float speed = 1;
    public float maxDistance = 0.1f; // на какое расстояние должен подъехать объект к точке, чтобы понять, что это точка


    private IEnumerator<Transform> pointInPath;
    // Start is called before the first frame update
    void Start()
    {
        if (MyPath == null)
        {
            Debug.Log("Прикрепи путь к объекту");
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        if(pointInPath.Current == null)
        {
            Debug.Log("Нужны точки");
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointInPath == null || pointInPath.Current == null) // если нет пути 
        {
            return;
        }

        if(Type == MovementType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        else if(Type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude; // достаточно ли мы близко к точке, чтобы начать двигаться к другой
        if(distanceSqure < maxDistance * maxDistance) // близость по теореме Пифагора
        {
            pointInPath.MoveNext();
        }
    }
}
