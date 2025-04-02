using UnityEngine;
using UnityEngine.Playables;

public class EndCutScene : MonoBehaviour
{
    [SerializeField] PlayableDirector _endDirector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _endDirector.Play();
        }
    }
}
