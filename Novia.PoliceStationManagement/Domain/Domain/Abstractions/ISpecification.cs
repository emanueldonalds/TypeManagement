﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Novia.PoliceStationManagement.Domain.Abstractions
{
    /// <summary>
    /// Represents that the implemented classes are specifications. For more
    /// information about the specification pattern, please refer to
    /// http://martinfowler.com/apsupp/spec.pdf.
    /// </summary>
    /// <Typeparam name="T">The Type of the object to which the specification
    /// is applied.</Typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Gets the LINQ expression which represents the current specification.
        /// </summary>
        /// <returns>The LINQ expression.</returns>
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}