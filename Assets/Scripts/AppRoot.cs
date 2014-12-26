using UnityEngine;
using System.Collections;
using MiniJSON;
using CustomAttributes;

namespace FecebookLoginTest
{
    public class AppRoot : MonoBehaviour
    {
        [SerializeField]
        private GUIText mLabel;

        [SerializeField]
        private GUITexture mAvatar;

        [SerializeField]
        [ReadOnly]
        private string id;

        [SerializeField]
        private Transform Cube;


        void Start()
        {
            FB.Init(OnFacebookInit);
            id = "0";
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Cube.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Cube.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Cube.Translate(new Vector3(0, 0, 1) * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Cube.Translate(new Vector3(0, 0, -1) * Time.deltaTime);
            }
        }


        protected void OnFacebookInit()
        {
            FB.Login("email, publish_actions", OnLoggedIn);
        }

        protected void OnLoggedIn(FBResult result)
        {
            if (FB.IsLoggedIn)
            {
                LabelText = "Logged In OK";
                FB.API("/me?fields=id,first_name,friends.limit(100).fields(first_name,id)", Facebook.HttpMethod.GET, APICallback);
            }
            else
            {
                LabelText = result.Text;
            }
        }

        void APICallback(FBResult result)
        {
            if (result.Error != null)
            {
                // Let's just try again                                                                                                
                FB.API("/me?fields=id,first_name,friends.limit(100).fields(first_name,id)", Facebook.HttpMethod.GET, APICallback);
                return;
            }

            LabelText = result.Text;

            if (FB.IsLoggedIn)
            {
                FB.Logout();
            }
        }

        public string LabelText
        {
            get { return mLabel.text; }
            set { mLabel.text = value; }
        }
    }
}
