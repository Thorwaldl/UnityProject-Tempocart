using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle 
{
    public Transform Cubo{ get; set; }
    public int Tempo { get; set; }
    public Obstacle obstacle { get; set; }

    public Obstacle(Transform cubo, int tempo, Obstacle nextObstacle)
    {
        Cubo = cubo;
        Tempo = tempo;
        SetObstacle(nextObstacle);
    }

    public Obstacle GetObstacle()
    {
        return obstacle;
    }

    public void SetObstacle(Obstacle o)
    {
        obstacle = o;
    }
}
