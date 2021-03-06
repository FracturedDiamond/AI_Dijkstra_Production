using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : Seek
{
    public GameObject[] path;
    int pathIndex;
    float targetRadius = .5f;

    public override SteeringOutput getSteering()
    {
        int nearestPathIndex = 0;
        float distToNearest = float.PositiveInfinity;

        if (target == null)
        {
            for (int i = 0; i < path.Length; i++)
            {
                GameObject possibleTarget = path[i];
                Vector3 vectorToTarget = possibleTarget.transform.position - character.transform.position;
                float distToPossibleTarget = vectorToTarget.magnitude;

                if (distToPossibleTarget < distToNearest)
                {
                    nearestPathIndex = i;
                    distToNearest = distToPossibleTarget;
                }

                target = path[nearestPathIndex];
            }
        }

        float distToTarget = (target.transform.position - character.transform.position).magnitude;
        bool reachedTarget = distToTarget < targetRadius;

        if (reachedTarget)
        {
            pathIndex++;

            if (pathIndex > path.Length - 1)
            {
                pathIndex = 0;
            }

            target = path[pathIndex];
        }

        return base.getSteering();
    }
}
