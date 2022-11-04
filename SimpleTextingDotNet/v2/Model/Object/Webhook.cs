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

using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using static SimpleTextingDotNet.Enum;

namespace SimpleTextingDotNet.v2.Model.Object
{
    public class Webhook
    {
        /// <summary>
        /// Existing Webhook ID in hexadecimal format
        /// </summary>
        [JsonProperty( PropertyName = "webhookId" )]
        [DefaultValue( "" )]
        public string WebhookId { get; set; }

        /// <summary>
        /// The URL for handling POST Request
        /// </summary>
        [JsonProperty( PropertyName = "url", Required = Required.Always )]
        [DefaultValue( "" )]
        public string Url { get; set; }

        /// <summary>
        /// Trigger a webhook on specific platform events
        /// </summary>
        [JsonProperty( PropertyName = "triggers", Required = Required.Always )]
        public List<Trigger> Triggers { get; set; }

        /// <summary>
        /// The maximum number of requests that can be sent within one second
        /// </summary>
        [JsonProperty( PropertyName = "requestsPerSecLimit" )]
        [DefaultValue( "" )]
        public int RequestPerSecLimit { get; set; }

        /// <summary>
        /// Optional: requests will come exclusively for the specified account phone number
        /// </summary>
        [JsonProperty( PropertyName = "accountPhone" )]
        [DefaultValue( "" )]
        public string AccountPhone { get; set; }

        /// <summary>
        /// Optional: requests will come exclusively for the specified contact phone number
        /// </summary>
        [JsonProperty( PropertyName = "contactPhone" )]
        [DefaultValue( "" )]
        public string ContactPhone { get; set; }
    }
}
