using UnityEngine;
using Eblomino;

public class PlayerController : MonoBehaviour {

	class LogPrintingGridListener : IGridListener
	{
		public void onCellCreated(Kreuz cell)
		{
			Debug.Log("Kreuz at " + cell);
		}

		public void onSquareFound(Kreuz first, Kreuz second)
		{
			Debug.Log("Square at " + first + " @ " + second);
		}
	}

    public float speed;
    public float rotation_speed;

	private Eblomino.PlayerGrid grid;

    // Use this for initialization
    void Start () {
		grid = new Eblomino.PlayerGrid();
		grid.AddListener(new LogPrintingGridListener());
	}
	
	// Update is called once per frames
	void Update () {
        float v_ax = Input.GetAxis("Vertical");
        float h_ax = Input.GetAxis("Horizontal");

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Quaternion rotation = rb.rotation;
        Matrix4x4 rot_matrix = Matrix4x4.Rotate(rotation);

        rb.velocity = rot_matrix.MultiplyVector(new Vector3(0.0f, speed*v_ax, 0.0f));
        rb.angularVelocity = new Vector3(0.0f, rotation_speed*h_ax, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        EblominoController ec = other.gameObject.transform.parent.gameObject.GetComponent<EblominoController>();

        other.gameObject.transform.SetParent(transform);
        Vector3 ea = other.gameObject.transform.localEulerAngles;
        ea.z = 0.0f;
        other.gameObject.transform.localEulerAngles = ea;

        Vector3 pos = other.gameObject.transform.localPosition;
        pos.x = Mathf.Floor(pos.x+0.5f);
        pos.y = Mathf.Floor(pos.y+0.5f);
        other.gameObject.transform.localPosition = pos;

		int x = (int)pos.x;
		int y = (int)pos.y;

		if (!grid.Exists (x, y)) {
			grid.NewCell (x, y);
		}

		GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");
		Camera camera = cam.GetComponent<Camera> ();
		if (camera != null) {
			camera.orthographicSize += 0.1f;
		}
    }
}
