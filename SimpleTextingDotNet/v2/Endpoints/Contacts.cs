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

namespace SimpleTextingDotNet.v2
{
    public partial class Client
    {
        /// <summary>
        /// Create a new contact and add them to a specific list.
        /// </summary>
        /// <param name="contactPhone">Contact's phone number</param>
        /// <param name="firstName">Contact's first name</param>
        /// <param name="lastName">Contact's last name</param>
        /// <param name="email">Contact's email</param>
        /// <param name="birthday">Contact's birthday</param>
        /// <param name="comment">Notes about the contact</param>
        /// <param name="lists">All the lists (List IDs or names) to add the contact to or replace.</param>
        /// <param name="customFields">Object that contains custom field values, where you should use a Name or a Merge tag in a property name and a field value as a property value.</param>
        /// <param name="upsert">If a contact already exists with the phone number in your request body, the contact will be updated with the information in the request when upsert is set to true.</param>
        /// <param name="listsReplacement">If listsReplacement is set to true, a contact will be removed from their existing list. If set to false, a contact will be added to a new list and stay in their original list.</param>
        /// <returns>ContactResponse</returns>
        public ContactResponse CreateContact( string contactPhone, string firstName = null, string lastName = null, string email = null, DateTime? birthday = null, string comment = null, List<string> lists = null, dynamic customFields = null, bool upsert = true, bool listsReplacement = true )
        {
            var request = new RestRequest( $"contacts?upsert={upsert}&listsReplacement={listsReplacement}", Method.POST );

            var reqBody = new ContactRequest
            {
                ContactPhone = contactPhone,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Birthday = birthday,
                Comment = comment,
                ListIds = lists,
                CustomFields = customFields
            };

            AddRequestJsonBody( request, reqBody );
            return Execute<ContactResponse>( request );
        }

        /// <summary>
        /// Update a contact's phone number or any other field.
        /// </summary>
        /// <param name="idOrNumber">Contact ID in hexadecimal format or the contact's phone number</param>
        /// <param name="contactPhone">Contact's phone number</param>
        /// <param name="firstName">Contact's first name</param>
        /// <param name="lastName">Contact's last name</param>
        /// <param name="email">Contact's email</param>
        /// <param name="birthday">Contact's birthday</param>
        /// <param name="comment">Notes about the contact</param>
        /// <param name="lists">All the lists (List IDs or names) to add the contact to or replace.</param>
        /// <param name="customFields">Object that contains custom field values, where you should use a Name or a Merge tag in a property name and a field value as a property value.</param>
        /// <param name="upsert">If a contact already exists with the phone number in your request body, the contact will be updated with the information in the request when upsert is set to true.</param>
        /// <param name="listsReplacement">If listsReplacement is set to true, a contact will be removed from their existing list. If set to false, a contact will be added to a new list and stay in their original list.</param>
        /// <returns>ContactResponse</returns>
        public ContactResponse UpdateContact( string idOrNumber, string contactPhone, string firstName = null, string lastName = null, string email = null, DateTime? birthday = null, string comment = null, List<string> lists = null, dynamic customFields = null, bool upsert = true, bool listsReplacement = true )
        {
            var request = new RestRequest( $"contacts/{idOrNumber}?upsert={upsert}&listsReplacement={listsReplacement}", Method.PUT );

            var reqBody = new ContactRequest
            {
                ContactPhone = contactPhone,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Birthday = birthday,
                Comment = comment,
                ListIds = lists,
                CustomFields = customFields
            };

            AddRequestJsonBody( request, reqBody );
            return Execute<ContactResponse>( request );
        }

        /// <summary>
        /// Get a contact via their unique ID or phone number. Phone number is the preferred parameter for this call. https://api-doc.simpletexting.com/#operation/getContact
        /// </summary>
        /// <param name="idOrNumber">Phone number (preferred) or Contact ID in hexadecimal format</param>
        /// <returns>Contact</returns>
        public Contact GetContact( string idOrNumber )
        {
            var request = new RestRequest( $"contacts/{idOrNumber}" );
            request.Method = Method.GET;

            return Execute<Contact>( request );
        }

        /// <summary>
        /// Gets the Contacts. https://api-doc.simpletexting.com/#operation/getContacts
        /// </summary>
        /// <param name="page">An ordinal number of the page to return with the results of a request (with the media items of the given number). Please note that page numbering starts at zero (0)</param>
        /// <param name="size">The number of the returned media items to show per page</param>
        /// <param name="since">List contacts updated since a specified date.</param>
        /// <param name="direction">Specify the sort order of your results. By default, results are sorted by the 'updated' field: ASC or DESC</param>
        /// <returns>ContactsResponse</returns>
        public ContactsResponse GetContacts( int? page = null, int? size = null, DateTime? since = null, string direction = null )
        {
            var request = new RestRequest( "contacts" );
            request.Method = Method.GET;

            if ( page.HasValue )
            {
                request.AddParameter( "page", page, ParameterType.GetOrPost );
            }
            if ( size.HasValue )
            {
                request.AddParameter( "size", size, ParameterType.GetOrPost );
            }
            if ( since.HasValue )
            {
                var sinceIsoString = since.Value.ToString( "o" );
                request.AddParameter( "since", sinceIsoString, ParameterType.GetOrPost );
            }
            if ( !string.IsNullOrWhiteSpace( direction ) )
            {
                request.AddParameter( "direction", direction, ParameterType.GetOrPost );
            }

            return Execute<ContactsResponse>( request );
        }

        /// <summary>
        /// Delete a contact via their unique ID or phone.
        /// </summary>
        /// <param name="idOrNumber">Contact ID in hexadecimal format or phone number</param>
        /// <returns>bool</returns>
        public bool DeleteContact( string idOrNumber )
        {
            var request = new RestRequest( $"contacts/{idOrNumber}" );
            request.Method = Method.DELETE;

            var response = Execute<ContactResponse>( request );

            return response != null;
        }
    }
}
