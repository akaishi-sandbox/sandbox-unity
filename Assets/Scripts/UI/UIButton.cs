using UnityEngine;
using UniRx;

namespace UI
{
	[RequireComponent (typeof (UnityEngine.UI.Button))]
	public class UIButton : MonoBehaviour {

		UnityEngine.UI.Button button {
			get {
				return GetComponent<UnityEngine.UI.Button>();
			}
		}

		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			// var path = Path.Combine(Application.persistentDataPath, "user.bin");
			var builder = new FlatBuffers.FlatBufferBuilder(1);
			var data = Data.User.CreateUser(builder);
			
			button.onClick.AsObservable()
				.Select(_ => 1)
				.Scan(0, (element, acc) => element + acc)
				.Subscribe (count => Debug.Log("count:" + count))
				.AddTo(gameObject);
		}

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}

}