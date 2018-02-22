﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Core.Plugin.Unity.API
{
    /// <summary>
    /// Class that helps with generic using of Http requests.
    /// </summary>
    internal class Accessor
    {
        public string ApiAddress { get; set; }

        private readonly HttpClient _client = new HttpClient();

        internal Accessor(string apiAddress)
        {
            ApiAddress = apiAddress;

            _client.BaseAddress = new Uri(ApiAddress);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Proceeds a GET call using the given url to retrieve an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        internal async Task<T> GetObject<T>(string url)
        {
            T obj = default(T);
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                obj = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            return obj;
        }

        /// <summary>
        /// Proceeds a POST call sending the given object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="object"></param>
        /// <returns></returns>
        internal Task<HttpResponseMessage> PostObject<T>(string url, T @object, string typeHeader = "application/json")
        {
            var obj = JsonConvert.SerializeObject(@object);
            var buffer = System.Text.Encoding.UTF8.GetBytes(obj);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue(typeHeader);
            return _client.PostAsync(url, byteContent);
        }

        /// <summary>
        /// Proceeds a POST call sending the given object in an Encoded Format.
        /// Optionnaly can take a string representing an Authorization.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="object"></param>
        /// <param name="auth"></param>
        /// <returns></returns>
        internal Task<HttpResponseMessage> PostObjectEncoded<T>(string url, T @object)
        {
            var obj = JsonConvert.SerializeObject(@object);
            var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(obj);
            var byteContent = new FormUrlEncodedContent(dic);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            return _client.PostAsync(url, byteContent);
        }

        internal Task<HttpResponseMessage> PostObjectMultipart<T>(string url, T @object)
        {
            var json = JsonConvert.SerializeObject(@object);
            var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            var obj = new StringContent(json);
            var content = new MultipartFormDataContent();

            foreach (var field in dic)
            {
                content.Add(new StringContent(field.Value), field.Key);
            }

            return _client.PostAsync(url, content);
        }

        internal Task<HttpResponseMessage> PostObjectMultipart<T>(string url, T @object, Action<MultipartFormDataContent> FillAdditionalContent)
        {
            var json = JsonConvert.SerializeObject(@object);
            var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            var obj = new StringContent(json);
            var content = new MultipartFormDataContent();

            foreach (var field in dic)
            {
                content.Add(new StringContent(field.Value), field.Key);
            }
            FillAdditionalContent?.Invoke(content);

            return _client.PostAsync(url, content);
        }

        /// <summary>
        /// Sets an authorization using OAuth 2.0 and the given Token.
        /// </summary>
        /// <param name="token"></param>
        internal void SetAuthorizationOAuth(Token token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
        }

        /// <summary>
        /// Sets and authorization using Basic login.
        /// </summary>
        /// <param name="auth"></param>
        internal void SetAuthorizationBasic(string auth)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
        }
    }
}