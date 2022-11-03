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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextingDotNet.v2.Model.Object
{
    public class MediaItem
    {
        /// <summary>
        /// Existing media ID in hexadecimal format
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// When the media was created. The time is in ISO 8601 format.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The File name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Gallery that contains the item such as "mms"
        /// </summary>
        public string Gallery { get; set; }

        /// <summary>
        /// The File size
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// The Status of the File
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The location of the file
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// The File media type
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The File extension
        /// </summary>
        public string Ext { get; set; }

        /// <summary>
        /// The ability to delete
        /// </summary>
        public bool CanDelete { get; set; }
    }
}
