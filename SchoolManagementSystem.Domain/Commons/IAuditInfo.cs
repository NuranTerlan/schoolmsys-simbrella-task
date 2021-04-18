using System;

namespace SchoolManagementSystem.Domain.Commons
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }
        DateTime? LastModifiedOn { get; set; }
    }
}