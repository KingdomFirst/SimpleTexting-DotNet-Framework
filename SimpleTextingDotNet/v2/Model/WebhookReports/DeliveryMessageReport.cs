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

using static SimpleTextingDotNet.Enum;

namespace SimpleTextingDotNet.v2.Model.WebhookReports
{
    /// <summary>
    /// The webhook Delivery/Non Delivered Message report, Triggers when an outgoing message is reported as delivered or undelivered by the carrier.
    /// </summary>
    public class DeliveryMessageReport
    {
        /// <summary>
        /// Unique report ID in hexadecimal format
        /// </summary>
        public string ReportId { get; set; }

        /// <summary>
        /// Webhook ID in hexadecimal format
        /// </summary>
        public string webhookId { get; set; }

        /// <summary>
        /// Webhook report content type.
        /// </summary>
        public Trigger Type { get; set; }

        /// <summary>
        /// Report content, DeliveryMessage
        /// </summary>
        public DeliveryMessage Values { get; set; }
    }
}
