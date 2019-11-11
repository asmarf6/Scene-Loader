using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{    
    public bool isClicked = false;
    public GameObject sceneHandler;
    private GameObject result;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkClick();
        if(isClicked)
        {
            sceneHandler.GetComponent<SceneHandler>().LoadNewScene();
            isClicked = false;
        }
    }

    public GameObject checkClick()
    {
        
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {               
                Debug.Log(hit.collider.gameObject.name + " clicked");
                isClicked = true;
                result = hit.collider.transform.parent.gameObject;
            }
        }
        return result ;
    }
}
