using System;
using TaxiQualifer.Common.Enums;

namespace TaxiQualifer.Web.Data.Entities
{
    public class UserGroupRequestEntity
    {
        public int Id { get; set; }

        public UserEntity ProposalUser { get; set; }

        public UserEntity RequiredUser { get; set; }

        public UserGroupStatus Status { get; set; }

        public Guid Token { get; set; }

    }
}
