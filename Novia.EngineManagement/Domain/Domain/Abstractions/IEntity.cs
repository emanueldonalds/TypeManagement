using System;
using System.Collections.Generic;
using System.Text;
namespace Novia.EngineManagement.Domain.Abstractions
{
    /// <summary>
    /// Marker interface to mark a entity
    /// Represents that the implemented classes are domain entities.
    /// </summary>
    public interface IEntity
    {
    }
    /// <summary>
    /// Marker interface to mark a entity
    /// Represents that the implemented classes are domain entities.
    /// </summary>
    /// <Typeparam name="TKey">The Type of the entity key.</Typeparam>
    public interface IEntity<TKey> : IEntity
    where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the identifier of the entity.
        /// </summary>
        /// <value>
        /// The identifier of the entity.
        /// </value>
        TKey Id { get; set; }
    }
}