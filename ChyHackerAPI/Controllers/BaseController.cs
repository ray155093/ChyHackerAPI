
//using MoeaEGFxData_WebAPI.Attribute;
using ChyHackerAPI.Models.Data.Enum;
//using MoeaEGFxData_WebAPI.Data.WebAPI.Service;
//using MoeaEGFxData_WebAPI.Service;
using Newtonsoft.Json;
using RiChi.Library.Common;
using RiChi.Library.Factory;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ChyHackerAPI.Controllers
{
    public class BaseController : ApiController
    {



        private Dictionary<string, string> _servcieParameterDict = new Dictionary<string, string>();

        public bool CheckQueryType(string param1, string param2, string param3)
        {
            bool _isXY = true;
            double _result;
            double x, y, buffer;
            if (double.TryParse(param1, out _result))
                x = Convert.ToDouble(param1);
            else
                _isXY = false;
            if (double.TryParse(param2, out _result))
                y = Convert.ToDouble(param2);
            else
                _isXY = false;
            if (double.TryParse(param3, out _result))
                buffer = Convert.ToDouble(param3);
            else
                _isXY = false;
            return _isXY;
        }

        public string DBConnection(string tagName)
        {
            Encryption _encry = new Encryption();
            string _conn = _encry.Decrypt(tagName);
            _conn = _conn.Replace("\r\n", "");

            return _conn;
        }

        public void ServiceParameADD(string key, string value)
        {
            this._servcieParameterDict.Add(key, value);
        }

        protected T CreateInstance<T>()
        {
            T _service;
            Type _inputType = typeof(T);

            string _path = HttpContext.Current.Server.MapPath("~/bin/");
            string _dllName = "RiChi.Library.Factory";
            string _dllPath = Path.Combine(_path, string.Format("{0}.{1}", _dllName, "dll"));
            Assembly _assembly = Assembly.LoadFrom(_dllPath);
            string _className = string.Format("{0}.{1}", _dllName, "Factory");
            Type _factoyType = _assembly.GetType(_className);

            NameValueCollection _collection =
                        (NameValueCollection)System.Web.Configuration.WebConfigurationManager.GetSection(@"classConfig/ProjectSettings");
            _dllName = _collection["Service"].ToString();
            _dllPath = Path.Combine(_path, string.Format("{0}.{1}", _dllName, "dll"));
            _assembly = Assembly.LoadFrom(_dllPath);
            //string _serviceName = this.ControllerName() + "Service";
            string _serviceName = _inputType.Name;
            _className = _dllName + "." + _serviceName;
            Type _serviceType = _assembly.GetType(_className);

            if (this._servcieParameterDict.Keys.Count == 0)
            {
                MethodInfo _method = _factoyType.GetMethod("CreateInstanceIncParameter", BindingFlags.Static | BindingFlags.Public);
                _method = _method.MakeGenericMethod(_serviceType);
                _service = (T)_method.Invoke(null, new object[] { _path, _dllName + ".dll", _serviceName });
            }
            else
            {
                MethodInfo _method = _factoyType.GetMethod("CraInstanceWithParameInfo", BindingFlags.Static | BindingFlags.Public);
                _method = _method.MakeGenericMethod(_serviceType);
                _service = (T)_method.Invoke(null, new object[] { _path, _dllName + ".dll", _serviceName, _servcieParameterDict });
            }
            return _service;
        }

        //20140811 Renee Add
        protected void JsonResponse<T>(T returnObj) where T : class
        {
            //將回傳的資料寫入Reponse中
            //20150703 JavaScriptSerializer JSON字串超過4MB，就會發生maxJsonLength 不足，
            //改用JSON.NET 做序列化 by Chad
            //System.Web.Script.Serialization.JavaScriptSerializer objSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //string _resultStr = objSerializer.Serialize(returnObj);
            //將List JSON化
            string _resultStr = JsonConvert.SerializeObject(returnObj);
            byte[] bytes = Encoding.UTF8.GetBytes(_resultStr);
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.BufferOutput = true;
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.OutputStream.Write(bytes, 0, bytes.Length);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 使用Newtonsoft.Json實作
        /// </summary>
        /// <param name="returnObj">The return object.</param>
        protected void JsonResponse2 (object returnObj) 
        {
            //將回傳的資料寫入Reponse中
            //20150703 JavaScriptSerializer JSON字串超過4MB，就會發生maxJsonLength 不足，
            //改用JSON.NET 做序列化 by Chad
            //System.Web.Script.Serialization.JavaScriptSerializer objSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //string _resultStr = objSerializer.Serialize(returnObj);
            //將List JSON化
            string _resultStr = JsonConvert.SerializeObject(returnObj);
            byte[] bytes = Encoding.UTF8.GetBytes(_resultStr);
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.BufferOutput = true;
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.OutputStream.Write(bytes, 0, bytes.Length);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 使用預設方法實作
        /// </summary>
        /// <param name="returnObj">The return object.</param>
        protected void JsonResponse(object returnObj)
        {
            System.Web.Script.Serialization.JavaScriptSerializer objSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            StringBuilder sb = new StringBuilder();

            //將回傳的資料寫入Reponse中
            string _resultStr = objSerializer.Serialize(returnObj);
            byte[] bytes = Encoding.UTF8.GetBytes(_resultStr);

            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.BufferOutput = true;
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            HttpContext.Current.Response.OutputStream.Write(bytes, 0, bytes.Length);
            HttpContext.Current.Response.End();
        }

        protected string JsonString<T>(T returnObj) where T : class
        {
            System.Web.Script.Serialization.JavaScriptSerializer objSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            StringBuilder sb = new StringBuilder();

            //將回傳的資料寫入Reponse中
            string _resultStr = objSerializer.Serialize(returnObj);

            return _resultStr;
        }

        protected void Redirect(String url)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.BufferOutput = true;
            HttpContext.Current.Response.ContentType = "charset=utf-8";
            HttpContext.Current.Response.Redirect(url);
            HttpContext.Current.Response.End();
        }

        protected void Response<T>(T returnObj) where T : class
        {
            //將回傳的XML寫入Reponse中
            string _resultXMLStr = XML.Serialize(returnObj);
            byte[] bytes = Encoding.UTF8.GetBytes(_resultXMLStr);

            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.BufferOutput = true;
            HttpContext.Current.Response.ContentType = "text/xml;charset=utf-8";
            HttpContext.Current.Response.OutputStream.Write(bytes, 0, bytes.Length);
            HttpContext.Current.Response.End();
        }

        protected string GetUserIp()
        {
            string CallerIp = null;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null)
            {
                CallerIp = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                CallerIp = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            return CallerIp;
        }



        #region -- Private --

        private string ControllerName()
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString();
        }

        #endregion -- Private --

        public EQueryLevel GetQueryLevel(string querylevel)
        {
            querylevel = querylevel.ToLower();
            if (querylevel.IndexOf("coun") != -1)
            {
                return EQueryLevel.Count;
            }
            else if (querylevel.IndexOf("town") != -1)
            {
                return EQueryLevel.Town;
            }
            else if (querylevel.IndexOf("Code3") != -1)
            {
                return EQueryLevel.Code3;
            }
            else if (querylevel.IndexOf("Code2") != -1)
            {
                return EQueryLevel.Code2;
            }
            else if (querylevel.IndexOf("Code1") != -1)
            {
                return EQueryLevel.Code1;
            }
            else
            { throw new NotImplementedException(); }
        }

        public EDataType GetDataType(string dataType)
        {
            dataType = dataType.ToLower();
            if (dataType.IndexOf("poi") != -1)
            { return EDataType.景點; }
            else if (dataType.IndexOf("passengersna") != -1)
            { return EDataType.區域旅客國籍; }
            else if (dataType.IndexOf("hotellist") != -1)
            { return EDataType.旅館清單; }
            else if (dataType.IndexOf("bablist") != -1)
            { return EDataType.民宿清單; }
            else if (dataType.IndexOf("hotelpeople") != -1)
            { return EDataType.旅館人數; }
            else if (dataType.IndexOf("babpeople") != -1)
            { return EDataType.民宿人數; }
            else if (dataType.IndexOf("poly") != -1)
            { return EDataType.poly; }
            else if (dataType.IndexOf("countnetinfo") != -1)
            { return EDataType.縣市網格; }
            else if (dataType.IndexOf("countbusstation") != -1)
            { return EDataType.縣市公車站; }
            else if (dataType.IndexOf("townsupplydemand") != -1)
            { return EDataType.鄉鎮供需; }
            else
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 找出回傳格式
        /// </summary>
        /// <param name="respType"></param>
        /// <returns></returns>
        public EResponseType GetRespType(string respType)
        {
            respType = respType.ToLower();
            if (respType.IndexOf("xml") != -1)
            { return EResponseType.xml; }
            else if (respType.IndexOf("json") != -1)
            { return EResponseType.json; }
            else
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 找出geoType
        /// </summary>
        /// <param name="geometry"></param>
        /// <returns></returns>
        public EGeometryType GetGeometryType(string geometryStr)
        {
            int geometry = Convert.ToInt16(geometryStr);
            if (geometry == 84)
            { return EGeometryType.WGS84; }
            else
            { return EGeometryType.TWD97; }
        }
    }
}
