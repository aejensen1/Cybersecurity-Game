using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntivirusDetector : MonoBehaviour
{
    public GameObject Detector;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Detector.SetActive(false);
        animator.SetBool("Detection", false);
    }

    // Update is called once per frame
    void Update()
    {

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void ActivateDetector()
    {
        Detector.SetActive(true);
        Cursor.visible = true;
    }

    public void DeactivateDetector()
    {
        Detector.SetActive(false);
        Cursor.visible = false;
    }

    void OnTriggerEnter2D(Collider2D other) //triggers when detector touches antivirus
    {
        if (other.gameObject.tag == "Antivirus")
        {
            animator.SetBool("Detection", true);
            Debug.Log("DetectionBool = " + animator.GetBool("Detection"));
        }
    }

    void OnTriggerExit2D(Collider2D other) //triggers when detector touches antivirus
    {
        if (other.gameObject.tag == "Antivirus")
        {
            animator.SetBool("Detection", false);
            Debug.Log("DetectionBool = " + animator.GetBool("Detection"));
        }
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Antivirus")
    //        animator.SetBool("Detection", true);
    //}
}
