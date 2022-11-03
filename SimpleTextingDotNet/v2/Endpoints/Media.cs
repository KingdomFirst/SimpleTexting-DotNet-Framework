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
        /// Upload a media file from a local file to SimpleTexting.
        /// </summary>
        /// <param name="file">The media file you want to upload</param>
        /// <param name="shared">Define whether a media file is shared with teammates</param>
        /// <returns>MediaItem</returns>
        public MediaItem Upload( string file, bool shared = true )
        {
            var request = new RestRequest( $"mediaitems/upload?shared={shared}", Method.POST );

            var reqBody = new MediaUpload
            {
                File = file
            };

            AddRequestJsonBody( request, reqBody );
            return Execute<MediaItem>( request );
        }

        /// <summary>
        /// This endpoint allows you to upload media via a URL so that you can send it in a message to a contact.
        /// </summary>
        /// <param name="link">The URL you will upload your media from</param>
        /// <param name="shared">Define whether a media file is shared with teammates</param>
        /// <returns>MediaItem</returns>
        public MediaItem UploadWithLink( string link, bool shared = true )
        {
            var request = new RestRequest( $"mediaitems/loadByLink?shared={shared}", Method.POST );

            var reqBody = new MediaUpload
            {
                Link = link
            };

            AddRequestJsonBody( request, reqBody );
            return Execute<MediaItem>( request );
        }

        /// <summary>
        /// Gets the Media Item. https://api-doc.simpletexting.com/#operation/getMediaItem
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public MediaItem GetMediaItem( string id )
        {
            var request = new RestRequest( $"mediaitems/{id}" );
            request.Method = Method.GET;

            return Execute<MediaItem>( request );
        }

        /// <summary>
        /// Gets the Media Items. https://api-doc.simpletexting.com/#operation/getMediaItems
        /// </summary>
        /// <param name="page">An ordinal number of the page to return with the results of a request (with the media items of the given number). Please note that page numbering starts at zero (0)</param>
        /// <param name="size">The number of the returned media items to show per page</param>
        /// <returns>MessageResponse</returns>
        public MediaItemsResponse GetMediaItems( int? page = null, int? size = null )
        {
            var request = new RestRequest( "mediaitems" );
            request.Method = Method.GET;

            if ( page.HasValue )
            {
                request.AddParameter( "page", page, ParameterType.GetOrPost );
            }
            if ( size.HasValue )
            {
                request.AddParameter( "size", size, ParameterType.GetOrPost );
            }

            return Execute<MediaItemsResponse>( request );
        }

        /// <summary>
        /// Remove media that you have previously uploaded to SimpleTexting.
        /// </summary>
        /// <param name="mediaItemId">Media Item ID in hexadecimal format</param>
        /// <returns></returns>
        public bool DeleteMediaItem( string mediaItemId )
        {
            var request = new RestRequest( $"mediaitems/{mediaItemId}" );
            request.Method = Method.DELETE;

            var response = Execute<MediaItemsResponse>( request );

            return response != null;
        }
    }
}
