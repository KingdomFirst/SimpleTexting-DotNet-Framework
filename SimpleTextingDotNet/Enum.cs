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

namespace SimpleTextingDotNet
{
    public class Enum
    {
        /// <summary>
        /// Determines how your message will be presented.
        /// AUTO: this means that SimpleTexting will find more relative types for your message content
        /// SINGLE_SMS_STRICTLY: this will send only a single SMS or return an error
        /// MMS_PREFERRED: this will send an MMS or fallback SMS if MMS is not enabled by your contacts' carriers
        /// </summary>
        public enum Mode
        {
            AUTO,
            SINGLE_SMS_STRICTLY,
            MMS_PREFERRED
        }

        /// <summary>
        /// The direction in which the message was sent:
        /// MT: Refers to Mobile Terminating, meaning messages sent to the contacts' cell phones
        /// MO: Refers to Mobile Originating, meaning messages sent from the contacts' cell phones
        /// </summary>
        public enum DirectionType
        {
            MT,
            MO
        }

        /// <summary>
        /// Message category:
        /// SMS: SMS are regular texts, 160 characters or below
        /// MMS: Multimedia messages.Messages over 306 characters, or with media attached
        /// EXTENDED_SMS: Messages which are above 160 characters, but below 306 characters
        /// </summary>
        public enum Category
        {
            SMS,
            MMS,
            EXTENDED_SMS
        }

        /// <summary>
        /// Contacts subscription status
        /// </summary>
        public enum SubscriptionStatus
        {
            OPT_IN,
            OPT_OUT,
            WAIT_SMS_CONFIRMATION,
            REJECT_CONFIRMATION
        }

        /// <summary>
        /// How the contact was updated.
        /// </summary>
        public enum UpdateSource
        {
            IMPORTED_FROM_FILE,
            PUBLIC_API,
            MAILCHIMP_SYNC,
            KEYWORD,
            WEB_FORM,
            MANUAL,
            REMINDER,
            ZAPIER,
            WORKATO,
            CONFIRMATION,
            INCOMING_MESSAGE
        }

        /// <summary>
        /// Trigger a webhook on specific platform events.
        /// INCOMING_MESSAGE: Trigger a webhook event based on an incoming message
        /// OUTGOING_MESSAGE: Trigger a webhook event based on an outgoing message
        /// DELIVERY_REPORT: Trigger a webhook when a delivery confirmation is received from a contact
        /// NON_DELIVERED_REPORT: Trigger a webhook when a failed delivery is reported from a contact
        /// UNSUBSCRIBE_REPORT: Trigger a webhook when a contact unsubscribes
        /// </summary>
        public enum Trigger
        {
            INCOMING_MESSAGE,
            OUTGOING_MESSAGE,
            DELIVERY_REPORT,
            NON_DELIVERED_REPORT,
            UNSUBSCRIBE_REPORT
        }
    }
}
