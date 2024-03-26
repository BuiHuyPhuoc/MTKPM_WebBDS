using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webbds.Class
{
    public class SecretString_SingleTon
    {
        private static SecretString_SingleTon instance;
        public static string Facebook_ClientSecret { get {  return "7b51a5f2a88865b104801054057d85c3"; } }
        public static string Facebook_ClientId { get { return "290678663865598"; } }
        public static string Google_ClientId { get { return "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"; } }
        public static string Google_ClientSecret { get { return "364529464069-nfod00d40knfqj8n398ubj84drpo0sf7.apps.googleusercontent.com"; } }
        private SecretString_SingleTon() { }
        public static SecretString_SingleTon GetInstance()
        {
            // Sử dụng double-check locking để đảm bảo tính đồng bộ
            if (instance == null)
            {
                instance = new SecretString_SingleTon();
            }
            return instance;
        }
    }
}