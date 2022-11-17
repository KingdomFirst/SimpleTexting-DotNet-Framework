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

using System.Collections.Generic;
using static SimpleTextingDotNet.Enum;

namespace SimpleTextingDotNet.v2.Model.Response
{
    /// <summary>
    /// The API response retrieving a single message.
    /// </summary>
    public class EvaluateResponse
    {
        /// <summary>
        /// Autodetected category of message:
        /// SMS: SMS are regular texts, 160 characters or below
        /// MMS: Multimedia messages.Messages over 306 characters, or with media attached
        /// EXTENDED_SMS: Messages which are above 160 characters, but below 306 characters
        /// </summary>
        public Category DetectedCategory { get; set; }

        /// <summary>
        /// The message length in characters
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// The remaining characters
        /// </summary>
        public int Remains { get; set; }

        /// <summary>
        /// The maximum message length in characters with the current message type and encoding
        /// </summary>
        public int MaxLength { get; set; }

        /// <summary>
        /// Returns true if there is some number of Latin-1 or GSM-7 characters present
        /// </summary>
        public bool Unicode { get; set; }

        /// <summary>
        /// How much credits message will cost
        /// </summary>
        public int SumOfCredits { get; set; }

        /// <summary>
        /// A list of warning messages if present
        /// </summary>
        public List<string> Warnings { get; set; }

        /// <summary>
        /// List of error messages if present
        /// </summary>
        public List<string> Errors { get; set; }

    }
}
