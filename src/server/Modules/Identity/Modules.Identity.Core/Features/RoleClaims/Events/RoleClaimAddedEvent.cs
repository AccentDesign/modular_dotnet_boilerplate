// --------------------------------------------------------------------------------------------------
// <copyright file="RoleClaimAddedEvent.cs" company="AccentDesign">
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using Modules.Identity.Core.Entities;
using Shared.Core.Domain;

namespace Modules.Identity.Core.Features.RoleClaims.Events
{
    public class RoleClaimAddedEvent : Event
    {
        public int Id { get; }

        public string RoleId { get; }

        public string ClaimType { get; }

        public string ClaimValue { get; }

        public string Group { get; }

        public string Description { get; }

        public RoleClaimAddedEvent(AccentRoleClaim roleClaim)
        {
            RoleId = roleClaim.RoleId;
            Group = roleClaim.Group;
            ClaimType = roleClaim.ClaimType;
            ClaimValue = roleClaim.ClaimValue;
            Description = roleClaim.Description;
            Id = roleClaim.Id;
            AggregateId = Guid.NewGuid();
            RelatedEntities = new[] { typeof(AccentRoleClaim) };
        }
    }
}