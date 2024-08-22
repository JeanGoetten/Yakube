using UnityEngine;

public class SwordHit : MonoBehaviour
{
    public GameObject go_squareBlood; 
    public ScreenShake screenShake;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            screenShake.start = true;
            Instantiate(go_squareBlood, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
