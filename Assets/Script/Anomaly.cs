using UnityEngine;

public class Anomaly : MonoBehaviour
{
    //anomaly functions:
    //move
    //appear
    //disappear
    //change
    [SerializeField] private int loopToChange;

    [SerializeField] private bool move;
    [SerializeField] private Vector3 newPosition;

    [SerializeField] private GameObject obj;
    [SerializeField] private bool appear;
    [SerializeField] private bool disappear;

    [SerializeField] private bool change;
    [SerializeField] private GameObject otherObj;
    
    [SerializeField] private bool changeMat;
    [SerializeField] private Material newMat;
    
    [SerializeField] private bool enableScript;
    [SerializeField] private  MonoBehaviour script;
    


    public void LoopCheck(int loop)
    {
        if (loop == loopToChange)
        {
            gameObject.tag = "Identifiable";
            if (move)
            {
                transform.position = newPosition;
            }

            if (appear)
            {
                obj.SetActive(true);
            }

            if (disappear)
            {
                obj.SetActive(false);
            }

            if (change)
            {
                obj.SetActive(false);
                otherObj.SetActive(true);
            }

            if (changeMat)
            {
                GetComponent<Renderer>().material = newMat;
            }

            if (enableScript)
            {
                script.enabled = true;
            }
        }
    }
}