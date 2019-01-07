using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	private Rigidbody rigidbody;
	private AudioSource audioSource;
	private Vector3 startPos = new Vector3 (0f,20f,0f);

	public bool inPlay = false;
    public bool bounced = false;
    public AudioClip[] audios;
    public Text myText;
    public Texture[] myTextures = new Texture[5];
    int maxTextures;
    int arrayPos = 0;
    private Renderer renderer; 

    // Use this for initialization
    void Start ()
	{
        myText.color = Color.green;
		rigidbody = GetComponent<Rigidbody> ();
		rigidbody.useGravity = false;
		audioSource = GetComponent<AudioSource> ();
        maxTextures = myTextures.Length - 1;
        renderer = GetComponent<Renderer>();
        
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (!bounced)
        {
            audioSource.Pause();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            renderer.material.mainTexture = myTextures[arrayPos];

            if (arrayPos == maxTextures)
            {
                arrayPos = 0;
            }
            else
            {
                arrayPos++;
            }

        }
    }

	public void Launch (Vector3 launch)
	{		
		rigidbody.useGravity = true;
        rigidbody.velocity = launch;
        myText.color = Color.red;
        inPlay = true;

    }

	public void Reset()
	{
        transform.position = startPos;
        rigidbody.velocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.useGravity = false;
	}

    void OnCollisionEnter(Collision col)
    {
        bounced = true;
        if (col.gameObject.GetComponent<Lane> ())
        {
            audioSource.clip = audios[0];
            audioSource.Play();
            Invoke("Roll" , 4f);
        }
    }

    void Roll()
    {
        audioSource.clip = audios[1];
        audioSource.Play();
    }
}
