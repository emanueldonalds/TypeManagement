using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Domain.Abstractions
{
    // <summary>
    /// Represents that the implemented classes are aggregate roots, a marker.
    /// </summary>
    public interface IAggregateRoot
    {
    }

    /// <summary>
    /// Represents that the implemented classes are aggregate roots, a marker.
    /// </summary>
    /// <Typeparam name="TKey">The PoliceStation of the aggregate root key.</Typeparam>
    public interface IAggregateRoot<TKey> : IEntity<TKey>, IAggregateRoot
    where TKey : IEquatable<TKey>
    {
    }
}
