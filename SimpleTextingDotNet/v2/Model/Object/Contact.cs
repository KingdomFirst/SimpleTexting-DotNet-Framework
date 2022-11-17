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
using static SimpleTextingDotNet.Enum;

namespace SimpleTextingDotNet.v2.Model.Object
{
    /// <summary>
    /// The contact data.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Gets or sets the contact identifier in hexadecimal format.
        /// </summary>
        public string ContactId { get; set; }

        /// <summary>
        /// Gets or sets the Contact Phone.
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Last Name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Contact's birthday
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// List of all Contact Lists where the contact is stored
        /// </summary>
        public List<ContactListSimple> Lists { get; set; }

        /// <summary>
        /// Object that contains custom field values, where you should use a Name or a Merge tag in a property name and a field value as a property value.
        /// </summary>
        public dynamic CustomFields { get; set; }

        /// <summary>
        /// Notes about the contact
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the Subscription Status.
        /// </summary>
        public SubscriptionStatus SubscriptionStatus { get; set; }

        /// <summary>
        /// When the contact was created. 
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// When the contact was updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// How the contact was updated
        /// </summary>
        public UpdateSource UpdateSource { get; set; }

    }
}
