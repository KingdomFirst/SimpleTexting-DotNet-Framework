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

using SimpleTextingDotNet.v2.Model.Object;
using SimpleTextingDotNet.v2.Model.Response;
using RestSharp;
using System.Collections.Generic;
using static SimpleTextingDotNet.Enum;

namespace SimpleTextingDotNet.v2
{
    public partial class Client
    {
        /// <summary>
        /// Create a new webhook from scratch.
        /// </summary>
        /// <param name="url">The URL for handling a POST request</param>
        /// <param name="triggers">Trigger a webhook based on a specific platform event</param>
        /// <param name="requestsPerSecLimit">The maximum number of requests that can be sent within a second <= 25</param>
        /// <param name="accountPhone">Optional: requests will come exclusively for the specified account phone number</param>
        /// <param name="contactPhone">Optional: requests will come exclusively for the specified contact's phone number</param>
        /// <returns>MediaItem</returns>
        public ContactResponse CreateWebhook( string url, List<Trigger> triggers, int requestsPerSecLimit = 25, string accountPhone = null, string contactPhone = null )
        {
            var request = new RestRequest( $"webhooks", Method.POST );

            var reqBody = new Webhook
            {
                Url = url,
                Triggers = triggers,
                RequestPerSecLimit = requestsPerSecLimit,
                AccountPhone = accountPhone,
                ContactPhone = contactPhone
            };

            AddRequestJsonBody( request, reqBody );
            return Execute<ContactResponse>( request );
        }

        /// <summary>
        /// Update an existing webhook using its unique ID.
        /// </summary>
        /// <param name="url">The URL for handling a POST request</param>
        /// <param name="triggers">Trigger a webhook based on a specific platform event</param>
        /// <param name="requestsPerSecLimit">The maximum number of requests that can be sent within a second <= 25</param>
        /// <param name="accountPhone">Optional: requests will come exclusively for the specified account phone number</param>
        /// <param name="contactPhone">Optional: requests will come exclusively for the specified contact's phone number</param>
        /// <returns>MediaItem</returns>
        public ContactResponse UpdateWebhook( string webhookid, string url, List<Trigger> triggers, int requestsPerSecLimit = 25, string accountPhone = null, string contactPhone = null )
        {
            var request = new RestRequest( $"webhooks/{webhookid}", Method.PUT );

            var reqBody = new Webhook
            {
                Url = url,
                Triggers = triggers,
                RequestPerSecLimit = requestsPerSecLimit,
                AccountPhone = accountPhone,
                ContactPhone = contactPhone
            };

            AddRequestJsonBody( request, reqBody );
            return Execute<ContactResponse>( request );
        }

        /// <summary>
        /// Get all the Webhooks. https://api-doc.simpletexting.com/#operation/getWebhooks
        /// </summary>
        /// <param name="page">An ordinal number of the page to return with the results of a request (with the webhooks of the given account). Please note that page numbering starts at zero (0)</param>
        /// <param name="size">The number of the returned webhooks to show per page</param>
        /// <returns>WebhooksResponse</returns>
        public WebhooksResponse GetWebhooks( int? page = null, int? size = null )
        {
            var request = new RestRequest( "webhooks" );
            request.Method = Method.GET;

            if ( page.HasValue )
            {
                request.AddParameter( "page", page, ParameterType.GetOrPost );
            }
            if ( size.HasValue )
            {
                request.AddParameter( "size", size, ParameterType.GetOrPost );
            }

            return Execute<WebhooksResponse>( request );
        }

        /// <summary>
        /// Remove media that you have previously uploaded to SimpleTexting.
        /// </summary>
        /// <param name="mediaItemId">Media Item ID in hexadecimal format</param>
        /// <returns></returns>
        public bool DeleteWebhook( string webhookId )
        {
            var request = new RestRequest( $"webhooks/{webhookId}" );
            request.Method = Method.DELETE;

            var response = Execute<MediaItemsResponse>( request );

            return response != null;
        }
    }
}
