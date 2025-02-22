using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private GameObject visibleSub;

    public float moveSpeed = 5f;
    public PlayerType PlayerType;
    public AudioSource radarAudioSource;
    
    private string horizontalAxis;
    private string verticalAxis;

    private float horizontalTouchInput;
    private float verticalTouchInput;
    
    // Start wird vor dem ersten Frame-Update aufgerufen
    void Start()
    {
        // Entscheide, welche Tasten für welche Achsen verwendet werden, basierend auf dem Spieler
        if (PlayerType == PlayerType.Vision)
        {
            horizontalAxis = "Horizontal";
            verticalAxis = "Vertical";
        }
        else if (PlayerType == PlayerType.Audio)
        {
            horizontalAxis = "Horizontal2";
            verticalAxis = "Vertical2";
        }
    }

    // Update wird einmal pro Frame aufgerufen
    void Update()
    {
        // Bewegung in horizontaler und vertikaler Richtung basierend auf den Tasteneingaben
        var horizontalInput = Input.GetAxisRaw(horizontalAxis);
        var verticalInput = Input.GetAxisRaw(verticalAxis);

        horizontalInput += horizontalTouchInput;
        verticalInput += verticalTouchInput;
        
        // Berechnung der Bewegungsrichtung
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized * moveSpeed * Time.deltaTime;

        if (horizontalInput < 0)
        {
            visibleSub.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(horizontalInput > 0){
            visibleSub.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        // Bewegung des Objekts
        transform.Translate(movement);
        ResetTouchInput();

        if (Input.GetKeyDown(KeyCode.Space)) // KeyCode.Space kann durch jede beliebige Taste ersetzt werden
        {
            PlayRadarSound();
            // Sound abspielen, wenn die Taste gedrückt wird
            
        }
    }

    private void ResetTouchInput()
    {
        horizontalTouchInput = 0;
        verticalTouchInput = 0;
    }
    public void MoveInDirection(Direction direction)
    {
        if(direction == Direction.left)
        {
            horizontalTouchInput = -1f;
        }

        if (direction == Direction.right)
        {
            horizontalTouchInput = 1f;
            //print("right");
        }

        if (direction == Direction.up)
        {
            verticalTouchInput = 1f;
        }

        if (direction == Direction.down)
        {
            verticalTouchInput = -1f;
        }
    }

    public void PlayRadarSound()
    {
        if (radarAudioSource != null)
        {
            radarAudioSource.Play();
        }
    }
    
    public void EnterFloatingBackArea(int direction, float speed)
    {

    }

}

public enum PlayerType
{
    Vision, Audio
}

public enum Direction
{
    left, right, up, down
}
