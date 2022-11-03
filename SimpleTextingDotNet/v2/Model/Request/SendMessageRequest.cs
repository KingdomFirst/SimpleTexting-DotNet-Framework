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
using System.Collections.Generic;
using System.ComponentModel;
using static SimpleTextingDotNet.Enum;

namespace SimpleTextingDotNet.v2.Model.Request
{
    public class SendMessageRequest
    {
        /// <summary>
        /// The Contact's phone number
        /// </summary>
        [JsonProperty( PropertyName = "contactPhone" )]
        [DefaultValue( "" )]
        public string ContactPhone { get; set; }

        /// <summary>
        /// The account phone, if not set it will use the first phone
        /// </summary>
        [JsonProperty( PropertyName = "accountPhone" )]
        [DefaultValue( "" )]
        public string AccountPhone { get; set; }

        /// <summary>
        /// The message mode
        /// </summary>
        [JsonProperty( PropertyName = "mode" )]
        [DefaultValue( "AUTO" )]
        public string Mode { get; set; }

        /// <summary>
        /// The message subject for mms
        /// </summary>
        [JsonProperty( PropertyName = "subject" )]
        [DefaultValue( "" )]
        public string Subject { get; set; }

        /// <summary>
        /// The text message
        /// </summary>
        [JsonProperty( PropertyName = "text" )]
        [DefaultValue( "" )]
        public string Text { get; set; }

        /// <summary>
        /// The fallback text for mms messages that do not go through
        /// </summary>
        [JsonProperty( PropertyName = "fallbackText" )]
        [DefaultValue( "" )]
        public string FallbackText { get; set; }

        /// <summary>
        /// A list of Media Id's or Url's to send with the mms message
        /// </summary>
        [JsonProperty( PropertyName = "mediaItems" )]
        public List<string> MediaItems { get; set; }
    }
}
