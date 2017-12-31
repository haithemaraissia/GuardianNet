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

        public Query Add(string phrase, bool exact = false)
        {
            if(query.Length <= 0)
                query.Append(exact ? $"\"{phrase}\"" : phrase);
            else
                query.Append(exact ? $" OR \"{phrase}\"" : $" OR {phrase}");

            return this;
        }

        public Query And(string phrase, bool exact = false)
        {
            if(query.Length <= 0)
                throw new InvalidOperationException("You can't add AND when query is empty.");

            query.Append(exact ? $" AND \"{phrase}\"" : $" AND {phrase}");

            return this;
        }

        public Query Not(string phrase, bool exact = false)
        {
            if (query.Length <= 0)
                throw new InvalidOperationException("You can't add OR when query is empty.");

            query.Append(exact ? $" AND NOT \"{phrase}\"" : $" AND NOT {phrase}");

            return this;
        }

        internal string Build()
            => query.ToString().Trim();
    }
}