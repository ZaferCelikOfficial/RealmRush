using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float Speed=1f;
    Enemy enemy;    
    void OnEnable()
    {
        FindPath();
        ReturntoStart();
        StartCoroutine(FollowPath());

    }
    void Start()
    {
        enemy = FindObjectOfType<Enemy>();   
    }
    void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null)
            {
                path.Add(waypoint);
            }  
        }
    }
    void ReturntoStart()
    {
        transform.position = path[0].transform.position;
    }
    void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.DrawGold();
    }
    IEnumerator FollowPath()
    {

        foreach(Waypoint waypoint in path)
        {
            Vector3 StartingPosition = transform.position;
            Vector3 EndingPosition = waypoint.transform.position;
            float TravelPercent = 0f;
            transform.LookAt(EndingPosition);
            while(TravelPercent<1f)
            {
                TravelPercent += Time.deltaTime * Speed ;
                transform.position = Vector3.Lerp(StartingPosition, EndingPosition, TravelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}
