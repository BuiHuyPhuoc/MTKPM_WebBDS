using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Facebook;
using GoogleAuthentication.Services;
using Newtonsoft.Json;
using webbds.Models;
namespace webbds.Class
{
    abstract class OtherLogin
    {
        protected BDS_TestEntities db = new BDS_TestEntities();
        protected SecretString_SingleTon singleTon = SecretString_SingleTon.GetInstance();
        public NguoiDung NguoiDung { get; set; }
        public virtual Task<User> GetUserByGoogle(string code) { return null ; }
        public virtual User GetUserByFacebook(string code) { return null ; }
    }
    class GoogleLogin : OtherLogin
    {
        
        string clientId = SecretString_SingleTon.Google_ClientId;
        string clientSecret = SecretString_SingleTon.Google_ClientSecret;
        protected string url = "http://localhost:61552/NguoiDung/GoogleLoginCallBack";
        public override async Task<User> GetUserByGoogle(string code)
        {
            var token = await GoogleAuth.GetAuthAccessToken(code, clientId, clientSecret, url);
            var userProfile = await GoogleAuth.GetProfileResponseAsync(token.AccessToken.ToString());
            var googleUser = JsonConvert.DeserializeObject<User>(userProfile);
            base.NguoiDung = db.NguoiDungs.Where(x => x.Email == googleUser.Email).FirstOrDefault();
            return googleUser;
        }
    }

    class FacebookLogin : OtherLogin 
    {
        string clientId = SecretString_SingleTon.Facebook_ClientId;
        string clientSecret = SecretString_SingleTon.Google_ClientSecret;
        protected string url = "http://localhost:61552/NguoiDung/FacebookLoginCallBack";
        public override User GetUserByFacebook(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Get("/oauth/access_token", new
            {
                client_id = clientId,
                client_secret = clientSecret,
                redirect_uri = url,
                code = code
            });

            fb.AccessToken = result.access_token;
            dynamic me = fb.Get("/me?fields=name,email");
            string name = me.name;  
            string email = me.email;
            base.NguoiDung = db.NguoiDungs.Where(x => x.Email == email).FirstOrDefault();

            return new User
            {
                Name = name, Email = email
            };
        }
    }

    abstract class  OtherLoginFactory
    {
        public abstract OtherLogin CreateLoginWay();
    }

    class FacebookLoginFactory : OtherLoginFactory
    {
        public override OtherLogin CreateLoginWay()
        {
            return new FacebookLogin();
        }
    }

    class GoogleLoginFactory : OtherLoginFactory
    {
        public override OtherLogin CreateLoginWay()
        {
            return new GoogleLogin();
        }
    }

}