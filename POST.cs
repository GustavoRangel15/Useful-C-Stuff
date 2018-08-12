using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;


namespace POSTto
{
    public static class POSTto
    {
        public static byte[] Post(string uri, NameValueCollection pairs)
        {
            byte[] result = null;
            using (WebClient webClient = new WebClient())
            {
                result = webClient.UploadValues(uri, pairs);
            }
            return result;
        }
    }
}
