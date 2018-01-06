// GuardianNet/GuardianNet/Section.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis

using System.Collections.Generic;

namespace GuardianNet.Models.Sections
{
    public class Section
    {
        public string Id { get; set; }
        public string WebTitle { get; set; }
        public string WebUrl { get; set; }
        public List<SectionEdition> Editions { get; set; }
    }
}