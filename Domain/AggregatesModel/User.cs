using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.AggregatesModel
{
    public class User : Entity, IEntity, IAggregateRoot
    {
        public int TenantId { get; private set; }

        public long OrgId{ get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public bool Enable { get; private set; }

        public bool IsLocked { get; private set; }

        public void ChangePassword(string password)
            => Password = password;
    }
}
