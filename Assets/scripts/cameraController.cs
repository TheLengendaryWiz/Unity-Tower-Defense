using UnityEngine;

public class cameraController : MonoBehaviour
{
    bool doMove = false;
    public float scroolspeed=5f;
    public float panspeed = 30f;
    public float maxScrool = 80f;
    public float minScrool =10f;
    public float panBorder =10f;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameOver)
        {
            this.enabled = false;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMove = !doMove;
        }
        if (!doMove)
        {
            return;
        }
        if (Input.GetKey("w") || Input.mousePosition.y > Screen.height - panBorder)
        {
            transform.Translate(Vector3.forward * panspeed *Time.deltaTime,Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y < panBorder)
        {
            transform.Translate(Vector3.back * panspeed * Time.deltaTime, Space.World);
        }if (Input.GetKey("a") || Input.mousePosition.x < panBorder)
        {
            transform.Translate(Vector3.left * panspeed * Time.deltaTime, Space.World);
        }if (Input.GetKey("d") || Input.mousePosition.x > Screen.width - panBorder)
        {
            transform.Translate(Vector3.right * panspeed * Time.deltaTime, Space.World);
        }
        float scroll =Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scroolspeed * Time.deltaTime;
        pos.y=Mathf.Clamp(pos.y, minScrool, maxScrool);
        pos.x = Mathf.Clamp(pos.x,0, 81);
        pos.z = Mathf.Clamp(pos.z, -93, 0);
        transform.position = pos;
    }
}