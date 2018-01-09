// GuardianNet/GuardianNet/Query.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System;
using System.Collections.Generic;
using System.Text;

namespace GuardianNet
{
    public class Query
    {
        private readonly StringBuilder query = new StringBuilder();
        
        /// <summary>
        /// Adds OR type query to object
        /// </summary>
        /// <param name="phrase">Words to search</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Throws when PHRASE is empty or null</exception>
        public Query Add(string phrase)
        {

            if (string.IsNullOrWhiteSpace(phrase))
                throw new InvalidOperationException("Cant create request with null or empty query");

            if (query.Length <= 0)
                query.Append(!phrase.Contains(" ") ? phrase : $"\"{phrase}\"");
            else
                query.Append(!phrase.Contains(" ") ? $" OR {phrase}" : $" OR \"{phrase}\"");

            return this;
        }
    
        /// <summary>
        /// Adds AND type query. It means previus word and this have to be in title
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Throws when PHRASE is empty or null</exception>
        public Query And(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                throw new InvalidOperationException("Cant create request with null or empty query");

            if (query.Length <= 0)
                throw new InvalidOperationException("You can't add AND when query is empty.");

            query.Append(!phrase.Contains(" ") ? $" AND {phrase}" : $" AND \"{phrase}\"");

            return this;
        }
        
        /// <summary>
        /// Adds AND NOT type query. It means this word cant exist together with previous query word.
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Query Not(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                throw new InvalidOperationException("Cant create request with null or empty query");
            if (query.Length <= 0)
                throw new InvalidOperationException("You can't add OR when query is empty.");

            query.Append(!phrase.Contains(" ") ? $" AND NOT {phrase}" : $" AND NOT \"{phrase}\"");

            return this;
        }
        
        /// <summary>
        /// Get string representation of Query
        /// </summary>
        /// <returns></returns>
        internal string Build()
            => query.ToString().Trim();
    }
}