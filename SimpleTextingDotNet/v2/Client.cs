// <copyright>
// MIT License
// 
// Copyright (c) 2022 Kingdom First Solutions
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// </copyright>

using Newtonsoft.Json;
using SimpleTextingDotNet.v2.Model.Response;
using RestSharp;
using System;
using System.Net;

namespace SimpleTextingDotNet.v2
{
    public partial class Client
    {
        #region Properties

        /// <summary>
        /// The base URL
        /// </summary>
        private const string _baseUrl = "https://api-app2.simpletexting.com/v2/api/";

        /// <summary>
        /// The client
        /// </summary>
        private readonly IRestClient _client;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="baseUrl">The baseUrl for the API service.</param>
        /// <param name="apiKey">The API key.</param>
        public Client( string apiKey )
        {
            _client = new RestClient( _baseUrl );
            _client.AddDefaultHeader( "Authorization", "Bearer " + apiKey ); // used on every request
        }

        #endregion

        #region Method

        /// <summary>
        /// Executes the specified request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public T Execute<T>( RestRequest request ) where T : new()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var response = _client.Execute<T>( request );

            if ( response.ErrorException != null )
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var exception = new ApplicationException( message, response.ErrorException );
                throw exception;
            }
            else if ( response.Content.Contains( "errorCode" ) )
            {
                var message = "";
                try
                {
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>( response.Content );
                    message = string.Format( "Error Code \"{0}\". {1}", errorResponse.Code, errorResponse.Message );
                } catch
                {
                    var errorResponse = JsonConvert.DeserializeObject<ErrorConflictResponse>( response.Content );
                    message = string.Format( "Error Code \"{0}\". {1}\nDetails: {2}", errorResponse.Code, errorResponse.Message, errorResponse.Details );
                }
                var exception = new ApplicationException( message, response.ErrorException );
                throw exception;
            }
            else if ( response.StatusCode != HttpStatusCode.OK )
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorConflictResponse>( response.Content );
                var message = string.Format( "Error Code \"{0}\". {1}\nDetails: {2}", errorResponse.Code, errorResponse.Message, errorResponse.Details );
                var exception = new ApplicationException( message, response.ErrorException );
                throw exception;

            }
            return response.Data;
        }

        public RestRequest AddRequestJsonBody( RestRequest request, object bodyObject )
        {
            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
            var jsonBody = JsonConvert.SerializeObject( bodyObject, jsonSettings );
            request.AddParameter( "application/json", jsonBody, ParameterType.RequestBody );
            return request;
        }

        public static DateTime UnixTimeStampToDateTime( double unixTimeStamp )
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime( 1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc );
            dateTime = dateTime.AddSeconds( unixTimeStamp ).ToLocalTime();
            return dateTime;
        }

        #endregion
    }
}
