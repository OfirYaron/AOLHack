using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace AOLHack.Site.Code
{
    public static class WebHelper
    {
        public static string GetWebResponse(string url, NetworkCredential credentials = null, bool second = false)
        {
            int timeout = 0;

            timeout = 10000;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = timeout;
            request.UserAgent = "AOL CampFire";

            if (credentials != null)
                request.Credentials = credentials;

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                Encoding encoding = !string.IsNullOrEmpty(response.CharacterSet)
                                        ? Encoding.GetEncoding(response.CharacterSet)
                                        : Encoding.UTF8;
                StreamReader reader = new StreamReader(response.GetResponseStream(), encoding);
                string result = reader.ReadToEnd();
                reader.Close();
                return result;
            }
            catch (WebException webx)
            {
                if (webx.Status == WebExceptionStatus.Timeout && second == false)
                    return GetWebResponse(url, credentials, true);

                string message = "URL: " + url;
                if (webx.Response != null && webx.Response.Headers != null)
                    message += " Header: " + webx.Response.Headers;

                return string.Empty;
            }
            catch (Exception ex)
            {
                string message = "URL: " + url;

                return string.Empty;
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }
    }
}