using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace Scaffolding.Common
{
    // Append Class by Teeramed Tangjirawattana 2562
    // T:  ใช้ DeserializeObject Result จาก Api 
    // T2: ใช้ DeserializeObject Error  จาก Api (เฉพาะกรณี Api แยก Response Success และ Unsuccess เป็น 2 แบบ)
    // Parameters:
    //      "string url":   รับ "Domain Url" ที่ใช้สำหรับ Connect ไปยัง Api 
    //      "string route": รับ "Route" ที่ใช้เรียก Method ภายใน "Domain Url" 
    //      "List<KeyValuePair<string, string>> header": HTTP Request Header สำหรับ Request ไปยัง Api รับข้อมูลเป็น Key และ Value 
    //      "object jsonBody": Parameters(HTTP Request Body) ที่ใช้ส่งไปยัง Api รองรับรับค่าทั้งแบบ Model หรือ Anonymous(Key,value)

    public interface IRestUtilityCommon
    {
        string UrlCombind(string url, params string[] paths);

        // GET
        REST_RESPONSE Get<T>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody);
        REST_RESPONSE Get<T, T2>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody);

        // POST
        REST_RESPONSE Post<T>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody);
        REST_RESPONSE Post<T, T2>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody);

        // PUT
        REST_RESPONSE Put<T>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody);
        REST_RESPONSE Put<T, T2>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody);

        // DELETE
        REST_RESPONSE Delete<T>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody);
        REST_RESPONSE Delete<T, T2>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody);
    }

    public class RestUtilityCommon : IRestUtilityCommon
    {
        private const string default_ContentTypeKey = "Content-Type";
        private const string default_ContentTypeValue = "application/json";
        private const string default_AcceptKey = "Accept";
        private const string default_AcceptValue = "*/*";

        #region [Utility Methods]
        public string UrlCombind(string url, params string[] paths)
        {
            return paths.Aggregate(url, (current, path) => string.Format("{0}/{1}", current.TrimEnd('/'), path.TrimStart('/')));
        }
        #endregion [Utility Methods]

        #region [GET Methods]
        public REST_RESPONSE Get<T>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody)
        {
            try
            {
                var httpMethod = Method.GET;
                var client = this.InitRestClient(url: url);
                var request = this.InitRouteHttpMethod(route: route, method: httpMethod);

                this.SetRouteBody(ref request, jsonBody: jsonBody, method: httpMethod);
                this.SetRouteHeader(ref request, header: header);

                IRestResponse response = client.Execute(request);
                return this.GetRestResponse<T>(iRes: response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public REST_RESPONSE Get<T, T2>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody)
        {
            try
            {
                var httpMethod = Method.GET;
                var client = this.InitRestClient(url: url);
                var request = this.InitRouteHttpMethod(route: route, method: httpMethod);

                this.SetRouteBody(ref request, jsonBody: jsonBody, method: httpMethod);
                this.SetRouteHeader(ref request, header: header);

                IRestResponse response = client.Execute(request);
                return this.GetRestResponse<T, T2>(iRes: response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion [GET Methods]

        #region [POST Methods]
        public REST_RESPONSE Post<T>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody)
        {
            try
            {
                var httpMethod = Method.POST;
                var client = this.InitRestClient(url: url);
                var request = this.InitRouteHttpMethod(route: route, method: httpMethod);

                this.SetRouteBody(ref request, jsonBody: jsonBody, method: httpMethod);
                this.SetRouteHeader(ref request, header: header);

                IRestResponse response = client.Execute(request);
                return this.GetRestResponse<T>(iRes: response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public REST_RESPONSE Post<T, T2>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody)
        {
            try
            {
                var httpMethod = Method.POST;
                var client = this.InitRestClient(url: url);
                var request = this.InitRouteHttpMethod(route: route, method: httpMethod);

                this.SetRouteBody(ref request, jsonBody: jsonBody, method: httpMethod);
                this.SetRouteHeader(ref request, header: header);

                IRestResponse response = client.Execute(request);
                return this.GetRestResponse<T, T2>(iRes: response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion [POST Methods]

        #region [PUT Methods]
        public REST_RESPONSE Put<T>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody)
        {
            try
            {
                var httpMethod = Method.PUT;
                var client = this.InitRestClient(url: url);
                var request = this.InitRouteHttpMethod(route: route, method: httpMethod);

                this.SetRouteBody(ref request, jsonBody: jsonBody, method: httpMethod);
                this.SetRouteHeader(ref request, header: header);

                IRestResponse response = client.Execute(request);
                return this.GetRestResponse<T>(iRes: response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public REST_RESPONSE Put<T, T2>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody)
        {
            try
            {
                var httpMethod = Method.PUT;
                var client = this.InitRestClient(url: url);
                var request = this.InitRouteHttpMethod(route: route, method: httpMethod);

                this.SetRouteBody(ref request, jsonBody: jsonBody, method: httpMethod);
                this.SetRouteHeader(ref request, header: header);

                IRestResponse response = client.Execute(request);
                return this.GetRestResponse<T, T2>(iRes: response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion [PUT Methods]

        #region [DELETE Methods]
        public REST_RESPONSE Delete<T>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody)
        {
            try
            {
                var httpMethod = Method.DELETE;
                var client = this.InitRestClient(url: url);
                var request = this.InitRouteHttpMethod(route: route, method: httpMethod);

                this.SetRouteBody(ref request, jsonBody: jsonBody, method: httpMethod);
                this.SetRouteHeader(ref request, header: header);

                IRestResponse response = client.Execute(request);
                return this.GetRestResponse<T>(iRes: response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public REST_RESPONSE Delete<T, T2>(string url, string route, List<KeyValuePair<string, string>> header, object jsonBody)
        {
            try
            {
                var httpMethod = Method.DELETE;
                var client = this.InitRestClient(url: url);
                var request = this.InitRouteHttpMethod(route: route, method: httpMethod);

                this.SetRouteBody(ref request, jsonBody: jsonBody, method: httpMethod);
                this.SetRouteHeader(ref request, header: header);

                IRestResponse response = client.Execute(request);
                return this.GetRestResponse<T, T2>(iRes: response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion [DELETE Methods]

        #region [Private Methods]

        private RestClient InitRestClient(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                    throw new Exception("Service url not found.");

                return new RestClient(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private RestRequest InitRouteHttpMethod(string route, Method method)
        {
            try
            {
                if (string.IsNullOrEmpty(route))
                    throw new Exception("Route not found.");

                var request = new RestRequest(resource: route, method: method);
                request.RequestFormat = DataFormat.Json;
                return request;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetRouteHeader(ref RestRequest request, List<KeyValuePair<string, string>> header)
        {
            if (header == null)
                header = new List<KeyValuePair<string, string>>();

            if (header.Where(a => a.Key.Trim().ToLower() == default_ContentTypeKey.Trim().ToLower()).Count() == 0)
                header.Add(new KeyValuePair<string, string>(default_ContentTypeKey, default_ContentTypeValue));

            if (header.Where(a => a.Key.Trim().ToLower() == default_AcceptKey.Trim().ToLower()).Count() == 0)
                header.Add(new KeyValuePair<string, string>(default_AcceptKey, default_AcceptValue));

            foreach (var keyVal in header)
            {
                request.AddHeader(keyVal.Key, keyVal.Value);
            }
        }

        private void SetRouteBody(ref RestRequest request, object jsonBody, Method method)
        {
            try
            {
                if (jsonBody != null)
                {
                    request.AddJsonBody(jsonBody);
                }
                else
                {
                    switch (method)
                    {
                        case Method.POST:
                        case Method.PUT:
                        case Method.DELETE:
                            throw new Exception(method.ToString() + " required at least one parameter(request body).");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private REST_RESPONSE GetRestResponse<T>(IRestResponse iRes)
        {
            REST_RESPONSE res = new REST_RESPONSE();
            try
            {
                if (iRes != null)
                {
                    res.IS_SUCCESS = iRes.IsSuccessful;
                    res.STATUS_CODE = iRes.StatusCode;
                    res.STATUS_DESC = iRes.StatusDescription;
                    res.RESULT = JsonConvert.DeserializeObject<T>(iRes.Content);
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private REST_RESPONSE GetRestResponse<T, T2>(IRestResponse iRes)
        {
            REST_RESPONSE res = new REST_RESPONSE();
            try
            {
                if (iRes != null)
                {
                    res.IS_SUCCESS = iRes.IsSuccessful;
                    res.STATUS_CODE = iRes.StatusCode;
                    res.STATUS_DESC = iRes.StatusDescription;
                    if (res.IS_SUCCESS)
                    {
                        res.RESULT = JsonConvert.DeserializeObject<T>(iRes.Content);
                    }
                    else
                    {
                        res.RESULT = JsonConvert.DeserializeObject<T2>(iRes.Content);
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion  [Private Methods]
    }

    public class REST_RESPONSE
    {
        public bool IS_SUCCESS { get; set; }
        public HttpStatusCode STATUS_CODE { get; set; }
        public string STATUS_DESC { get; set; }
        public object RESULT { get; set; }

        public REST_RESPONSE()
        {
            this.IS_SUCCESS = false;
            this.STATUS_CODE = HttpStatusCode.NotFound;
            this.STATUS_DESC = null;
            this.RESULT = null;
        }
    }
}
