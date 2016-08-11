using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.Models
{
    public abstract class EntityModel<TId>
    {
        public virtual TId Guid { get; protected set; }
        protected virtual int Version { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as EntityModel<TId>);
        }

        private static bool IsTransient(EntityModel<TId> obj)
        {
            return obj != null &&
                   Equals(obj.Guid, default(TId));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        public virtual bool Equals(EntityModel<TId> other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Guid, other.Guid))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                 otherType.IsAssignableFrom(thisType);
            }
            return false;
        }

        public override int GetHashCode()
        {
            if (Equals(Guid, default(TId)))
                return base.GetHashCode();
            return Guid.GetHashCode();
        }
    }
    public abstract class Entity : EntityModel<Guid> {

    }
    
}