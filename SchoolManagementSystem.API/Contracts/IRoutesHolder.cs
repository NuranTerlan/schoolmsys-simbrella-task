using System;

namespace SchoolManagementSystem.API.Contracts
{
    public interface IRoutesHolder
    {
        static string Root { get; set; }
        static string Version { get; set; }
        static string Base { get; }
    }
}