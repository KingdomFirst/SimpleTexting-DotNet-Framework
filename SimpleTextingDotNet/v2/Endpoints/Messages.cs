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
using SimpleTextingDotNet.v2.Model.Request;
using SimpleTextingDotNet.v2.Model.Response;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using static SimpleTextingDotNet.Enum;

namespace SimpleTextingDotNet.v2
{
    public partial class Client
    {
        /// <summary>
        /// Sends a message. https://api-doc.simpletexting.com/#operation/createMessage
        /// </summary>
        /// <param name="contactPhone">The Contact's phone number to send the message to</param>
        /// <param name="text">The text body of the message</param>
        /// <param name="mode">The mode of the message that determines how it will be presented. Default: Auto</param>
        /// <param name="accountPhone">The account phone to send from. If this field is left blank, the primary account number will be used as a default</param>
        /// <param name="subject">The subject of the MMS message</param>
        /// <param name="fallbackText">The HTML body of the e-mail</param>
        /// <param name="mediaItems">List of MMS media URLs for temporal storing or media items IDs to send with the MMS</param>
        /// <returns>SendResponse</returns>
        public SendResponse SendMessage( string contactPhone, string text, Mode mode = Mode.AUTO, string accountPhone = null, string subject = null, string fallbackText = null, List<string> mediaItems = null )
        {
            var request = new RestRequest( "messages", Method.POST );

            var reqBody = new SendMessageRequest
            {
                ContactPhone = contactPhone,
                Text = text,
                Mode = mode.ToString(),
                AccountPhone = accountPhone,
                Subject = subject,
                FallbackText = fallbackText,
                MediaItems = mediaItems
            };

            AddRequestJsonBody( request, reqBody );
            return Execute<SendResponse>( request );
        }

        /// <summary>
        /// Evaluate the body of your message before sending it to a contact or contacts. https://api-doc.simpletexting.com/#operation/evaluateMessage
        /// We evaluate a message to determine a number of properties. These include the number of credits it will use, whether it is an extended SMS or a regular SMS and any potential errors that may occur.
        /// </summary>
        /// <param name="text">The text body of the message</param>
        /// <param name="mode">The mode of the message that determines how it will be presented. Default: Auto</param>
        /// <param name="subject">The subject of the MMS message</param>
        /// <param name="fallbackText">The HTML body of the e-mail</param>
        /// <param name="mediaItems">List of MMS media URLs for temporal storing or media items IDs to send with the MMS</param>
        /// <returns>EvaluateResponse</returns>
        public EvaluateResponse EvaluateMessage( string text, Mode mode = Mode.AUTO, string subject = null, string fallbackText = null, List<string> mediaItems = null )
        {
            var request = new RestRequest( "messages/evaluate", Method.POST );

            var reqBody = new SendMessageRequest
            {
                Text = text,
                Mode = mode.ToString(),
                Subject = subject,
                FallbackText = fallbackText,
                MediaItems = mediaItems
            };

            AddRequestJsonBody( request, reqBody );
            return Execute<EvaluateResponse>( request );
        }


        /// <summary>
        /// Gets the message. https://api-doc.simpletexting.com/#operation/getMessage
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Message GetMessage( string id )
        {
            var request = new RestRequest( $"messages/{id}" );
            request.Method = Method.GET;

            return Execute<Message>( request );
        }

        /// <summary>
        /// Gets the messages. https://api-doc.simpletexting.com/#operation/getMessages
        /// </summary>
        /// <param name="page">An ordinal number of the page to return with the results of a request (with the messages of the given number). Please note that page numbering starts at zero (0)</param>
        /// <param name="size">The number of the returned messages to show per page</param>
        /// <param name="accountPhone">The phone number on your account the messages were sent to. If blank, the request will return the messages sent to the primary account phone</param>
        /// <param name="since">First sent/received timestamp. The time is sent in ISO 8601 format.</param>
        /// <param name="contactPhone">The contact's phone number</param>
        /// <returns>MessageResponse</returns>
        public MessagesResponse GetMessages( int? page = null, int? size = null, string accountPhone = null, DateTime? since = null, string contactPhone = null )
        {
            var request = new RestRequest( "messages" );
            request.Method = Method.GET;

            if ( page.HasValue )
            {
                request.AddParameter( "page", page, ParameterType.GetOrPost );
            }
            if ( size.HasValue )
            {
                request.AddParameter( "size", size, ParameterType.GetOrPost );
            }
            if ( !string.IsNullOrWhiteSpace( accountPhone ) )
            {
                request.AddParameter( "accountPhone", accountPhone, ParameterType.GetOrPost );
            }
            if ( since.HasValue )
            {
                var sinceIsoString = since.Value.ToString( "o" );
                request.AddParameter( "since", sinceIsoString, ParameterType.GetOrPost );
            }
            if ( !string.IsNullOrWhiteSpace( contactPhone ) )
            {
                request.AddParameter( "contactPhone", contactPhone, ParameterType.GetOrPost );
            }

            return Execute<MessagesResponse>( request );
        }
    }
}
