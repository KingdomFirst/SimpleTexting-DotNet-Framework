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
using System.ComponentModel;
using Newtonsoft.Json;
using static SimpleTextingDotNet.Utilities;

namespace SimpleTextingDotNet.v2.Model.Request
{
    /// <summary>
    /// The contact data.
    /// </summary>
    public class ContactRequest
    {
        /// <summary>
        /// Gets or sets the Contact Phone.
        /// </summary>
        [JsonProperty( PropertyName = "contactPhone" )]
        [DefaultValue( "" )]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        [JsonProperty( PropertyName = "firstName" )]
        [DefaultValue( "" )]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Last Name.
        /// </summary>
        [JsonProperty( PropertyName = "lastName" )]
        [DefaultValue( "" )]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [JsonProperty( PropertyName = "email" )]
        [DefaultValue( "" )]
        public string Email { get; set; }

        /// <summary>
        /// Contact's birthday in format (yyyy-mm-dd)
        /// </summary>
        [JsonProperty( PropertyName = "birthday" )]
        [DefaultValue( "" )]
        [JsonConverter( typeof( DateFormatConverter ), "yyyy-MM-dd" )]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Object that contains custom field values, where you should use a Name or a Merge tag in a property name and a field value as a property value.
        /// </summary>
        public dynamic CustomFields { get; set; }

        /// <summary>
        /// Notes about the contact
        /// </summary>
        [JsonProperty( PropertyName = "comment" )]
        [DefaultValue( "" )]
        public string Comment { get; set; }

        /// <summary>
        /// All the lists (List IDs or names) to add the contact to or replace.
        /// </summary>
        public List<string> ListIds { get; set; }

    }
}
