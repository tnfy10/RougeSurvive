using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliveController : MonoBehaviour
{
    float flowTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyOlive", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.gameObject.transform.position;
        float xPos = position.x;
        float zPos = position.z;
        
        if (xPos < 0 || xPos > 100 || zPos < 0 || zPos > 100)
        {
            Destroy(this.gameObject);
        }

        flowTime += Time.deltaTime;
        if ( flowTime > 5.0f )
            Destroy(this.gameObject);
    }

    void DestroyOlive()
    {
        Destroy(this.gameObject);
    }
}
