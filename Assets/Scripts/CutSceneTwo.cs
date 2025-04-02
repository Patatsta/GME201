using UnityEngine;
using UnityEngine.Playables;
public class CutSceneTwo : MonoBehaviour
{
    [SerializeField]    
    private PlayableDirector _director2;

    private void OnTriggerEnter(Collider other)
    {
   
        if (other.CompareTag("Player"))
        {
         
            _director2.Play();
            Destroy(gameObject);
        }
    }
}
