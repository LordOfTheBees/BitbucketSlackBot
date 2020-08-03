using System;
using System.Collections.Generic;
using System.Text;

namespace Bitbucket.API.Data.EnumTypes
{
    public enum RepositoryRole
    {
        /// <summary>
        /// Has explicit administrator access
        /// </summary>
        Admin,

        /// <summary>
        /// Has explicit write access
        /// </summary>
        Contributor,

        /// <summary>
        /// Has explicit read access
        /// </summary>
        Member,

        /// <summary>
        /// Owner of repository
        /// </summary>
        Owner
    }
}
