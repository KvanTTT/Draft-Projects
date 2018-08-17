using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace BinarySundial
{
    public class Helper
	{
		public static string SendRequest(string url, WebRequestMethod method = WebRequestMethod.Get,
			Dictionary<string, string> headers = null, byte[] body = null, string contentType = "", int timeout = 5000)
		{
			Dictionary<string, string> responseHeaders;
			return SendRequest(url, out responseHeaders, method, headers, body, contentType, timeout);
		}

		public static string SendRequest(string url, out Dictionary<string, string> responseHeaders,
			WebRequestMethod method = WebRequestMethod.Get,
			Dictionary<string, string> headers = null, byte[] body = null, string contentType = "", int timeout = 5000)
		{
			var request = MakeRequest(url, method, headers, body, contentType, timeout);

			string responseString = String.Empty;
			responseHeaders = new Dictionary<string, string>();
			using (var response = request.GetResponse())
			{
				var stream = response.GetResponseStream();
				var reader = new StreamReader(stream);
				responseString = reader.ReadToEnd();
				foreach (var header in response.Headers)
				{
					var key = (string)header;
					responseHeaders.Add(key, response.Headers[key]);
				}
			}

			return responseString;
		}

		public static Stream GetStreamFromRequest(string url,
			WebRequestMethod method = WebRequestMethod.Get, Dictionary<string, string> headers = null,
			byte[] body = null, string contentType = "", int timeout = 5000)
		{
			Dictionary<string, string> responseHeaders;
			return GetStreamFromRequest(url, out responseHeaders, method, headers, body, contentType, timeout);
		}

		public static Stream GetStreamFromRequest(string url, out Dictionary<string, string> responseHeaders,
			WebRequestMethod method = WebRequestMethod.Get,
			Dictionary<string, string> headers = null, byte[] body = null, string contentType = "", int timeout = 5000)
		{
			var request = MakeRequest(url, method, headers, body, contentType, timeout);

			string responseString = String.Empty;
			responseHeaders = new Dictionary<string, string>();

			var response = request.GetResponse();
			var stream = response.GetResponseStream();
			var reader = new StreamReader(stream);
			foreach (var header in response.Headers)
			{
				var key = (string)header;
				responseHeaders.Add(key, response.Headers[key]);
			}

			return stream;
		}

		private static HttpWebRequest MakeRequest(string url, WebRequestMethod method = WebRequestMethod.Get,
			Dictionary<string, string> headers = null, byte[] body = null, string contentType = "", int timeout = 5000)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = method.ToString().ToUpperInvariant();
			request.ContentType = contentType;
			request.UserAgent = "BinarySundial";
			request.Timeout = timeout;
			if (headers != null)
				foreach (var header in headers)
					request.Headers.Add(header.Key, header.Value);
			if ((method == WebRequestMethod.Post || method == WebRequestMethod.Patch) && body != null)
			{
				request.ContentType = contentType;
				request.ContentLength = body.Length;
				using (var stream = request.GetRequestStream())
					stream.Write(body, 0, body.Length);
			}
			return request;
		}
	}
}
