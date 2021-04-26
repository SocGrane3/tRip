using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class DestroyFractals : MonoBehaviour
{

    public UnityEngine.Rendering.Volume v;
    Bloom b;
    Vignette vign;
    DepthOfField depth;
    ChromaticAberration ca;
    [SerializeField]
    AudioSource boom;

    // Start is called before the first frame update
    void Start()
    {
        boom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        CreateFractals.indexFractals +=1;
        if (CreateFractals.indexFractals == 6)
        {
            boom.Play();
            Debug.Log("ae");
            SceneManager.LoadScene("FinalScene");
        }else if (CreateFractals.indexFractals == 5)
        {
            boom.Play();
            v.profile.TryGet<Vignette>(out vign);
            v.profile.TryGet<DepthOfField>(out depth);
            v.profile.TryGet<ChromaticAberration>(out ca);
            v.profile.TryGet<Bloom>(out b);
            b.intensity.value += 150;
            ca.intensity.value += 0.2f;

        }
        else
        {
            boom.Play();
            v.profile.TryGet<Bloom>(out b);
           v.profile.TryGet<Vignette>(out vign);
           v.profile.TryGet<DepthOfField>(out depth);
           v.profile.TryGet<ChromaticAberration>(out ca);
            b.intensity.value += 20;
            ca.intensity.value += 0.2f;
            vign.intensity.value += 0.05f;
        }

        Destroy(this.gameObject);

    }
}
