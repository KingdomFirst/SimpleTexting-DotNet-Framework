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
    public class ContactList
    {
        /// <summary>
        /// Existing List identifier in hexadecimal format
        /// </summary>
        public string ListId { get; set; }

        /// <summary>
        /// The list name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// When the media was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// When the media was created.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Title is present when list is created automatically by a keyword via the dashboard, otherwise defaults to null
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The number of contacts
        /// </summary>
        public int TotalContactsCount { get; set; }

        /// <summary>
        /// The number of active contacts
        /// </summary>
        public int ActiveContactsCount { get; set; }

        /// <summary>
        /// The number of invalid contacts
        /// </summary>
        public int InvalidContactsCount { get; set; }

        /// <summary>
        /// The number of unsubscribed contacts
        /// </summary>
        public int UnsubscribedContactsCount { get; set; }

        /// <summary>
        /// Keywords associated with the list
        /// </summary>
        public List<string> Keywords { get; set; }
    }
}
